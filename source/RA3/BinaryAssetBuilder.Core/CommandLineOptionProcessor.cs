using BinaryAssetBuilder.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;

namespace BinaryAssetBuilder
{
    public class CommandLineOptionProcessor
    {
        private class OrderedOptionInfo : IComparable<OrderedOptionInfo>
        {
            public PropertyDescriptor Descriptor;
            public OrderedCommandLineOptionAttribute OptionAttribute;

            public OrderedOptionInfo(PropertyDescriptor descriptor, OrderedCommandLineOptionAttribute optionAttribute)
            {
                Descriptor = descriptor;
                OptionAttribute = optionAttribute;
            }

            public int CompareTo(OrderedOptionInfo other)
            {
                if (other is null)
                {
                    throw new InvalidCastException("Cannot compare to 'null'.");
                }
                if (OptionAttribute.Ordinal < other.OptionAttribute.Ordinal)
                {
                    return -1;
                }
                return OptionAttribute.Ordinal <= other.OptionAttribute.Ordinal ? 0 : 1;
            }
        }

        private class OptionalOptionInfo : IComparable<OptionalOptionInfo>
        {
            public PropertyDescriptor Descriptor;
            public OptionalCommandLineOptionAttribute OptionAttribute;
            public OptionalOptionInfo(PropertyDescriptor descriptor, OptionalCommandLineOptionAttribute optionAttribute)
            {
                Descriptor = descriptor;
                OptionAttribute = optionAttribute;
            }

            public int CompareTo(OptionalOptionInfo other)
            {
                if (other is null)
                {
                    throw new InvalidCastException("Cannot compare to 'null'.");
                }
                return string.CompareOrdinal(Descriptor.DisplayName, other.Descriptor.DisplayName);
            }
        }

        private readonly List<OrderedOptionInfo> _orderedOptions = new List<OrderedOptionInfo>();
        private readonly List<OptionalOptionInfo> _optionalOptions = new List<OptionalOptionInfo>();
        private readonly Dictionary<string, OptionalOptionInfo> _optionalOptionLookup = new Dictionary<string, OptionalOptionInfo>();
        private Type _settingsObjectType;
        private int _displayNameMaxLength;
        private object _settingsObject;

        public object SettingsObject { get => _settingsObject; set => SetSettingsObject(value); }

        public CommandLineOptionProcessor(object settingsObject)
        {
            SettingsObject = settingsObject;
        }

        private static void ValidateOption(ACommandLineOptionAttribute attribute, PropertyDescriptor descriptor)
        {
            if (descriptor.IsReadOnly)
            {
                throw new InvalidOperationException($"Property '{descriptor.Name}' is read only.");
            }
            if ((attribute.MinValue != null || attribute.MaxValue != null) && descriptor.PropertyType.GetInterface(nameof(IComparable)) == null)
            {
                throw new InvalidCastException($"Min and Max are specified but type of option property {descriptor.Name} is not comparable");
            }
            if (attribute.MinValue != null && !descriptor.PropertyType.IsAssignableFrom(attribute.MinValue.GetType()))
            {
                throw new InvalidCastException($"Min value {attribute.MinValue} is not assignable to option property {descriptor.Name}");
            }
            if (attribute.MaxValue != null && !descriptor.PropertyType.IsAssignableFrom(attribute.MaxValue.GetType()))
            {
                throw new InvalidCastException($"Max value {attribute.MaxValue} is not assignable to option property {descriptor.Name}");
            }
            if (attribute.ValidValueSet is null)
            {
                return;
            }
            foreach (object validValue in attribute.ValidValueSet)
            {
                if (!descriptor.PropertyType.IsAssignableFrom(validValue.GetType()))
                {
                    throw new InvalidCastException($"Specified valid value {validValue} is not assignable to option property {descriptor.Name}");
                }
            }
        }

        private static object ValidateValue(ACommandLineOptionAttribute attribute, PropertyDescriptor descriptor, string value, List<string> messages)
        {
            object obj;
            try
            {
                if (descriptor.PropertyType.IsEnum)
                {
                    obj = Enum.Parse(descriptor.PropertyType, value, true);
                }
                else
                {
                    obj = Convert.ChangeType(value.Trim('"'), descriptor.PropertyType);
                }
            }
            catch
            {
                messages.Add($"Error: Value '{value}' is not valid for option '{descriptor.DisplayName}'");
                return null;
            }
            if (attribute.MaxValue != null && attribute.MinValue != null)
            {
                if (obj is IComparable comparable)
                {
                    if (comparable.CompareTo(attribute.MinValue) == -1 || comparable.CompareTo(attribute.MaxValue) == 1)
                    {
                        messages.Add($"Error: Value '{value}' for option '{descriptor.DisplayName}' is out of bounds");
                        return null;
                    }
                }
                else
                {
                    messages.Add($"Error: Value '{value}' for option '{descriptor.DisplayName}' cannot be compared to bounds");
                    return null;
                }
            }
            if (attribute.ValidValueSet != null)
            {
                bool isValidValue = false;
                foreach (object validValue in attribute.ValidValueSet)
                {
                    if (obj.Equals(validValue))
                    {
                        isValidValue = true;
                        break;
                    }
                }
                if (!isValidValue)
                {
                    messages.Add($"Error: alue '{value}' is not valid for option '{descriptor.DisplayName}'");
                    return null;
                }
            }
            return obj;
        }

        private string[] ProcessPaths(string combinedPaths)
        {
            string[] result = combinedPaths.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            for (int idx = 0; idx < result.Length; ++idx)
            {
                if (result[idx] != "*")
                {
                    result[idx] = ShPath.Canonicalize(Path.Combine(Settings.Current.DataRoot, result[idx]));
                }
            }
            return result;
        }

        private void SetSettingsObject(object settingsObject)
        {
            _settingsObject = settingsObject;
            _settingsObjectType = _settingsObject.GetType();
            _orderedOptions.Clear();
            _optionalOptions.Clear();
            _optionalOptionLookup.Clear();
            _displayNameMaxLength = 0;
            foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(_settingsObject))
            {
                if (property is null)
                {
                    continue;
                }
                OrderedCommandLineOptionAttribute orderedCommand = property.Attributes[typeof(OrderedCommandLineOptionAttribute)] as OrderedCommandLineOptionAttribute;
                OptionalCommandLineOptionAttribute optionalCommand = property.Attributes[typeof(OptionalCommandLineOptionAttribute)] as OptionalCommandLineOptionAttribute;
                if (orderedCommand != null && optionalCommand != null)
                {
                    throw new InvalidOperationException($"Command line option {property.Name} cannot be ordered and optional at the same time");
                }
                if (orderedCommand != null)
                {
                    ValidateOption(orderedCommand, property);
                    OrderedOptionInfo orderedOption = new OrderedOptionInfo(property, orderedCommand);
                    _displayNameMaxLength = Math.Max(_displayNameMaxLength, property.DisplayName.Length);
                    _orderedOptions.Add(orderedOption);
                }
                else if (optionalCommand != null)
                {
                    ValidateOption(optionalCommand, property);
                    OptionalOptionInfo optionalOption = new OptionalOptionInfo(property, optionalCommand);
                    _optionalOptions.Add(optionalOption);
                    _optionalOptionLookup.Add(property.DisplayName.ToLower(), optionalOption);
                    _displayNameMaxLength = Math.Max(_displayNameMaxLength, property.DisplayName.Length + 1);
                    if (!string.IsNullOrEmpty(optionalCommand.Alias))
                    {
                        string alias = optionalCommand.Alias;
                        char[] separator = new[] { ',' };
                        foreach (string str in alias.Split(separator, StringSplitOptions.RemoveEmptyEntries))
                        {
                            _optionalOptionLookup.Add(str.Trim().ToLower(), optionalOption);
                        }
                    }
                }
            }
            _optionalOptions.Sort();
            _orderedOptions.Sort();
        }

        private bool ProcessOptionsInternal(string[] options, out string[] messages)
        {
            int optionsIdx = 0;
            bool hasErrors = false;
            List<string> echo = new List<string>();
            int idx = 0;
            while (idx < _orderedOptions.Count)
            {
                OrderedOptionInfo orderedOption = _orderedOptions[idx];
                if (optionsIdx == options.Length)
                {
                    echo.Add($"Error: Command line option '{orderedOption.Descriptor.DisplayName}' not specified");
                    hasErrors = true;
                }
                else
                {
                    string option = options[optionsIdx++].Trim();
                    if (!string.IsNullOrEmpty(option) && option[0] != '#')
                    {
                        object obj = ValidateValue(orderedOption.OptionAttribute, orderedOption.Descriptor, option, echo);
                        if (obj != null)
                        {
                            orderedOption.Descriptor.SetValue(_settingsObject, obj);
                        }
                        else
                        {
                            hasErrors = true;
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
                ++idx;
            }
            while (optionsIdx < options.Length)
            {
                string option = options[optionsIdx++].Trim();
                if (!string.IsNullOrEmpty(option) && option[0] != '#')
                {
                    if (option[0] != '/' && option[0] != '-')
                    {
                        echo.Add($"Command line option '{option}' does not start with '/' or '-'");
                        hasErrors = true;
                    }
                    else
                    {
                        string[] optionAndValue = option[1..].Split(new[] { ':' }, 2);
                        if (!_optionalOptionLookup.TryGetValue(optionAndValue[0].ToLower(), out OptionalOptionInfo optionalOption))
                        {
                            echo.Add($"Error: Unknown command line option '{optionAndValue[0]}'");
                            hasErrors = true;
                        }
                        else
                        {
                            string value;
                            if (optionAndValue.Length == 2)
                            {
                                value = optionAndValue[1].Trim();
                            }
                            else if (optionalOption.Descriptor.PropertyType == typeof(bool))
                            {
                                value = "true";
                            }
                            else
                            {
                                echo.Add($"Error: No value for command line option '{optionalOption.Descriptor.DisplayName}' specified");
                                hasErrors = true;
                                continue;
                            }
                            object obj = ValidateValue(optionalOption.OptionAttribute, optionalOption.Descriptor, value, echo);
                            if (obj != null)
                            {
                                optionalOption.Descriptor.SetValue(_settingsObject, obj);
                            }
                            else
                            {
                                hasErrors = true;
                            }
                        }
                    }
                }
            }
            messages = echo.ToArray();
            return !hasErrors;
        }

        public string GetCommandLineHintText()
        {
            StringBuilder sb = new StringBuilder();
            foreach (OrderedOptionInfo orderedOption in _orderedOptions)
            {
                sb.AppendFormat("{0} ", orderedOption.Descriptor.DisplayName);
            }
            foreach (OptionalOptionInfo optionalOption in _optionalOptions)
            {
                sb.AppendFormat("[[/|-]{0}", optionalOption.Descriptor.DisplayName);
                if (!string.IsNullOrEmpty(optionalOption.OptionAttribute.Alias))
                {
                    sb.Append("|");
                    sb.Append(string.Join("|", optionalOption.OptionAttribute.Alias.Split(',', StringSplitOptions.RemoveEmptyEntries)));
                }
                optionalOption.Descriptor.GetValue(_settingsObject);
                sb.Append(":");
                if (optionalOption.Descriptor.PropertyType.IsEnum)
                {
                    sb.Append(string.Join("|", Enum.GetNames(optionalOption.Descriptor.PropertyType)));
                }
                else if (optionalOption.OptionAttribute.ValidValueSet != null)
                {
                    bool first = true;
                    foreach (object validValue in optionalOption.OptionAttribute.ValidValueSet)
                    {
                        if (!first)
                        {
                            sb.Append("|");
                        }
                        first = false;
                        sb.Append(validValue);
                    }
                }
                else if (optionalOption.OptionAttribute.MinValue != null && optionalOption.OptionAttribute.MaxValue != null)
                {
                    sb.AppendFormat("{0}-{1}", optionalOption.OptionAttribute.MinValue, optionalOption.OptionAttribute.MaxValue);
                }
                else if (optionalOption.Descriptor.PropertyType == typeof(bool))
                {
                    sb.Append("true|false");
                }
                else
                {
                    sb.Append(optionalOption.Descriptor.PropertyType.Name);
                }
                sb.Append("] ");
            }
            return sb.ToString().Trim();
        }

        public string GetCommandLineHelpText()
        {
            StringBuilder sb = new StringBuilder();
            foreach (OrderedOptionInfo orderedOption in _orderedOptions)
            {
                sb.AppendFormat("  {0}", orderedOption.Descriptor.DisplayName);
                sb.Append(' ', _displayNameMaxLength + 5 - orderedOption.Descriptor.DisplayName.Length);
                sb.Append(orderedOption.Descriptor.Description);
                object obj = orderedOption.Descriptor.GetValue(_settingsObject);
                if (obj != null)
                {
                    sb.AppendFormat(" (default: {0})", obj);
                }
                sb.Append("\n");
            }
            foreach (OptionalOptionInfo optionalOption in _optionalOptions)
            {
                sb.AppendFormat("  [/|-]{0}", optionalOption.Descriptor.DisplayName);
                sb.Append(' ', _displayNameMaxLength + 4 - optionalOption.Descriptor.DisplayName.Length);
                sb.Append(optionalOption.Descriptor.Description);
                object obj = optionalOption.Descriptor.GetValue(_settingsObject);
                if (obj != null)
                {
                    sb.AppendFormat(" (default: {0})", obj);
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }

        public bool ProcessOptions(string[] options, out string[] messages)
        {
            if (options.Length == 1 && !string.IsNullOrEmpty(options[0]) && options[0][0] == '@')
            {
                string path = options[0][1..];
                if (!File.Exists(path))
                {
                    throw new BinaryAssetBuilderException(ErrorCode.FileNotFound, "Response file '{0}' not found.", path);
                }
                options = File.ReadAllLines(path);
            }
            return ProcessOptionsInternal(options, out messages);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;

namespace BinaryAssetBuilder.Core.CommandLine
{
    public class CommandLineOptionProcessor
    {
        private class OrderedOptionInfo : IComparable<OrderedOptionInfo>
        {
            public PropertyDescriptor Descriptor;
            public OrderedCommandLineOptionAttribute OptionAttribute;

            public int CompareTo(OrderedOptionInfo other)
            {
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

            public int CompareTo(OptionalOptionInfo other)
            {
                return string.Compare(Descriptor.DisplayName, other.Descriptor.DisplayName);
            }
        }

        private readonly List<OrderedOptionInfo> _orderedOptions = new List<OrderedOptionInfo>();
        private readonly List<OptionalOptionInfo> _optionalOptions = new List<OptionalOptionInfo>();
        private readonly Dictionary<string, OptionalOptionInfo> _optionalOptionMap = new Dictionary<string, OptionalOptionInfo>();
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
            if ((attribute.MinValue is not null || attribute.MaxValue is not null) && descriptor.PropertyType.GetInterface(nameof(IComparable)) is null)
            {
                throw new InvalidCastException($"Min and/or Max are specified but type of option property {descriptor.Name} is not comparable.");
            }
            if (attribute.MinValue is not null && !descriptor.PropertyType.IsAssignableFrom(attribute.MinValue.GetType()))
            {
                throw new InvalidCastException($"Min value {attribute.MinValue} is not assignable to option property {descriptor.Name}.");
            }
            if (attribute.MaxValue is not null && !descriptor.PropertyType.IsAssignableFrom(attribute.MaxValue.GetType()))
            {
                throw new InvalidCastException($"Max value {attribute.MaxValue} is not assignable to option property {descriptor.Name}.");
            }
            if (attribute.ValidValueSet is not null)
            {
                foreach (object validValue in attribute.ValidValueSet)
                {
                    if (!descriptor.PropertyType.IsAssignableFrom(validValue.GetType()))
                    {
                        throw new InvalidCastException($"Specified valid value {validValue} is not assignable to option property {descriptor.Name}.");
                    }
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
                messages.Add($"Error: Value '{value}' is not valid for option '{descriptor.DisplayName}'.");
                return null;
            }
            IComparable comparable = obj as IComparable;
            if (attribute.MinValue is not null && comparable.CompareTo(attribute.MinValue) == -1)
            {
                messages.Add($"Error: Value '{value}' for option '{descriptor.DisplayName}' is too small.");
                return null;
            }
            if (attribute.MaxValue is not null && comparable.CompareTo(attribute.MaxValue) == 1)
            {
                messages.Add($"Error: Value '{value}' for option '{descriptor.DisplayName}' is too big.");
                return null;
            }
            if (attribute.ValidValueSet is not null)
            {
                bool isValid = false;
                foreach (object validValue in attribute.ValidValueSet)
                {
                    if (obj.Equals(validValue))
                    {
                        isValid = true;
                        break;
                    }
                }
                if (!isValid)
                {
                    messages.Add($"Error: Value '{value}' is not valid for option '{descriptor.DisplayName}'.");
                    return null;
                }
            }
            return obj;
        }

        private void SetSettingsObject(object settingsObject)
        {
            _settingsObject = settingsObject;
            _orderedOptions.Clear();
            _optionalOptions.Clear();
            _optionalOptionMap.Clear();
            _displayNameMaxLength = 0;
            foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(_settingsObject))
            {
                OrderedCommandLineOptionAttribute orderedAttribute = property.Attributes[typeof(OrderedCommandLineOptionAttribute)] as OrderedCommandLineOptionAttribute;
                OptionalCommandLineOptionAttribute optionalAttribute = property.Attributes[typeof(OptionalCommandLineOptionAttribute)] as OptionalCommandLineOptionAttribute;
                if (orderedAttribute is not null)
                {
                    if (optionalAttribute is not null)
                    {
                        throw new InvalidOperationException($"Command line option property {property.Name} cannot be ordered and optional at the same time.");
                    }
                    ValidateOption(orderedAttribute, property);
                    OrderedOptionInfo orderedOption = new OrderedOptionInfo
                    {
                        OptionAttribute = orderedAttribute,
                        Descriptor = property
                    };
                    _orderedOptions.Add(orderedOption);
                    _displayNameMaxLength = Math.Max(_displayNameMaxLength, property.DisplayName.Length);
                }
                else if (optionalAttribute is not null)
                {
                    ValidateOption(optionalAttribute, property);
                    OptionalOptionInfo optionalOption = new OptionalOptionInfo
                    {
                        OptionAttribute = optionalAttribute,
                        Descriptor = property
                    };
                    _optionalOptions.Add(optionalOption);
                    _optionalOptionMap.Add(property.DisplayName.ToLower(), optionalOption);
                    if (!string.IsNullOrEmpty(optionalAttribute.Alias))
                    {
                        foreach (string alias in optionalAttribute.Alias.Split(',', StringSplitOptions.RemoveEmptyEntries))
                        {
                            _optionalOptionMap.Add(alias.Trim().ToLower(), optionalOption);
                        }
                    }
                    _displayNameMaxLength = Math.Max(_displayNameMaxLength, property.DisplayName.Length + 1);
                }
            }
            _optionalOptions.Sort();
            _orderedOptions.Sort();
        }

        private bool ProcessOptionsInternal(string[] options, out string[] messages)
        {
            int num = 0;
            bool hasErrors = false;
            List<string> errors = new List<string>();
            int index = 0;
            while (index < _orderedOptions.Count)
            {
                OrderedOptionInfo orderedOption = _orderedOptions[index];
                if (num == options.Length)
                {
                    errors.Add($"Error: Command line option '{orderedOption.Descriptor.DisplayName}' not specified.");
                    hasErrors = true;
                }
                else
                {
                    string str = options[num++].Trim();
                    if (!string.IsNullOrEmpty(str) && str[0] != '#')
                    {
                        object obj = ValidateValue(orderedOption.OptionAttribute, orderedOption.Descriptor, str, errors);
                        if (obj is not null)
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
                ++index;
            }
            while (num < options.Length)
            {
                string str = options[num++].Trim();
                if (!string.IsNullOrEmpty(str) && str[0] != '#')
                {
                    if (str[0] != '/' && str[0] != '-')
                    {
                        hasErrors = true;
                        errors.Add($"Error: Command line option '{str}' does not start with '/' or '-'.");
                    }
                    else
                    {
                        string[] optionAndValue = str[1..].Split(':', 2);
                        if (!_optionalOptionMap.TryGetValue(optionAndValue[0].ToLower(), out OptionalOptionInfo optionalOption))
                        {
                            hasErrors = true;
                            errors.Add($"Error: Unknown command line option '{optionAndValue[0]}'.");
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
                                hasErrors = true;
                                errors.Add($"Error: No value for command line option '{optionalOption.Descriptor.DisplayName}' specified.");
                                continue;
                            }
                            object obj = ValidateValue(optionalOption.OptionAttribute, optionalOption.Descriptor, value, errors);
                            if (obj is not null)
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
            messages = errors.ToArray();
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
                sb.AppendFormat("[/{0}", optionalOption.Descriptor.DisplayName);
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
                else if (optionalOption.OptionAttribute.ValidValueSet is not null)
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
                else if (optionalOption.OptionAttribute.MinValue is not null)
                {
                    if (optionalOption.OptionAttribute.MaxValue is null)
                    {
                        sb.AppendFormat("{0}..", optionalOption.OptionAttribute.MinValue);
                    }
                    else
                    {
                        sb.AppendFormat("{0}-{1}", optionalOption.OptionAttribute.MinValue, optionalOption.OptionAttribute.MaxValue);
                    }
                }
                else if (optionalOption.OptionAttribute.MaxValue is not null)
                {
                    sb.AppendFormat("..{0}", optionalOption.OptionAttribute.MaxValue);
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

        public string GetCommandLineHelpText(int width)
        {
            StringBuilder sb = new StringBuilder();
            foreach (OrderedOptionInfo orderedOption in _orderedOptions)
            {
                sb.AppendFormat("  {0}", orderedOption.Descriptor.DisplayName);
                sb.Append(' ', _displayNameMaxLength + 5 - orderedOption.Descriptor.DisplayName.Length);
                sb.Append(orderedOption.Descriptor.Description);
                object defaultValue = orderedOption.Descriptor.GetValue(_settingsObject);
                if (defaultValue is not null)
                {
                    sb.AppendFormat(" (default: {0})", defaultValue);
                }
                sb.AppendLine();
            }
            foreach (OptionalOptionInfo optionalOption in _optionalOptions)
            {
                sb.AppendFormat("  /{0}", optionalOption.Descriptor.DisplayName);
                sb.Append(' ', _displayNameMaxLength + 4 - optionalOption.Descriptor.DisplayName.Length);
                sb.Append(optionalOption.Descriptor.Description);
                object defaultValue = optionalOption.Descriptor.GetValue(_settingsObject);
                if (defaultValue is not null)
                {
                    sb.AppendFormat(" (default: {0})", defaultValue);
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
                options = File.Exists(path) ? File.ReadAllLines(path) : throw new BinaryAssetBuilderException(ErrorCode.FileNotFound, "Response file '{0}' not found.", path);
            }
            return ProcessOptionsInternal(options, out messages);
        }
    }
}

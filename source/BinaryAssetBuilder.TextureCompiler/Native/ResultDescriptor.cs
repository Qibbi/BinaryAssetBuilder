using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Native
{
    public sealed class ResultDescriptor : IEquatable<ResultDescriptor>
    {
        private const string _unknownText = "Unknown";

        private static readonly object _lock = new object();
        private static readonly List<Type> _registeredDescriptorProvider = new List<Type>();
        private static readonly Dictionary<Result, ResultDescriptor> _descriptors = new Dictionary<Result, ResultDescriptor>();

        public Result Result { get; }
        public int Code => Result.Code;
        public string Module { get; }
        public string NativeApiCode { get; }
        public string ApiCode { get; }
        public string Description { get; private set; }

        public ResultDescriptor(Result code, string module, string nativeApiCode, string apiCode, string description = null)
        {
            Result = code;
            Module = module;
            NativeApiCode = nativeApiCode;
            ApiCode = apiCode;
            Description = description;
        }

        public static bool operator ==(ResultDescriptor x, ResultDescriptor y)
        {
            if (x is null)
            {
                return false;
            }
            return x.Result.Code == y.Result.Code;
        }

        public static bool operator !=(ResultDescriptor x, ResultDescriptor y)
        {
            if (x is null)
            {
                return false;
            }
            return x.Result.Code != y.Result.Code;
        }

        public static implicit operator Result(ResultDescriptor x)
        {
            return x.Result;
        }

        public static explicit operator int(ResultDescriptor x)
        {
            return x.Result.Code;
        }

        public static explicit operator uint(ResultDescriptor x)
        {
            return unchecked((uint)x.Result.Code);
        }

        [DllImport("kernel32.dll", EntryPoint = "FormatMessageW")]
        private static extern uint FormatMessageW(int dwFlags, IntPtr lpSource, int dwMessageId, int dwLanguageId, ref IntPtr lpBuffer, int nSize, IntPtr arguments);

        private static void AddDescriptorsFromType(Type type)
        {
            foreach (FieldInfo field in type.GetTypeInfo().DeclaredFields)
            {
                if (field.FieldType == typeof(ResultDescriptor) && field.IsPublic && field.IsStatic)
                {
                    ResultDescriptor descriptor = (ResultDescriptor)field.GetValue(null);
                    if (!_descriptors.ContainsKey(descriptor.Result))
                    {
                        _descriptors.Add(descriptor.Result, descriptor);
                    }
                }
            }
        }

        private static string GetDescriptionFromResultCode(int resultCode)
        {
            const int format_message_allocate_buffer = 0x00000100;
            const int format_message_ignore_inserts = 0x00000200;
            const int format_message_from_system = 0x00001000;
            IntPtr buffer = IntPtr.Zero;
            FormatMessageW(format_message_allocate_buffer | format_message_ignore_inserts | format_message_from_system, IntPtr.Zero, resultCode, 0, ref buffer, 0, IntPtr.Zero);
            string description = Marshal.PtrToStringUni(buffer);
            Marshal.FreeHGlobal(buffer);
            return description;
        }

        public static void RegisterProvider(Type descriptorsProviderType)
        {
            lock (_lock)
            {
                if (!_registeredDescriptorProvider.Contains(descriptorsProviderType))
                {
                    _registeredDescriptorProvider.Add(descriptorsProviderType);
                }
            }
        }

        public static ResultDescriptor Find(Result result)
        {
            ResultDescriptor descriptor;
            lock (_lock)
            {
                if (_registeredDescriptorProvider.Count > 0)
                {
                    foreach (Type type in _registeredDescriptorProvider)
                    {
                        AddDescriptorsFromType(type);
                    }
                    _registeredDescriptorProvider.Clear();
                }
                if (!_descriptors.TryGetValue(result, out descriptor))
                {
                    descriptor = new ResultDescriptor(result, _unknownText, _unknownText, _unknownText);
                }
                if (descriptor.Description is null)
                {
                    descriptor.Description = GetDescriptionFromResultCode(result.Code) ?? _unknownText;
                }
            }
            return descriptor;
        }

        public bool Equals([AllowNull] ResultDescriptor other)
        {
            if (other is null)
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }
            return other.Result.Equals(Result);
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            return obj is ResultDescriptor objT && Equals(objT);
        }

        public override int GetHashCode()
        {
            return Result.GetHashCode();
        }

        public override string ToString()
        {
            return $"HRESULT: [0x{Result.Code:X8}], Module: [{Module}], ApiCode: [{NativeApiCode}/{ApiCode}], Message: {Description}";
        }
    }
}

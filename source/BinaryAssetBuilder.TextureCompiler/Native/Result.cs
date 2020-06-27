using BinaryAssetBuilder;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace Native
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Result : IEquatable<Result>
    {
        public static Result Ok { get; } = new Result(unchecked(0x00000000));
        public static Result False { get; } = new Result(unchecked(0x00000001));
        public static ResultDescriptor Abort { get; } = new ResultDescriptor(unchecked(0x80004004), "General", "E_ABORT", "Operation aborted");
        public static ResultDescriptor AccessDenied { get; } = new ResultDescriptor(unchecked(0x80070005), "General", "E_ACCESSDENIED", "General access denied error");
        public static ResultDescriptor Fail { get; } = new ResultDescriptor(unchecked(0x80004005), "General", "E_FAIL", "Unspecified error");
        public static ResultDescriptor Handle { get; } = new ResultDescriptor(unchecked(0x80070006), "General", "E_HANDLE", "Invalid handle");
        public static ResultDescriptor InvalidArg { get; } = new ResultDescriptor(unchecked(0x80070057), "General", "E_INVALIDARG", "Invalid arguments");
        public static ResultDescriptor NoInterface { get; } = new ResultDescriptor(unchecked(0x80004002), "General", "E_NOINTERFACE", "No such interface supported");
        public static ResultDescriptor NotImplemented { get; } = new ResultDescriptor(unchecked(0x80004001), "General", "E_NOTIMPL", "Not implemented");
        public static ResultDescriptor OutOfMemory { get; } = new ResultDescriptor(unchecked(0x8007000E), "General", "E_OUTOFMEMORY", "Out of memory");
        public static ResultDescriptor InvalidPointer { get; } = new ResultDescriptor(unchecked(0x80004003), "General", "E_POINTER", "Invalid pointer");
        public static ResultDescriptor UnexpectedFailure { get; } = new ResultDescriptor(unchecked(0x8000FFFF), "General", "E_UNEXPECTED", "Catastrophic failure");
        public static ResultDescriptor WaitAbandoned { get; } = new ResultDescriptor(unchecked(0x00000080), "General", "WAIT_ABANDONED", "Wait abandoned");
        public static ResultDescriptor WaitTimeout { get; } = new ResultDescriptor(unchecked(0x00000102), "General", "WAIT_TIMEOUT", "Wait timeout");
        public static ResultDescriptor Pending { get; } = new ResultDescriptor(unchecked(0x8000000A), "General", "E_PENDING", "Pending");

        private int _code;

        public int Code => _code;
        public bool Success => _code >= 0;
        public bool Failure => _code < 0;

        public Result(int code)
        {
            _code = code;
        }

        public Result(uint code)
        {
            _code = unchecked((int)code);
        }

        public static bool operator ==(Result x, Result y)
        {
            return x.Code == y.Code;
        }

        public static bool operator !=(Result x, Result y)
        {
            return x.Code != y.Code;
        }

        public static explicit operator int(Result x)
        {
            return x.Code;
        }

        public static explicit operator uint(Result x)
        {
            return unchecked((uint)x.Code);
        }

        public static implicit operator Result(int x)
        {
            return new Result(x);
        }

        public static implicit operator Result(uint x)
        {
            return new Result(x);
        }

        public static Result GetResultFromException(Exception ex)
        {
            return new Result(Marshal.GetHRForException(ex));
        }

        public static Result GetResultFromWin32Error(int win32Error)
        {
            const int facility_win32 = 7;
            return win32Error <= 0 ? win32Error : (int)((win32Error & 0x0000FFFF) | (facility_win32 << 16) | 0x80000000);
        }

        public void CheckError()
        {
            if (_code < 0)
            {
                throw new BinaryAssetBuilderException(ErrorCode.InternalError, "{0}", this);
            }
        }

        public bool Equals([AllowNull] Result other)
        {
            return Code == other.Code;
        }

        public override bool Equals(object obj)
        {
            return obj is Result objT && Equals(objT);
        }

        public override int GetHashCode()
        {
            return Code;
        }

        public override string ToString()
        {
            return $"HRESULT = 0x{_code:X8}";
        }
    }
}

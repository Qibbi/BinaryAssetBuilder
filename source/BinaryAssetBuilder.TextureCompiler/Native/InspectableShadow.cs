using System;
using System.Runtime.InteropServices;

namespace Native
{
    internal class InspectableShadow : AComObjectShadow
    {
        public class InspectableProviderVtbl : ComObjectVtbl
        {
            private enum TrustLevel
            {
                BaseTrust,
                PartialTrust,
                FullTrust
            }

            public unsafe InspectableProviderVtbl() : base(3)
            {
                AddMethod(new GetIidsDelegate(GetIids));
                AddMethod(new GetRuntimeClassNameDelegate(GetRuntimeClassName));
                AddMethod(new GetTrustLevelDelegate(GetTrustLevel));
            }

            [UnmanagedFunctionPointer(CallingConvention.StdCall)]
            private unsafe delegate int GetIidsDelegate(IntPtr thisPtr, int* iidCount, IntPtr* iids);

            private unsafe static int GetIids(IntPtr thisPtr, int* iidCount, IntPtr* iids)
            {
                try
                {
                    InspectableShadow shadow = ToShadow<InspectableShadow>(thisPtr);
                    IInspectable callback = (IInspectable)shadow.Callback;
                    ShadowContainer container = (ShadowContainer)callback.Shadow;
                    int countGuids = container.Guids.Length;
                    iids = (IntPtr*)Marshal.AllocCoTaskMem(IntPtr.Size * countGuids);
                    *iidCount = countGuids;
                    for (int idx = 0; idx < countGuids; ++idx)
                    {
                        iids[idx] = container.Guids[idx];
                    }
                }
                catch (Exception ex)
                {
                    return (int)Result.GetResultFromException(ex);
                }
                return Result.Ok.Code;
            }

            [UnmanagedFunctionPointer(CallingConvention.StdCall)]
            private delegate int GetRuntimeClassNameDelegate(IntPtr thisPtr, IntPtr className);

            private static int GetRuntimeClassName(IntPtr thisPtr, IntPtr className)
            {
                try
                {
                    InspectableShadow shadow = ToShadow<InspectableShadow>(thisPtr);
                    IInspectable callback = (IInspectable)shadow.Callback;
                }
                catch (Exception ex)
                {
                    return (int)Result.GetResultFromException(ex);
                }
                return Result.Ok.Code;
            }

            [UnmanagedFunctionPointer(CallingConvention.StdCall)]
            private delegate int GetTrustLevelDelegate(IntPtr thisPtr, IntPtr trustLevel);

            private static int GetTrustLevel(IntPtr thisPtr, IntPtr trustLevel)
            {
                try
                {
                    InspectableShadow shadow = ToShadow<InspectableShadow>(thisPtr);
                    IInspectable callback = (IInspectable)shadow.Callback;
                    Marshal.WriteInt32(trustLevel, (int)TrustLevel.FullTrust);
                }
                catch (Exception ex)
                {
                    return (int)Result.GetResultFromException(ex);
                }
                return Result.Ok.Code;
            }
        }

        private static readonly InspectableProviderVtbl _vtbl = new InspectableProviderVtbl();

        protected override CppObjectVtbl GetVtbl => _vtbl;

        public static IntPtr ToIntPtr(IInspectable callback)
        {
            return ToCallbackPtr<IInspectable>(callback);
        }
    }
}
using System;

namespace Native
{
    public class ObjectReference
    {
        public DateTime CreationTime { get; }
        public WeakReference Object { get; }
        public string StackTrace { get; }
        public bool IsAlive => Object.IsAlive;

        public ObjectReference(DateTime creationTime, ComObject comObject, string stackTrace)
        {
            CreationTime = creationTime;
            Object = new WeakReference(comObject, true);
            StackTrace = stackTrace;
        }

        public override string ToString()
        {
            if (!(Object.Target is ComObject comObject))
            {
                return string.Empty;
            }
            return $"Active COM Object: [0x{comObject.NativePointer.ToInt64():X16}] Class: [{comObject.GetType().FullName}] Time [{CreationTime}] Stack:\r\n{StackTrace}";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Native
{
    public class ComObjectEventArgs : EventArgs
    {
        public ComObject Object { get; }

        public ComObjectEventArgs(ComObject obj)
        {
            Object = obj;
        }
    }

    public static class ObjectTracker
    {
        private class GetStackTraceException : Exception
        {
        }

        private static Dictionary<IntPtr, List<ObjectReference>> _processGlobalObjectReferences;
        [ThreadStatic] private static Dictionary<IntPtr, List<ObjectReference>> _threadStaticObjectReferences;

        public static Func<string> StackTraceProvider = GetStackTrace;

        private static Dictionary<IntPtr, List<ObjectReference>> ObjectReferences
        {
            get
            {
                Dictionary<IntPtr, List<ObjectReference>> result;
                if (Configuration.UseThreadStaticObjectTracking)
                {
                    if (_threadStaticObjectReferences is null)
                    {
                        _threadStaticObjectReferences = new Dictionary<IntPtr, List<ObjectReference>>(EqualityComparer.DefaultIntPtr);
                    }
                    result = _threadStaticObjectReferences;
                }
                else
                {
                    if (_processGlobalObjectReferences is null)
                    {
                        _processGlobalObjectReferences = new Dictionary<IntPtr, List<ObjectReference>>(EqualityComparer.DefaultIntPtr);
                    }
                    result = _processGlobalObjectReferences;
                }
                return result;
            }
        }

        public static event EventHandler<ComObjectEventArgs> Tracked;
        public static event EventHandler<ComObjectEventArgs> UnTracked;

        private static void OnTracked(ComObject obj)
        {
            Tracked?.Invoke(null, new ComObjectEventArgs(obj));
        }

        private static void OnUnTracked(ComObject obj)
        {
            UnTracked?.Invoke(null, new ComObjectEventArgs(obj));
        }

        public static string GetStackTrace()
        {
            try
            {
                throw new GetStackTraceException();
            }
            catch (GetStackTraceException ex)
            {
                return ex.StackTrace;
            }
        }

        public static void Track(ComObject comObject)
        {
            if (comObject is null || comObject.NativePointer == IntPtr.Zero)
            {
                return;
            }
            lock (ObjectReferences)
            {
                if (!ObjectReferences.TryGetValue(comObject.NativePointer, out List<ObjectReference> references))
                {
                    references = new List<ObjectReference>();
                    ObjectReferences.Add(comObject.NativePointer, references);
                }
                references.Add(new ObjectReference(DateTime.Now, comObject, StackTraceProvider != null ? StackTraceProvider() : string.Empty));
                OnTracked(comObject);
            }
        }

        public static List<ObjectReference> Find(IntPtr comObjectPtr)
        {
            lock (ObjectReferences)
            {
                if (ObjectReferences.TryGetValue(comObjectPtr, out List<ObjectReference> references))
                {
                    return new List<ObjectReference>(references);
                }
            }
            return new List<ObjectReference>();
        }

        public static ObjectReference Find(ComObject comObject)
        {
            lock (ObjectReferences)
            {
                if (ObjectReferences.TryGetValue(comObject.NativePointer, out List<ObjectReference> references))
                {
                    foreach (ObjectReference reference in references)
                    {
                        if (ReferenceEquals(reference.Object.Target, comObject))
                        {
                            return reference;
                        }
                    }
                }
            }
            return null;
        }

        public static void UnTrack(ComObject comObject)
        {
            if (comObject is null || comObject.NativePointer == IntPtr.Zero)
            {
                return;
            }
            lock (ObjectReferences)
            {
                if (ObjectReferences.TryGetValue(comObject.NativePointer, out List<ObjectReference> references))
                {
                    for (int idx = references.Count - 1; idx >= 0; --idx)
                    {
                        ObjectReference reference = references[idx];
                        if (ReferenceEquals(reference.Object.Target, comObject))
                        {
                            references.RemoveAt(idx);
                        }
                        else if (!reference.IsAlive)
                        {
                            references.RemoveAt(idx);
                        }
                    }
                    if (references.Count == 0)
                    {
                        ObjectReferences.Remove(comObject.NativePointer);
                    }
                    OnUnTracked(comObject);
                }
            }
        }

        public static List<ObjectReference> FindActiveObjects()
        {
            List<ObjectReference> result = new List<ObjectReference>();
            lock (ObjectReferences)
            {
                foreach (List<ObjectReference> references in ObjectReferences.Values)
                {
                    foreach (ObjectReference reference in references)
                    {
                        if (reference.IsAlive)
                        {
                            result.Add(reference);
                        }
                    }
                }
            }
            return result;
        }

        public static string ReportActiveObjects()
        {
            StringBuilder sb = new StringBuilder();
            int count = 0;
            Dictionary<string, int> countPerType = new Dictionary<string, int>();
            foreach (ObjectReference activeObject in FindActiveObjects())
            {
                string str = activeObject.ToString();
                if (!string.IsNullOrEmpty(str))
                {
                    sb.AppendFormat("[{0}]: {1}", count, str);
                    object target = activeObject.Object.Target;
                    if (!(target is null))
                    {
                        string targetType = target.GetType().Name;
                        if (!countPerType.TryGetValue(targetType, out int typeCount))
                        {
                            countPerType[targetType] = 0;
                        }
                        else
                        {
                            countPerType[targetType] = typeCount + 1;
                        }
                    }
                }
                ++count;
            }
            List<string> keys = new List<string>(countPerType.Keys);
            keys.Sort();
            sb.AppendLine();
            sb.AppendLine("Count per type:");
            foreach (string key in keys)
            {
                sb.AppendFormat("{0}: {1}", key, countPerType[key]);
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }
}

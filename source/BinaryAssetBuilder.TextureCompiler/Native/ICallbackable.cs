using System;

namespace Native
{
    public interface ICallbackable : IDisposable
    {
        IDisposable Shadow { get; set; }
    }
}

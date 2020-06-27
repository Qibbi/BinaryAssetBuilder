using System.Runtime.InteropServices;

namespace Native
{
    [Guid("AF86E2E0-B12D-4c6a-9C5A-D7AA65101E90"), Shadow(typeof(InspectableShadow))]
    public interface IInspectable : ICallbackable
    {
    }
}
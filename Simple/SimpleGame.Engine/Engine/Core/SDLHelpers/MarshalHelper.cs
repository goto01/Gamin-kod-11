using System;
using System.Runtime.InteropServices;

namespace SimpleGame.Engine.Engine.Core.SDLHelpers
{
    public static class MarshalHelper
    {
        public static T GetObjectFromPointer<T>(IntPtr pointer)
        {
            return (T)Marshal.PtrToStructure(
                pointer,
                typeof(T)
            );
        }
    }
}

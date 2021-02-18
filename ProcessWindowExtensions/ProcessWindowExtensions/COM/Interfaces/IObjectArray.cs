// From -> https://github.com/Grabacr07/VirtualDesktop/blob/master/source/VirtualDesktop/Interop/IObjectArray.cs

using System;
using System.Runtime.InteropServices;

namespace ProcessWindowExtensions.COM.Interfaces
{
    [ComImport]
    [Guid("92CA9DCD-5622-4BBA-A805-5E9F541BD8C9")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IObjectArray
    {
        uint GetCount();

        object GetAt(uint iIndex, ref Guid riid, [Out] [MarshalAs(UnmanagedType.Interface)]
            out object ppvObject);
    }
}
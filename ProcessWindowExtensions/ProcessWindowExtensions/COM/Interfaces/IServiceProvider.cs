// From -> https://github.com/Grabacr07/VirtualDesktop/blob/master/source/VirtualDesktop/Interop/IServiceProvider.cs

using System;
using System.Runtime.InteropServices;

namespace ProcessWindowExtensions.COM.Interfaces
{
    [ComImport]
    [Guid("6D5140C1-7436-11CE-8034-00AA006009FA")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComVisible(false)]
    public interface ICOMServiceProvider
    {
        [PreserveSig]
        [return: MarshalAs(UnmanagedType.I4)]
        int QueryService(ref Guid guidService, ref Guid riid,
            [MarshalAs(UnmanagedType.Interface)] out object ppvObject);
    }
}
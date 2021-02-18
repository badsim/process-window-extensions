// Partially from -> https://github.com/MScholtes/VirtualDesktop/blob/master/VirtualDesktop.cs

using System;
using System.Runtime.InteropServices;

namespace ProcessWindowExtensions.COM.Interfaces
{
    [ComImport]
    [Guid("FF72FFDD-BE7E-43FC-9C03-AD81681E88E4")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IVirtualDesktop
    {
        bool IsViewVisible(object pView);

        Guid GetID();

        void GetName([MarshalAs(UnmanagedType.HString)] out string name);

        int Unknown1();
    }
}
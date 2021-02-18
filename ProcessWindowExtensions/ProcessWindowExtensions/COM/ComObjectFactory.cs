using System;
using ProcessWindowExtensions.COM.Interfaces;

namespace ProcessWindowExtensions.COM
{
    public class ComObjectFactory
    {
        private ICOMServiceProvider _icomServiceProvider;

        public ICOMServiceProvider GetImmersiveShell()
        {
            if (_icomServiceProvider is not null) return _icomServiceProvider;

            var type = Type.GetTypeFromCLSID(ComClassIdentifiers.ImmersiveShell);
            if (type is null) return null;
            _icomServiceProvider = (ICOMServiceProvider) Activator.CreateInstance(type!);
            return _icomServiceProvider;
        }

        public IApplicationViewCollection GetIApplicationViewCollection()
        {
            var shell = GetImmersiveShell();
            shell.QueryService(
                typeof(IApplicationViewCollection).GUID,
                typeof(IApplicationViewCollection).GUID, out var obj
            );
            var _iApplicationViewCollection = (IApplicationViewCollection) obj;
            return _iApplicationViewCollection;
        }

        public IVirtualDesktopManager GetIVirtualDesktopManager()
        {
            var type = Type.GetTypeFromCLSID(ComClassIdentifiers.VirtualDesktopManager);
            if (type is null) return null;
            return (IVirtualDesktopManager) Activator.CreateInstance(type);
        }

        public IVirtualDesktopManagerInternal GetVirtualDesktopManagerInternal()
        {
            var shell = GetImmersiveShell();
            shell.QueryService(
                ComClassIdentifiers.VirtualDesktopManagerInternal,
                typeof(IVirtualDesktopManagerInternal).GUID,
                out var virtualDesktopManagerInternal);
            return virtualDesktopManagerInternal as IVirtualDesktopManagerInternal;
        }
    }
}
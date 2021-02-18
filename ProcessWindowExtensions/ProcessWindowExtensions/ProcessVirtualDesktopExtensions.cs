using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using ProcessWindowExtensions.COM;
using ProcessWindowExtensions.COM.Interfaces;

namespace ProcessWindowExtensions
{
    public static class ProcessVirtualDesktopExtensions
    {
        private static readonly ComObjectFactory ComObjectFactory;

        static ProcessVirtualDesktopExtensions()
        {
            ComObjectFactory ??= new ComObjectFactory();
        }

        /// <summary>
        ///     Moves window to selected virtual desktop.
        /// </summary>
        /// <param name="process">Valid process with MainWindowHandle set</param>
        /// <param name="desktopId">Id of a desktop counting from left, firt one is 0</param>
        public static Guid MoveToDesktop(this Process process, int desktopId)
        {
            ValidateProcessWindow(process);

            var availableVirtualDesktops = GetAvailableVirtualDesktops();
            if (availableVirtualDesktops.Count < desktopId)
                return Guid.Empty;

            var targetVirtualDesktop = availableVirtualDesktops.ElementAt(desktopId);

            ComObjectFactory.GetIApplicationViewCollection().GetViewForHwnd(
                process.MainWindowHandle,
                out var iApplicationView);

            ComObjectFactory.GetVirtualDesktopManagerInternal().MoveViewToDesktop(
                iApplicationView,
                targetVirtualDesktop
            );

            return targetVirtualDesktop.GetID();
        }

        public static Guid GetVirtualDesktopGuid(this Process process)
        {
            ValidateProcessWindow(process);
            ComObjectFactory.GetIVirtualDesktopManager().GetWindowDesktopId(process.MainWindowHandle, out var guid);
            return guid;
        }

        /// <summary>
        ///     Todo move to helpers class.
        /// </summary>
        public static List<Guid> GetAvailableDesktopsGuids()
        {
            var list = new List<Guid>();
            ComObjectFactory.GetVirtualDesktopManagerInternal().GetDesktops(out var desktops);
            var count = desktops.GetCount();
            for (uint i = 0; i < count; i++)
            {
                desktops.GetAt(i, typeof(IVirtualDesktop).GUID, out var desktopObject);
                list.Add(((IVirtualDesktop) desktopObject).GetID());
            }

            return list;
        }

        /// <summary>
        ///     Todo: move to helper class.
        /// </summary>
        /// <returns></returns>
        public static List<IVirtualDesktop> GetAvailableVirtualDesktops()
        {
            var list = new List<IVirtualDesktop>();
            ComObjectFactory.GetVirtualDesktopManagerInternal().GetDesktops(out var desktops);
            var count = desktops.GetCount();
            for (uint i = 0; i < count; i++)
            {
                desktops.GetAt(i, typeof(IVirtualDesktop).GUID, out var desktopObject);
                list.Add(desktopObject as IVirtualDesktop);
            }

            return list;
        }

        private static void ValidateProcessWindow(Process process)
        {
            var tries = 0;
            var maxTries = 100;
            while (process.MainWindowHandle == IntPtr.Zero)
            {
                if (tries++ > maxTries) throw new NullReferenceException("Process window not found.");
                Thread.SpinWait(1000);
            }
        }
    }
}
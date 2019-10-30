using System;
using System.Text;
using System.Runtime.InteropServices;

internal static class iupcontrols_c {

  static DynamicLinker dynlink = new DynamicLinker("iupcontrols");

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate void IupControlsOpenDelegate();
  internal static IupControlsOpenDelegate IupControlsOpen = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupControlsOpen"),typeof(IupControlsOpenDelegate)) as IupControlsOpenDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate IntPtr IupCellsDelegate();
  internal static IupCellsDelegate IupCells = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupCells"),typeof(IupCellsDelegate)) as IupCellsDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate IntPtr IupColorbarDelegate();
  internal static IupColorbarDelegate IupColorbar = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupColorbar"),typeof(IupColorbarDelegate)) as IupColorbarDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate IntPtr IupColorBrowserDelegate();
  internal static IupColorBrowserDelegate IupColorBrowser = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupColorBrowser"),typeof(IupColorBrowserDelegate)) as IupColorBrowserDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate IntPtr IupDialDelegate(string orientation);
  internal static IupDialDelegate IupDial = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupDial"),typeof(IupDialDelegate)) as IupDialDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate IntPtr IupMatrixDelegate(string action_cb);
  internal static IupMatrixDelegate IupMatrix = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupMatrix"),typeof(IupMatrixDelegate)) as IupMatrixDelegate;

}

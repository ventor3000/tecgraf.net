using System;
using System.Text;
using System.Runtime.InteropServices;

internal static class NativeIUPControls
{

	const string libName = "iupcontrols";

	[DllImport (libName, CallingConvention=CallingConvention.Cdecl)]
  internal static extern void IupControlsOpen ();

	[DllImport (libName, CallingConvention=CallingConvention.Cdecl)]
  internal static extern IntPtr IupCells ();

	[DllImport (libName, CallingConvention=CallingConvention.Cdecl)]
  internal static extern IntPtr IupColorbar ();

	[DllImport (libName, CallingConvention=CallingConvention.Cdecl)]
  internal static extern IntPtr IupColorBrowser ();

	[DllImport (libName, CallingConvention=CallingConvention.Cdecl)]
  internal static extern IntPtr IupDial (string orientation);

	[DllImport (libName, CallingConvention=CallingConvention.Cdecl)]
  internal static extern IntPtr IupMatrix (string action_cb);
}

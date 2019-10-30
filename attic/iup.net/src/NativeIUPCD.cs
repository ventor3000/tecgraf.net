using System;
using System.Text;
using System.Runtime.InteropServices;

internal static class NativeIUPCD
{
	const string libName = "iupcd";

	[DllImport(libName,CallingConvention=CallingConvention.Cdecl)]
	internal static extern IntPtr cdContextIup ();
}

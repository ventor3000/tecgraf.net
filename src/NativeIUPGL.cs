using System;
using System.Text;
using System.Runtime.InteropServices;

internal static class NativeIUPGL
{
	const string libName = "iupgl";

	[DllImport(libName,CallingConvention=CallingConvention.Cdecl)]
	internal static extern IntPtr IupGLCanvas (string action);

	[DllImport(libName,CallingConvention=CallingConvention.Cdecl)]
	internal static extern void IupGLCanvasOpen ();

	[DllImport(libName,CallingConvention=CallingConvention.Cdecl)]
	internal static extern void IupGLMakeCurrent (IntPtr ih);

	[DllImport(libName,CallingConvention=CallingConvention.Cdecl)]
	internal static extern int IupGLIsCurrent (IntPtr ih);

	[DllImport(libName,CallingConvention=CallingConvention.Cdecl)]
	internal static extern void IupGLSwapBuffers (IntPtr ih);

	[DllImport(libName,CallingConvention=CallingConvention.Cdecl)]
	internal static extern void IupGLPalette (IntPtr ih, int index, float r, float g, float b);

	[DllImport(libName,CallingConvention=CallingConvention.Cdecl)]
	internal static extern void IupGLUseFont (IntPtr ih, int first, int count, int list_base);

	[DllImport(libName,CallingConvention=CallingConvention.Cdecl)]
	internal static extern void IupGLWait (int gl);
}

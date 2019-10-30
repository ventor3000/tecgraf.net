using System;
using System.Text;
using System.Runtime.InteropServices;

internal static class iupgl_c {

  static DynamicLinker dynlink = new DynamicLinker("iupgl");

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate IntPtr IupGLCanvasDelegate(string action);
  internal static IupGLCanvasDelegate IupGLCanvas = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupGLCanvas"),typeof(IupGLCanvasDelegate)) as IupGLCanvasDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate void IupGLCanvasOpenDelegate();
  internal static IupGLCanvasOpenDelegate IupGLCanvasOpen = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupGLCanvasOpen"),typeof(IupGLCanvasOpenDelegate)) as IupGLCanvasOpenDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate void IupGLMakeCurrentDelegate(IntPtr ih);
  internal static IupGLMakeCurrentDelegate IupGLMakeCurrent = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupGLMakeCurrent"),typeof(IupGLMakeCurrentDelegate)) as IupGLMakeCurrentDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate int IupGLIsCurrentDelegate(IntPtr ih);
  internal static IupGLIsCurrentDelegate IupGLIsCurrent = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupGLIsCurrent"),typeof(IupGLIsCurrentDelegate)) as IupGLIsCurrentDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate void IupGLSwapBuffersDelegate(IntPtr ih);
  internal static IupGLSwapBuffersDelegate IupGLSwapBuffers = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupGLSwapBuffers"),typeof(IupGLSwapBuffersDelegate)) as IupGLSwapBuffersDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate void IupGLPaletteDelegate(IntPtr ih, int index, float r, float g, float b);
  internal static IupGLPaletteDelegate IupGLPalette = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupGLPalette"),typeof(IupGLPaletteDelegate)) as IupGLPaletteDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate void IupGLUseFontDelegate(IntPtr ih, int first, int count, int list_base);
  internal static IupGLUseFontDelegate IupGLUseFont = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupGLUseFont"),typeof(IupGLUseFontDelegate)) as IupGLUseFontDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate void IupGLWaitDelegate(int gl);
  internal static IupGLWaitDelegate IupGLWait = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupGLWait"),typeof(IupGLWaitDelegate)) as IupGLWaitDelegate;

}

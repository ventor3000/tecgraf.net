using System;
using System.Text;
using System.Runtime.InteropServices;

internal static class iupimglib_c {

  static DynamicLinker dynlink = new DynamicLinker("iupimglib");

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate void IupImageLibOpenDelegate();
  internal static IupImageLibOpenDelegate IupImageLibOpen = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupImageLibOpen"),typeof(IupImageLibOpenDelegate)) as IupImageLibOpenDelegate;

}

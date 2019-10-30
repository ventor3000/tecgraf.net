using System;
using System.Text;
using System.Runtime.InteropServices;

internal static class iupcd_c {

  static DynamicLinker dynlink = new DynamicLinker("iupcd");

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate IntPtr cdContextIupDelegate();
  internal static cdContextIupDelegate cdContextIup = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("cdContextIup"),typeof(cdContextIupDelegate)) as cdContextIupDelegate;

}

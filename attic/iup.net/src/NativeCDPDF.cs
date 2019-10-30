using System;
using System.Text;
using System.Runtime.InteropServices;

internal static class NativeCDPDF{

  static DynamicLinker dynlink = new DynamicLinker("cdpdf");

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate IntPtr cdContextPDFDelegate();
  internal static cdContextPDFDelegate cdContextPDF = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("cdContextPDF"),typeof(cdContextPDFDelegate)) as cdContextPDFDelegate;

}

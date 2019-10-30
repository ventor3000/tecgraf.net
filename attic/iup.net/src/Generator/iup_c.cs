using System;
using System.Text;
using System.Runtime.InteropServices;

internal static class iup_c {

  static DynamicLinker dynlink = new DynamicLinker("iup");

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate int IupOpenDelegate(IntPtr argv,IntPtr argc);
  internal static IupOpenDelegate IupOpen = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupOpen"),typeof(IupOpenDelegate)) as IupOpenDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate void IupMessageDelegate(string title,string message);
  internal static IupMessageDelegate IupMessage = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupMessage"),typeof(IupMessageDelegate)) as IupMessageDelegate;

}

using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Reflection;
using System.IO;

public class DynamicLinker
{
  IntPtr dllhandle;
  string dllpath;


  public DynamicLinker(string modname)
  {

      dllpath = modname + ".dll";
      dllhandle = LoadLibrary(dllpath);

      if (dllhandle == IntPtr.Zero)
          throw new Exception("Failed to load library:" + dllpath);

    /*
    string sep = Path.DirectorySeparatorChar.ToString();
    string asmpath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + sep;
    string dllext = "dll";

    int bits = IntPtr.Size * 8;

    if (bits == 32)
      asmpath += "win32" + sep;
    else if (bits == 64)
      asmpath += "win64" + sep;
    else
      throw new Exception("Unknown bitwidth, only 32 or 64 bit supported");

    dllpath = asmpath + modname + "." + dllext;

    dllhandle = LoadLibrary(dllpath);

    if (dllhandle == IntPtr.Zero)
      throw new Exception("Failed to load library:" + dllpath);*/
  }

  public IntPtr GetFunction(string funcname)
  {
    IntPtr res = GetProcAddress(dllhandle, funcname);
    if (res == IntPtr.Zero)
      throw new Exception("Failed to get function '" + funcname + "' from file " + dllpath);
    
    return res;
  }

  [DllImport("kernel32.dll")]
  private static extern IntPtr LoadLibrary(string libname);

  [DllImport("kernel32.dll")]
  private static extern IntPtr GetProcAddress(IntPtr libhandle, string libname);
}

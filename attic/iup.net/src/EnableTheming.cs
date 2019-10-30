using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Tecgraf
{

    [SuppressUnmanagedCodeSecurity]
    public static class EnableThemingInScope
    {

        
        //Declare all the Dll Imports, these are C++ Dll's
        [DllImport("Kernel32.dll")]
        private extern static IntPtr CreateActCtxA(ref ACTCTX actctx);
        [DllImport("Kernel32.dll")]
        private extern static bool ActivateActCtx(IntPtr hActCtx, IntPtr lpCookie);
        //Create a structure to hold Active Content 
        private struct ACTCTX
        {
            public int cbSize;
            public uint dwFlags;
            public string lpSource;
            public ushort wProcessorArchitecture;
            public ushort wLangId;
            public string lpAssemblyDirectory;
            public IntPtr lpResourceName;
            public string lpApplicationName;
            //public IntPtr hModule;
        }
        




        public static bool EnableThemingInWindows() {
            ACTCTX actctx = new ACTCTX();
            actctx.cbSize=Marshal.SizeOf(actctx);
            actctx.dwFlags=28;
            actctx.lpSource="shell32.dll";
            actctx.wProcessorArchitecture=0;
            actctx.wLangId=0;
            actctx.lpAssemblyDirectory=Environment.SystemDirectory;
            actctx.lpResourceName=(IntPtr)124;

            IntPtr c=CreateActCtxA(ref actctx);
            bool suc=ActivateActCtx(c,IntPtr.Zero);

			return suc;
        }
    }


    



    

}

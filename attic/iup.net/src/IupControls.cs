
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tecgraf
{
    public class IupControls
    {
        public static void Open() { NativeIUPControls.IupControlsOpen(); }
		public static IupHandle Cells() {return IupHandle.Create(NativeIUPControls.IupCells());}
		public static IupHandle Colorbar() { return IupHandle.Create(NativeIUPControls.IupColorbar()); }
		public static IupHandle ColorBrowser() { return IupHandle.Create(NativeIUPControls.IupColorBrowser()); }
		public static IupHandle Dial(string orientation=null) { return IupHandle.Create(NativeIUPControls.IupDial(orientation)); }
		public static IupHandle Matrix(string action_cb=null) { return IupHandle.Create(NativeIUPControls.IupMatrix(action_cb)); }
    }
}


using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Tecgraf.ObjectIup
{


    public enum DialogPlacement
    {
        Full,
        Maximized,
        Minimized,
        Normal
    }
    

    public class Dialog:IupComposite
    {

        // Keep local resources here to be nice to garbage collection
        private static List<Dialog> _visibleDialogs = new List<Dialog>();
        private Button _enterbutton = null;
        private Button _escapebutton = null;
        private Glyph _icon = null;
        private Dialog _parentdialog = null;
        private Glyph _opacityimage=null;
        private Glyph _trayimage=null;

        public Dialog(string title=null)
            : base(null,Iup.Dialog(null))
        {

            Handle.SetCallback("SHOW_CB", new CBShow((h, state) => { return _internalOnShow(h, state); }));
            Handle.SetCallback("CLOSE_CB", new CBDefault((h) => { return OnClose(h); }));
            Handle.SetCallback("COPYDATA_CB", new CBCopyData((h,cmdlin,size) => { return OnCopyData(h,cmdlin,size); }));
            Handle.SetCallback("MOVE_CB", new CBMove((h, x, y) => { return OnMove(h, x, y); }));
            Handle.SetCallback("RESIZE_CB", new CBResize((h, wi, he) => { return OnResize(h, wi, he); }));
            Handle.SetCallback("TRAYCLICK_CB", new CBTrayClick((h, butidx,pressed,dclick) => { return OnTrayClick(h,butidx,pressed,dclick); }));

            
            if (title != null)
                this.Title = title;
        }

        


        public virtual Color Background
        {
            get
            {
                return Parse.Color(Handle.GetStrAttribute("BACKGROUND"));
            }
            set
            {
                Handle.SetStrAttribute("BACKGROUND",Format.Color(value));

            }
        }

        public virtual bool Border
        {
            get
            {
                return GetBool("BORDER");
            }
            set
            {
                SetBool("BORDER", value, "YES", "NO");
            }
        }

        /// <summary>
        /// Allow to specify a position offset for the child in pixel units. Available for native containers only. 
        /// It will not affect the natural size, and allows to position controls outside the client area. 
        /// </summary>
        public virtual Point ChildOffset
        {
            get
            {
                return GetPoint("CHILDOFFSET");
            }
            set
            {
                Handle.SetStrAttribute("CHILDOFFSET", Format.Point(value, "x"));
            }
        }


        public virtual Cursor Cursor
        {
            get
            {
                return Parse.Cursor(Handle.GetStrAttribute("CURSOR"));
            }
            set
            {
                Handle.SetStrAttribute("CURSOR", Format.Cursor(value));
            }
        }
                

        public virtual bool DropFilesTarget
        {
            get
            {
                return GetBool("DROPFILESTARGET");
            }
            set
            {
                SetBool("DROPFILESTARGET", value, "YES", "NO");
            }
        }


        /// <summary>
        /// Same as 'Active', but does not gray out the dialogs children.
        /// </summary>
        public bool ActiveNoGraying
        {
            get
            {
                return GetBool("NACTIVE");
            }
            set
            {
                SetBool("NACTIVE", value, "YES", "NO");
            }
        }

        public override void Show()
        {
            base.Show();
        }


        public string Title
        {
            get
            {
                return Handle.GetStrAttribute("TITLE");
            }

            set
            {
                Handle.SetStrAttribute("TITLE", value);
            }
        }

        public virtual Button DefaultEnter
        {
            get
            {
                return _enterbutton;
            }
            set
            {
                if (value == null)
                    return; //TODO: IUP cannot set this to null, its still set. We dont null either. Hear with antonio why.

                _enterbutton = value;
                Handle.SetAttributeHandle("DEFAULTENTER", value == null ? null : value.Handle);
            }
        }

        public virtual Button DefaultEscape
        {
            get
            {
                return _escapebutton;
            }
            set
            {

                if (value == null)
                    return; //TODO: IUP cannot set this to null, its still set. We dont null either. Hear with antonio why.
                
                _escapebutton = value;
                Handle.SetAttributeHandle("DEFAULTESC", value == null ? null : value.Handle);
            }
        }


        public virtual bool DialogFrame
        {
            get
            {
                return GetBool("DIALOGFRAME");
            }
            set
            {
                SetBool("DIALOGFRAME", value, "YES", "NO");
            }
        }

        public virtual Glyph Icon
        {
            get
            {
                return _icon;
            }

            set
            {
                _icon = value;
                Handle.SetAttributeHandle("ICON", value == null ? null : value.Handle);
            }
        }

        public virtual bool FullScreen
        {
            get
            {
                return GetBool("FULLSCREEN");
            }
            set
            {
                SetBool("FULLSCREEN", value, "YES", "NO");
            }
        }


        /// <summary>
        /// [Windows only] Returns the Windows Window handle. Available in the Windows driver or in the GTK driver in Windows.
        /// </summary>
        public virtual IntPtr HWND
        {
            get
            {
                return Handle.GetAttribute("HWND");
            }
        }


        public virtual bool MaxBox
        {
            get
            {
                return GetBool("MAXBOX");
            }
            set
            {
                SetBool("MAXBOX", value, "YES","NO");
            }
        }

        /// <summary>
        /// Maximum size for the dialog in raster units (pixels). 
        /// The windowing system will not be able to change the size beyond this limit. Default: 65535x65535. 
        /// </summary>
        public virtual Size MaxSize
        {
            get
            {
                return GetSize("MAXSIZE");
            }
            set
            {
                Handle.SetStrAttribute("MAXSIZE", Format.Size(value));
            }
        }

        
        //TODO: MENU


        /// <summary>
        /// (creation only): Requires a system menu box from the window manager. 
        /// If hidden will also remove the Close button. 
        /// Default: true. In Motif the decorations are controlled by the Window Manager and may not be possible to be changed 
        /// from IUP. In Windows if hidden will hide also MaxBox and MinBox.
        /// </summary>
        public virtual bool MenuBox
        {
            get
            {
                return GetBool("MENUBOX");
            }
            set
            {
                SetBool("MENUBOX", value, "YES", "NO");
            }
        }

        /// <summary>
        /// (creation only): Requires a minimize button from the window manager. 
        /// Default: YES. In Motif the decorations are controlled by the Window Manager and may not be possible to be changed from IUP.
        /// In Windows MinBox is hidden only if MaxBox is hidden as well, or else it will be just disabled.
        /// </summary>
        public virtual bool MinBox
        {
            get
            {
                return GetBool("MINBOX");
            }
            set
            {
                SetBool("MINBOX", value, "YES", "NO");
            }
        }

        /// <summary>
        /// Minimum size for the dialog in raster units (pixels). 
        /// The windowing system will not be able to change the size beyond this limit. 
        /// Default: 1x1. Some systems define a very minimum size greater than this, 
        /// for instance in Windows the horizontal minimum size includes the window decoration buttons.
        /// </summary>
        public virtual Size MinSize
        {
            get
            {
                return GetSize("MINSIZE");
            }
            set
            {
                Handle.SetStrAttribute("MINSIZE", Format.Size(value));
            }
        }

        /// <summary>
        ///  Gets the popup state. 
        ///  It is true if the dialog was shown using IupPopup. 
        ///  It is false if IupShow was used or it is not visible.
        /// </summary>
        public virtual bool Modal
        {
            get
            {
                return GetBool("MODAL");
            }
        }

        /// <summary>
        /// (creation only)
        /// This dialog will be always in front of the parent dialog.
        /// If the parent is minimized, this dialog is automatically minimized. The parent dialog must be mapped before mapping the child dialog.
        /// If ParentDialog is not defined then the NativeParent attribute is consulted. 
        /// </summary>
        public virtual Dialog ParentDialog
        {
            get
            {
                return _parentdialog;
            }

            set
            {
                _parentdialog = value;
                Handle.SetAttributeHandle("PARENTDIALOG", value == null ? null : value.Handle);
            }

        }

        /// <summary>
        /// (creation only)
        /// Native handle of a dialog to be used as parent. Used only if ParentDialog is not defined.
        /// </summary>
        public virtual IntPtr NativeParent
        {
            get
            {
                return Handle.GetAttribute("NATIVEPARENT");
            }
            set
            {
                Handle.SetAttribute("NATIVEPARENT", value);
            }
        }


        /// <summary>
        /// Changes how the dialog will be shown. Default: Normal. After Show/Popup the attribute is set back to Normal. 
        /// 'Full' is similar to FullScreen=true but only the dialog client area covers the screen area,
        /// menu and decorations will be there but out of the screen. 
        /// In UNIX there is a chance that the placement won't work correctly, that depends on the Window Manager. 
        /// </summary>
        public virtual DialogPlacement Placement
        {
            get
            {
                return AttToEnum<DialogPlacement>(Handle.GetStrAttribute("PLACEMENT"),
                    "FULL", DialogPlacement.Full,
                    "MAXIMIZED", DialogPlacement.Maximized,
                    "MINIMIZED", DialogPlacement.Minimized,
                    "NORMAL", DialogPlacement.Normal);
            }

            set
            {
                Handle.SetStrAttribute("PLACEMENT",EnumToAtt<DialogPlacement>(value,
                    "FULL", DialogPlacement.Full,
                    "MAXIMIZED", DialogPlacement.Maximized,
                    "MINIMIZED", DialogPlacement.Minimized,
                    "NORMAL", DialogPlacement.Normal));
            }
        }


        /// <summary>
        /// (creation only)
        /// Allows interactively changing the dialog’s size. 
        /// Default: true. If false, then MaxBox will be set to false. 
        /// In Motif the decorations are controlled by the Window Manager and may not be possible to be changed from IUP.
        /// </summary>
        public virtual bool Resize
        {
            get
            {
                return GetBool("RESIZE");
            }
            set
            {
                SetBool("RESIZE", value, "YES", "NO");
            }
        }

        /// <summary>
        /// [Windows and Motif Only] (creation only)
        /// When this attribute is true, the dialog stores the original image of the desktop region it occupies 
        /// (if the system has enough memory to store the image). In this case, when the dialog is closed or moved, 
        /// a redrawing event is not generated for the windows that were shadowed by it. 
        /// Its default value is true. To save memory disable it for your main dialog. Not available in GTK.
        /// </summary>
        public virtual bool SaveUnder
        {
            get
            {
                return GetBool("SAVEUNDER");
            }
            set
            {
                SetBool("SAVEUNDER", value, "YES", "NO");
            }
        }

        /// <summary>
        /// Allows changing the elements distribution when the dialog is smaller than the minimum size. Default: false.
        /// </summary>
        public virtual bool Shrink
        {
            get
            {
                return GetBool("SHRINK");
            }
            set
            {
                SetBool("SHRINK", value, "YES", "NO");
            }
        }

        /// <summary>
        /// Sets the control that should have focus upon the next Show() or Popup().  
        /// If not defined then the first control than can receive the focus is selected.
        /// Updated after CBShow is called and only if the focus was not changed during the callback.
        /// </summary>
        public virtual IupControl StartFocus
        {
            set
            {
                Handle.SetAttributeHandle("STARTFOCUS", value == null ? null : value.Handle);
            }
        }


        /// <summary>
        /// [UNIX Only] (non inheritable, read-only)
        /// Returns the X-Windows Window (Drawable). Available in the Motif driver or in the GTK driver in UNIX.
        /// </summary>
        public virtual IntPtr XWindow
        {
            get
            {
                return Handle.GetAttribute("XWINDOW");
            }
        }

        /// <summary>
        /// [Windows and GTK Only] (read-only)
        /// Informs if the dialog is the active window (the window with focus). Can be Yes or No.
        /// </summary>
        public virtual bool ActiveWindow
        {
            get
            {
                return GetBool("ACTIVEWINDOW");
            }
        }


        public virtual int Opacity
        {
            get
            {
                return Handle.GetInt("OPACITY");
            }
            set
            {
                Handle.SetInt("OPACITY", value);
            }
        }

        public virtual Glyph OpacityImage
        {
            get
            {
                return _opacityimage;
            }
            set
            {
                _opacityimage = value;
                Handle.SetAttributeHandle("OPACITYIMAGE", value == null ? null : value.Handle);
            }
        }

       

        /// <summary>
        /// [Windows and GTK Only]
        /// Puts the dialog always in front of all other dialogs in all applications. Default: false.
        /// </summary>
        public virtual bool Topmost
        {
            get
            {
                return GetBool("TOPMOST");
            }
            set
            {
                SetBool("TOPMOST", value, "YES", "NO");
            }
        }


        public virtual bool HideTaskbar
        {
            
            set
            {
                SetBool("HIDETASKBAR", value, "YES", "NO");
            }
        }

        public virtual bool Tray
        {
            get
            {
                return GetBool("TRAY");
            }
            set
            {
                SetBool("TRAY", value, "YES", "FALSE");
            }
        }

        public virtual Glyph TrayGlyph
        {
            get
            {
                return _trayimage;
            }
            set
            {
                _trayimage = value;
                Handle.SetAttributeHandle("TRAYIMAGE", value == null ? null : value.Handle);
            }
        }

        public virtual string TrayTip
        {
            get
            {
                return Handle.GetStrAttribute("TRAYTIP");
            }
            set
            {
                Handle.SetStrAttribute("TRAYTIP", value);
            }
        }


        #region CALLBACKS


        protected override CBResult OnInternalDestroyCallback(IupHandle sender)
        {
            //be nice to garbage collector:
            _enterbutton = null;
            _escapebutton = null;
            _icon = null;
            _parentdialog = null;
            _opacityimage = null;
            return base.OnInternalDestroyCallback(sender);
        }


        /// <summary>
        /// Called just before a dialog is closed when the user clicks the close button of the title bar or an equivalent action.
        /// If result is set to Ignore, the dialog is prevented from beeing closed. If the dialog is destroyed/disposed from
        /// within this callback, the result HAS to be set to Ignore.
        /// </summary>
        public event EventHandler<IupEventArgs> CBClose;
        public virtual CBResult OnClose(IupHandle sender)
        {
            IupEventArgs ea = new IupEventArgs();
            if (CBClose != null)
                CBClose(this, ea);
            return ea.Result;
        }


        public event EventHandler<CopyDataEventArgs> CBCopyData;
        public virtual CBResult OnCopyData(IupHandle sender, string cmdline, int size)
        {
            CopyDataEventArgs ea = new CopyDataEventArgs(cmdline);
            if (CBCopyData != null)
                CBCopyData(this, ea);
            return ea.Result;
        }



        EventHandler<DropFilesEventArgs> _cbDropFiles;
        protected virtual CBResult OnDropFiles(IupHandle sender, string filename, int index, int x, int y) {
            DropFilesEventArgs ea = new DropFilesEventArgs(filename, index, x, y);
            if (_cbDropFiles != null)
                _cbDropFiles(this, ea);
            return ea.Result;
        }

        public event EventHandler<DropFilesEventArgs> CBDropFiles
        {
            add
            {

                if (_cbDropFiles == null)
                    Handle.SetCallback("DROPFILES_CB", new CBDropFiles((h, fname,index,x, y) => { return OnDropFiles(h,fname,index,x,y); }));

                _cbDropFiles += value;

            }

            remove
            {
                _cbDropFiles -= value;
                if (_cbDropFiles == null)
                    Handle.SetCallback("DROPFILES_CB", null);
            }
        }


        public event EventHandler<PointEventArgs> CBMove;
        public virtual CBResult OnMove(IupHandle sender, int x,int y)
        {

            if (CBMove != null)
            {
                PointEventArgs ea = new PointEventArgs(x, y);
                CBMove(this, ea);
                return ea.Result;
            }
            
            return CBResult.Default;
        }

        public event EventHandler<SizeEventArgs> CBResize;
        public virtual CBResult OnResize(IupHandle sender, int w, int h)
        {
            SizeEventArgs ea = new SizeEventArgs(w, h);
            if (CBResize != null)
                CBResize(this, ea);
            return ea.Result;
        }


        public event EventHandler<ShowEventArgs> CBShow;

        private CBResult _internalOnShow(IupHandle sender, ShowState state)
        {
            // Keep track of visible dialogs.
            // we do this function to keep overriding the logic here from happning.
            if (state == ShowState.Show)
                _visibleDialogs.Add(this);
            else if (state == ShowState.Hide && _visibleDialogs.Contains(this))
                _visibleDialogs.Remove(this);

            // finally call the real OnShow function
            return OnShow(sender, state);
        }

        public virtual CBResult OnShow(IupHandle sender, ShowState state)
        {
            ShowEventArgs ea = new ShowEventArgs(state);
            if (CBShow != null)
                CBShow(this, ea);
            return ea.Result;
        }



        public event EventHandler<TrayClickEventArgs> CBTrayClick;
        private CBResult OnTrayClick(IupHandle h, int butidx, bool pressed, bool dclick)
        {
            
            MouseButton btn=(MouseButton)'0'+butidx;
            TrayClickEventArgs ea = new TrayClickEventArgs(btn, pressed, dclick);
            if (CBTrayClick != null)
                CBTrayClick(this, ea);
            return ea.Result;
        }

        #endregion

    }
}

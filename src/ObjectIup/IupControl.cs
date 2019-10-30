using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Tecgraf.ObjectIup
{
    public enum Expand
    {
        No,
        Yes,
        Vertical,
        Horizontal,
        HorizontalFree,
        VerticalFree
    }

   

    public class IupControl:IupObject
    {

        public IupControl(IupComposite parent,IupHandle handle)
            : base(handle)
        {
            if (parent != null)
                parent.Append(this);
        }

        
        protected override void Init(IupHandle handle)
        {
            base.Init(handle);

            //log raw objects thru LDESTROY_CB
            Handle.SetCallback("LDESTROY_CB", new CBDefault(OnInternalDestroyCallback));
            Handle.SetCallback("MAP_CB", new CBDefault(OnMap));
            Handle.SetCallback("UNMAP_CB", new CBDefault(OnUnmap));
            Handle.SetCallback("DESTROY_CB",new CBDefault(OnDestroy));
            Handle.SetCallback("GETFOCUS_CB",new CBDefault(OnGetFocus));
            Handle.SetCallback("KILLFOCUS_CB",new CBDefault(OnKillFocus));
            Handle.SetCallback("ENTERWINDOW_CB",new CBDefault(OnEnterWindow));
            Handle.SetCallback("LEAVEWINDOW_CB",new CBDefault(OnLeaveWindow));
            Handle.SetCallback("K_ANY",new CBKAny(OnKey));
            Handle.SetCallback("HELP_CB", new CBDefault(OnHelp));
        }
        /// <summary>
        /// Called on event from IUP that control is destroyed, unlog our raw ptr. to debug memory management.
        /// </summary>
        protected virtual CBResult OnInternalDestroyCallback(IupHandle sender)
        {
            UnlogRawObject();
            _handle = null;
            return CBResult.Default;
        }

        public virtual void Show()
        {
            Handle.Show();
        }

        public virtual void Hide()
        {
            Handle.Hide();
        }

        public virtual Size Size
        {
            get
            {
                int w, h;
                Handle.GetIntInt("SIZE", out w, out h);
                return new Size(w, h);
            }
            set
            {
                Handle.SetStrAttribute("SIZE", Format.Size(value));
            }
        }

        public virtual Size PixelSize
        {
            get
            {
                int w, h;
                Handle.GetIntInt("RASTERSIZE", out w, out h);
                return new Size(w, h);
            }
            set
            {
                Handle.SetStrAttribute("RASTERSIZE", Format.Size(value));
            }
        }

        public virtual Expand Expand
        {
            get
            {
                return AttToEnum<Expand>(this["EXPAND"],
                    "HORIZONTAL",Expand.Horizontal,"VERTICAL",Expand.Vertical,
                    "YES",Expand.Yes,"NO",Expand.No,
                    "HORIZONTALFREE",Expand.HorizontalFree,"VERTICALFREE",Expand.VerticalFree);
            }
            set {
                Handle.SetStrAttribute("EXPAND",EnumToAtt(value,
                    "HORIZONTAL",Expand.Horizontal,"VERTICAL",Expand.Vertical,
                    "YES",Expand.Yes,"NO",Expand.No,
                    "HORIZONTALFREE",Expand.HorizontalFree,"VERTICALFREE",Expand.VerticalFree));
            }
        }


        public virtual Color BackColor
        {
            set
            {
                Handle.SetStrAttribute("BGCOLOR", Format.Color(value));
            }
            get
            {
                return Parse.Color(Handle.GetStrAttribute("BGCOLOR"));
            }
        }

        public virtual Color ForeColor
        {
            set
            {
                Handle.SetStrAttribute("FGCOLOR", Format.Color(value));
            }
            get
            {
                return Parse.Color(Handle.GetStrAttribute("FGCOLOR"));
            }
        }

        public virtual string Font
        {
            get
            {
                return Handle.GetStrAttribute("FONT");
            }
            set
            {
                Handle.SetStrAttribute("FONT", value);
            }
        }


        public bool Active
        {
            get
            {
                return GetBool("ACTIVE");
            }
            set
            {
                SetBool("ACTIVE", value, "YES", "NO");
            }
        }


        public Point ScreenPosition
        {
            get
            {
                return GetPoint("SCREENPOSITION");
            }
        }

        public Point Position
        {
            get
            {
                return GetPoint("POSITION");
            }
        }


        #region EVENTS

        public event EventHandler<IupEventArgs> CBMap;
        protected virtual CBResult OnMap(IupHandle sender)
        {
            IupEventArgs ea = new IupEventArgs();
            if (CBMap != null)
                CBMap(this, ea);
            return ea.Result;
        }



        public event EventHandler<IupEventArgs> CBUnmap;
        protected virtual CBResult OnUnmap(IupHandle sender)
        {
            IupEventArgs ea = new IupEventArgs();
            if (CBUnmap != null)
                CBUnmap(this, ea);
            return ea.Result;
        }


        public event EventHandler<IupEventArgs> CBHelp;
        protected CBResult OnHelp(IupHandle sender)
        {
            IupEventArgs ea = new IupEventArgs();
            if (CBHelp != null)
                CBHelp(this, ea);
            return ea.Result;
        }

        public event EventHandler<KeyEventArgs> CBKey;
        protected CBResult OnKey(IupHandle sender, Key key)
        {
            KeyEventArgs ea = new KeyEventArgs(key);
            if (CBKey != null)
                CBKey(this, ea);
            return ea.Result;
        }

        public event EventHandler<IupEventArgs> CBLeaveWindow;
        protected CBResult OnLeaveWindow(IupHandle sender)
        {
            IupEventArgs ea = new IupEventArgs();
            if (CBLeaveWindow != null)
                CBLeaveWindow(this, ea);
            return ea.Result;
        }

        public event EventHandler<IupEventArgs> CBEnterWindow;
        protected CBResult OnEnterWindow(IupHandle sender)
        {
            IupEventArgs ea = new IupEventArgs();
            if (CBEnterWindow != null)
                CBEnterWindow(this, ea);
            return ea.Result;
        }


        public event EventHandler<IupEventArgs> CBKillFocus;
        protected CBResult OnKillFocus(IupHandle sender)
        {
            IupEventArgs ea = new IupEventArgs();
            if (CBKillFocus != null)
                CBKillFocus(this, ea);
            return ea.Result;
        }

        public event EventHandler<IupEventArgs> CBGetFocus;
        protected CBResult OnGetFocus(IupHandle sender)
        {
            IupEventArgs ea = new IupEventArgs();
            if (CBGetFocus != null)
                CBGetFocus(this, ea);
            return ea.Result;
        }

        public event EventHandler<IupEventArgs> CBDestroy;
        protected CBResult OnDestroy(IupHandle sender)
        {
            IupEventArgs ea = new IupEventArgs();
            if (CBDestroy != null)
                CBDestroy(this, ea);
            return ea.Result;
        }





        #endregion


    }
}

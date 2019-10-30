using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Tecgraf.ObjectIup
{

    public enum Alignment
    {
        Center = 0,
        Top = 1,
        Left = 2,
        Right = 4,
        Bottom = 8,
        TopLeft = Top | Left,
        TopRight = Top | Right,
        BottomLeft = Bottom | Left,
        BottomRight = Bottom | Right
    }

    public enum ImagePosition
    {
        Left,
        Right,
        Top,
        Bottom
    }


    public class Button:IupControl
    {

        // store local resources to avoid garbage collection
        private static Glyph _glyph = null; 
        private static Glyph _glyphInactive = null;
        private static Glyph _glyphPress = null;

        public Button(IupComposite parent, string title)
            : base(parent, Iup.Button(title))
        {
            Handle.SetCallback("ACTION", new CBDefault((h) => { return OnClick(h); }));
            Handle.SetCallback("BUTTON_CB", new CBButton((h,btn,down,x,y,status)=> { return OnMouseUpDown(h,btn,down,x,y,status); }));
        }

        


        public virtual Alignment Alignment
        {
            set
            {
                string v=EnumToAtt<Alignment>(value,
                    "ACENTER:ACENTER",Alignment.Center,
                    "ACENTER:ATOP",Alignment.Top,
                    "ALEFT:ACENTER",Alignment.Left,
                    "ARIGHT:ACENTER",Alignment.Right,
                    "ACENTER:ABOTTOM",Alignment.Bottom,
                    "ALEFT:ATOP",Alignment.TopLeft,
                    "ARIGHT:ATOP",Alignment.TopRight,
                    "ALEFT:ABOTTOM",Alignment.BottomLeft,
                    "ARIGHT:ABOTTOM",Alignment.BottomRight);
                Handle.SetStrAttribute("ALIGNMENT", v);
            }
        } //TODO: get


        public virtual bool CanFocus
        {
            get
            {
                return GetBool("CANFOCUS");
            }
            set
            {
                SetBool("CANFOCUS", value,"YES","NO");
            }
        }

        public virtual bool Flat
        {
            get
            {
                return GetBool("FLAT");
            }
            set
            {
                SetBool("FLAT", value, "YES", "NO");
            }
        }



        

        public virtual Glyph Glyph
        {
            get
            {
                return _glyph;
            }
            set
            {
                _glyph = value;
                Handle.SetAttributeHandle("IMAGE",value==null ? null:value.Handle);
            }
        }



        

        public virtual Glyph GlyphInactive
        {
            get
            {
                return _glyphInactive;
            }
            set
            {
                _glyphInactive = value;
                Handle.SetAttributeHandle("IMINACTIVE", value == null ? null : value.Handle);
            }
        }


        

        public virtual Glyph GlyphPress
        {
            get
            {
                return _glyphPress;
            }
            set
            {
                _glyphPress = value;
                Handle.SetAttributeHandle("IMPRESS", value==null ? null:value.Handle);
            }
        }

        public virtual ImagePosition ImagePosition
        {
            get
            {
                return AttToEnum<ImagePosition>(Handle.GetStrAttribute("IMAGEPOSITION"), "LEFT", ImagePosition.Left, "RIGHT", ImagePosition.Right, "TOP", ImagePosition.Top, "BOTTOM", ImagePosition.Bottom);
            }
            set
            {
                Handle.SetStrAttribute("IMAGEPOSITION",EnumToAtt<ImagePosition>(value, "LEFT", ImagePosition.Left, "RIGHT", ImagePosition.Right, "TOP", ImagePosition.Top, "BOTTOM", ImagePosition.Bottom));
            }
        }

        public virtual Size Padding
        {
            get
            {
                return base.GetSize("PADDING");
            }
            set
            {
                Handle.SetStrAttribute("PADDING", Format.Size(value));
            }
        }

        public virtual int Spacing
        {
            get
            {
                return Handle.GetInt("SPACING");
            }
            set
            {
                Handle.SetInt("SPACING", value);
            }
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



        #region CALLBACKS



        protected override CBResult OnInternalDestroyCallback(IupHandle sender)
        {
            // be nice to garbage collector
            _glyph = null;
            _glyphInactive = null;
            _glyphPress = null;
            return base.OnInternalDestroyCallback(sender);
        }



        public event EventHandler<IupEventArgs> CBClick;
        protected virtual CBResult OnClick(IupHandle sender)
        {
            IupEventArgs ea=new IupEventArgs();
            if (CBClick != null)
                CBClick(this,ea);
            return ea.Result;
        }


        public event EventHandler<MouseEventArgs> CBMouseDown;
        public event EventHandler<MouseEventArgs> CBMouseUp;
        protected CBResult OnMouseUpDown(IupHandle h, MouseButton btn, bool down, int x, int y, ModStatus status)
        {
            MouseEventArgs ea = new MouseEventArgs(btn,x,y,status);
            if (down && CBMouseDown != null)
                CBMouseDown(this, ea);
            else if(!down && CBMouseUp!=null)
                CBMouseUp(this, ea);
            return ea.Result;
        }
        

        #endregion

    }
}

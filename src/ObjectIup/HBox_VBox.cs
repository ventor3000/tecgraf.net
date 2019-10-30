using System.Drawing;
using System.Globalization;

namespace Tecgraf.ObjectIup
{

    public enum VAlign
    {
        Top,
        Center,
        Bottom
    }

    public enum HAlign
    {
        Left,
        Center,
        Right
    }
    

    public class InternalVHBox:IupComposite
    {

        internal InternalVHBox(IupComposite parent, IupHandle handle)
            : base(parent, handle)
        {

        }


        public int Gap
        {
            get
            {
                return Handle.GetInt("NCGAP");
            }
            set
            {
                Handle.SetInt("NCGAP", value);
            }
        }

        public int PixelGap
        {
            get
            {
                return Handle.GetInt("NGAP");
            }
            set
            {
                Handle.SetInt("NGAP", value);
            }
        }


        public bool Homogeneous
        {
            get
            {
                return GetBool("HOMOGENEOUS");
            }
            set
            {
                Handle.SetStrAttribute("HOMOGENEOUS", value ? "YES" : "NO");
            }
        }


        public Size Margin {
            get {
                int w,h;
                Handle.GetIntInt("CMARGIN",out w,out h);
                return new Size(w,h);
            }

            set {
                Handle.SetStrAttribute("CMARGIN", Format.Size(value));
            }
        }

        public Size PixelMargin
        {
            get
            {
                int w, h;
                Handle.GetIntInt("MARGIN", out w, out h);
                return new Size(w, h);
            }

            set
            {
                Handle.SetStrAttribute("MARGIN", Format.Size(value));
            }
        }

        
    }

    public class HBox : InternalVHBox
    {

         public HBox(IupComposite parent)
            : base(parent, Iup.Hbox())
        {

        }

        public VAlign Align
        {
            get
            {
                return AttToEnum<VAlign>(Handle.GetStrAttribute("ALIGNMENT"), "ATOP", VAlign.Top, "ABOTTOM", VAlign.Bottom, "ACENTER", VAlign.Center);
            }

            set
            {
                Handle.SetStrAttribute("ALIGNMENT", EnumToAtt(value, "ATOP", VAlign.Top, "ABOTTOM", VAlign.Bottom, "ACENTER", VAlign.Center));
            }
        }
    }


    public class VBox : InternalVHBox
    {

        public VBox(IupComposite parent)
            : base(parent, Iup.Vbox())
        {

        }

        public HAlign Align
        {
            get
            {
                return AttToEnum<HAlign>(Handle.GetStrAttribute("ALIGNMENT"), "ALEFT", HAlign.Left, "ARIGHT", HAlign.Right, "ACENTER", HAlign.Center);
            }

            set
            {
                Handle.SetStrAttribute("ALIGNMENT", EnumToAtt(value, "ALEFT", HAlign.Left , "ARIGHT", HAlign.Right, "ACENTER", HAlign.Center));
            }
        }
    }
}



using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Tecgraf.ObjectIup
{
    /// <summary>
    /// The draw area internally wraps an IUP canvas object. The name was changed to avoid collisions with tecgraf CD library, and Coral.Paint library.
    /// </summary>
    public class DrawArea:IupControl
    {


        public DrawArea(IupHandle native)
            : base(null, native)
        {

        }

        public DrawArea(IupComposite parent)
            : base(parent, Iup.Canvas())
        {

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

        public virtual bool CanFocus
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

        //HINT: Skipped CARIO_CR attribute, GTK only



        public virtual Rectangle ClipRect
        {
            get
            {
                string strrect = Handle.GetStrAttribute("CLIPRECT");
                if (strrect != null)
                {
                    string[] entr = strrect.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (entr.Length == 4)
                    {
                        int x1 = Parse.Int(entr[0]), y1 = Parse.Int(entr[1]), x2 = Parse.Int(entr[2]), y2 = Parse.Int(entr[3]);
                        return new Rectangle(x1, y1, x2 - x1 + 1, y2 - y1 + 1);
                    }
                }

                throw new Exception("Invalid ClipRect rectangle");
            }
        }



        #region CALLBACKS

        CBAction_Canvas _onpaint;
        public virtual CBResult OnPaint(IupHandle sender, float posx, float posy) { return _onpaint == null ? CBResult.Default : _onpaint(sender, posx, posy); }

        public event CBAction_Canvas CBPaint
        {
            add
            {

                if (_onpaint == null)
                    Handle.SetCallback("ACTION", new CBAction_Canvas((h, x, y) => { return OnPaint(h,x,y); }));

                _onpaint += value;

            }

            remove
            {
                _onpaint -= value;
                if (_onpaint == null)
                    Handle.SetCallback("ACTION", null);
            }
        }


        #endregion


    }
}

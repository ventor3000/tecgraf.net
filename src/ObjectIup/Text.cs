using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tecgraf.ObjectIup
{

    //TODO: finish!
    
    public class Text:IupControl
    {
        public Text(IupComposite parent)
            : base(parent, Iup.Text())
        {

        }

        public string Value
        {
            get
            {
                return Handle.GetStrAttribute("VALUE");
            }
            set
            {
                Handle.SetStrAttribute("VALUE", value ?? "");
            }
        }
    }
}

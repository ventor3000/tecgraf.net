using System;
using System.Collections.Generic;
using System.Text;

namespace Tecgraf.ObjectIup
{
    /// <summary>
    /// Base class for controls that can contain other controls.
    /// </summary>
    public class IupComposite:IupControl
    {
        public IupComposite(IupComposite parent,IupHandle handle)
            : base(parent,handle)
        {

        }


        public void Append(IupControl child)
        {
            if(Handle!=null)
                Handle.Append(child.Handle);
        }
        
    }
}

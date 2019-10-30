using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Tecgraf.ObjectIup
{

     public enum Cursor
    {
        None,
        Arrow,
        Busy,
        Cross,
        Hand,
        Help,
        Move,
        Pen,
        ResizeN,
        ResizeS,
        ResizeNS,
        ResizeW,
        ResizeE,
        ResizeWE,
        ResizeNE,
        ResizeSW,
        ResizeNW,
        ResizeSE,
        Text,
        /// <summary>
        /// Windows only
        /// </summary>
        AppStarting,    
        /// <summary>
        /// Windows only
        /// </summary>
        No, 
        UpArrow
     }

    public class IupObject:IDisposable
    {

        static Dictionary<IntPtr, string> rawObjects = new Dictionary<IntPtr, string>(); //TODO: dont log objects in release mode

        protected IupHandle _handle;
        private bool _disposed = false;

        protected IupObject(IupHandle handle)
        {
            Init(handle);
        }

        ~IupObject()
        {
            Dispose(false);
        }

        protected void LogRawObject()
        {
            var h = Handle;
            if (h != null)
            {
                IntPtr ch = IupHandle.GetCHandle(h);
                if (ch != IntPtr.Zero)
                {
                    rawObjects.Add(ch, h.GetClassName());
                }
            }
        }

        protected void UnlogRawObject()
        {
            var h = Handle;
            if (h != null)
            {
                IntPtr ch=IupHandle.GetCHandle(h);
                if (ch != IntPtr.Zero)
                {
                    rawObjects.Remove(ch);
                }
            }
        }

        public IupHandle Handle
        {
            get
            {
                return _handle;
            }
        }

        protected virtual void Init(IupHandle handle)
        {
            
            this._handle = handle;
            LogRawObject();
        }

        public string this[string attname] {
            get {
                if(Handle==null)
                    return null;
                return Handle.GetStrAttribute(attname);
            }
        }


    

        protected virtual void Dispose(bool disposing)
        {

            if (!_disposed)
            {
                _disposed = true;                

                if (disposing)
                {
                    // Dispose managed resources.
                    DisposeManaged();
                }

                // There are no unmanaged resources to release, but
                // if we add them, they need to be released here.

                DisposeUnmanaged();
            }


        }


        protected virtual void DisposeManaged()
        {
            
        }

        protected virtual void DisposeUnmanaged()
        {
            if (Handle != null)
            {
                _handle.Destroy();
                _handle = null;
            }

        }


        public override string ToString()
        {
            if (Handle == null)
                return "<<null object>>";
            else
                return Handle.GetClassName();
        }

        #region UTILS

        protected static T AttToEnum<T>(string attname, params object[] str_obj)
        {
            for (int i = 0; i < str_obj.Length; i += 2)
            {
                if (object.Equals(str_obj[i], attname))
                    return (T)str_obj[i + 1];
            }

            throw new Exception(attname + " attribute could not be mapped");
        }

        protected static string EnumToAtt<T>(T _enum, params object[] str_obj)
        {
            for (int i = 0; i < str_obj.Length; i += 2)
            {
                if (object.Equals(str_obj[i + 1], _enum))
                    return (string)str_obj[i];
            }

            throw new Exception(_enum.ToString() + " attribute could not be unmapped");
        }


        protected bool GetBool(string attname)
        {
            string s = Handle.GetStrAttribute(attname);
            if (s == "TRUE" || s == "YES" || s == "ON")
                return true;
            return false;
        }

        protected Point GetPoint(string attname)
        {
            int x, y;
            Handle.GetIntInt(attname, out x, out y);
            return new Point(x, y);
        }

        protected Size GetSize(string attname)
        {
            int x, y;
            Handle.GetIntInt(attname, out x, out y);
            return new Size(x, y);
        }

       
        protected void SetBool(string attname, bool value, string trueval, string falseval)
        {
            Handle.SetStrAttribute(attname, value ? trueval : falseval);
        }

        
            



        protected static class Format
        {

            public static string Int(int v)
            {
                return v.ToString(CultureInfo.InvariantCulture);
            }

            public static string Size(Size s)
            {
                return Format.Int(s.Width) + "x" + Format.Int(s.Height);
            }

            public static string Color(Color value)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(Int(value.R));
                sb.Append(' ');
                sb.Append(Int(value.G));
                sb.Append(' ');
                sb.Append(Int(value.B));
                return sb.ToString();
            }

            public static string Point(Point pt, string separator = ":")
            {
                return Int(pt.X) + separator + Int(pt.Y);
            }


            public static string Cursor(Cursor cursorname)
            {
                return EnumToAtt<Cursor>(cursorname,
                    "NONE", ObjectIup.Cursor.None,
                    "NULL", ObjectIup.Cursor.None,
                    "ARROW", ObjectIup.Cursor.Arrow,
                    "BUSY", ObjectIup.Cursor.Busy,
                    "CROSS", ObjectIup.Cursor.Cross,
                    "HAND", ObjectIup.Cursor.Hand,
                    "HELP", ObjectIup.Cursor.Help,
                    "MOVE", ObjectIup.Cursor.Move,
                    "PEN", ObjectIup.Cursor.Pen,
                    "RESIZE_N", ObjectIup.Cursor.ResizeN,
                    "RESIZE_S", ObjectIup.Cursor.ResizeS,
                    "RESIZE_NS", ObjectIup.Cursor.ResizeNS,
                    "RESIZE_W", ObjectIup.Cursor.ResizeW,
                    "RESIZE_E", ObjectIup.Cursor.ResizeE,
                    "RESIZE_WE", ObjectIup.Cursor.ResizeWE,
                    "RESIZE_NE", ObjectIup.Cursor.ResizeNE,
                    "RESIZE_SW", ObjectIup.Cursor.ResizeSW,
                    "RESIZE_NW", ObjectIup.Cursor.ResizeNW,
                    "RESIZE_SE", ObjectIup.Cursor.ResizeSE,
                    "TEXT", ObjectIup.Cursor.Text,
                    "APPSTARTING", ObjectIup.Cursor.AppStarting,
                    "NO", ObjectIup.Cursor.No,
                    "UPARROW", ObjectIup.Cursor.UpArrow);

            }
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected static class Parse
        {

            public static Color Color(string cs)
            {
                uint col;
                cs = cs.Trim();
                int r = 0, g = 0, b = 0;

                if (cs.StartsWith("#"))
                {
                    r = Convert.ToInt32(cs.Substring(1, 2));
                    g = Convert.ToInt32(cs.Substring(3, 2));
                    b = Convert.ToInt32(cs.Substring(5, 2));
                }
                else
                {
                    string[] rgb = cs.Split(new char[] { ' ', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                    if (rgb.Length > 0)
                        r = Int(rgb[0]);
                    if (rgb.Length > 1)
                        g = Int(rgb[1]);
                    if (rgb.Length > 2)
                        b = Int(rgb[2]);
                }

                return System.Drawing.Color.FromArgb(255, r, g, b);
            }

            public static int Int(string str)
            {
                int res;
                if (int.TryParse(str, out res))
                    return res;
                return 0;
            }

            public static Cursor Cursor(string cursorname)
            {
                return AttToEnum<Cursor>(cursorname,
                    "NONE", ObjectIup.Cursor.None,
                    "NULL", ObjectIup.Cursor.None,
                    "ARROW", ObjectIup.Cursor.Arrow,
                    "BUSY", ObjectIup.Cursor.Busy,
                    "CROSS", ObjectIup.Cursor.Cross,
                    "HAND", ObjectIup.Cursor.Hand,
                    "HELP", ObjectIup.Cursor.Help,
                    "MOVE", ObjectIup.Cursor.Move,
                    "PEN", ObjectIup.Cursor.Pen,
                    "RESIZE_N", ObjectIup.Cursor.ResizeN,
                    "RESIZE_S", ObjectIup.Cursor.ResizeS,
                    "RESIZE_NS", ObjectIup.Cursor.ResizeNS,
                    "RESIZE_W", ObjectIup.Cursor.ResizeW,
                    "RESIZE_E", ObjectIup.Cursor.ResizeE,
                    "RESIZE_WE", ObjectIup.Cursor.ResizeWE,
                    "RESIZE_NE", ObjectIup.Cursor.ResizeNE,
                    "RESIZE_SW", ObjectIup.Cursor.ResizeSW,
                    "RESIZE_NW", ObjectIup.Cursor.ResizeNW,
                    "RESIZE_SE", ObjectIup.Cursor.ResizeSE,
                    "TEXT", ObjectIup.Cursor.Text,
                    "APPSTARTING", ObjectIup.Cursor.AppStarting,
                    "NO", ObjectIup.Cursor.No,
                    "UPARROW", ObjectIup.Cursor.UpArrow);

            }
        }

        #endregion



      
    }
}

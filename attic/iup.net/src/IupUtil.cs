using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace Tecgraf
{
    public class IupUtil
    {

        /// <summary>
        /// Creates an IUP image using a System.Drawing.Bitmap
        /// </summary>
        /// <param name="bmp"></param>
        /// <returns></returns>
        public static IupHandle ImageFromBitmap(Bitmap bmp)
        {
            //TODO: try for diffrent bit depths / optimize with bitmap locking
            int w = bmp.Width, h = bmp.Height;
            if (w < 1 || h < 1)
                return null;
            IupHandle res;
            bool alpha = bmp.PixelFormat == System.Drawing.Imaging.PixelFormat.Format32bppArgb;

            if (alpha)
                res = Iup.ImageRGBA(w, h, null);
            else
                res = Iup.ImageRGB(w, h, null);

            int idx = 0;
            IntPtr pix = res.GetAttribute("WID");
            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {

                    var col = bmp.GetPixel(x, y);
                    Marshal.WriteByte(pix, idx++, col.R);
                    Marshal.WriteByte(pix, idx++, col.G);
                    Marshal.WriteByte(pix, idx++, col.B);
                    if (alpha) Marshal.WriteByte(pix, idx++, col.A);
                }
            }

            return res;
        }

        public static IupHandle ImageFromStream(Stream stream)
        {
            //uses system.drawing internally
            using (var db = System.Drawing.Bitmap.FromStream(stream) as System.Drawing.Bitmap)
            {
                if (db == null)
                    return null;
                return ImageFromBitmap(db);
            }
        }

        public static IupHandle ImageFromResource(Assembly asm, string resname)
        {
            //try to get resource with the actual name
            Stream stream = asm.GetManifestResourceStream(resname);
            if (stream == null)
            {
                //get resource with some random namspace ending with the given name
                //this is good for Visual Studio express users, where resources are auto prefixed
                string upname = "." + resname.ToUpperInvariant();
                foreach (string s in asm.GetManifestResourceNames())
                {
                    if (s.ToUpper().EndsWith(upname))
                    {
                        stream = asm.GetManifestResourceStream(s);
                    }
                }
            }

            if (stream == null)
                throw new Exception("Resource " + resname + " not found in assembly " + asm.ToString());

            IupHandle res = null;
            try
            {
                res = ImageFromStream(stream);
            }
            finally
            {
                stream.Close();
            }

            return res;
        }

        public static IupHandle ImageFromResource(string resname)
        {
            return ImageFromResource(Assembly.GetCallingAssembly(), resname);
        }

        public static IupHandle ImageFromFile(string filename)
        {
            Bitmap bmp = Bitmap.FromFile(filename) as Bitmap;
            var res = ImageFromBitmap(bmp);
            bmp.Dispose();
            return res;
        }

    }
}

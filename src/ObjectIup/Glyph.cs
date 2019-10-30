using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Tecgraf.ObjectIup
{

    public enum GlyphMode
    {
        Indexed,
        RGB,
        RGBA
    }

    public class Glyph:IupObject 
    {

        public static int GlyphsCreated = 0;




        protected override void DisposeUnmanaged()
        {
            UnlogRawObject(); //IMAGES do not work with our normal logging system depending on LDESTROY_CB
            base.DisposeUnmanaged();
            GlyphsCreated--;

            
        }

        public Glyph(int w,int h,GlyphMode mode,byte[] pixelData=null,Color[] palette=null):base(null)
        {
            Create(w, h, mode, pixelData,palette);
        }



        
        private void Create(int w, int h, GlyphMode mode, byte[] pixelData,Color[] palette)
        {
            

            switch (mode)
            {
                case GlyphMode.RGB: Init(Iup.ImageRGB(w, h, pixelData)); break;
                case GlyphMode.RGBA: Init(Iup.ImageRGBA(w, h, pixelData)); break;
                case GlyphMode.Indexed:
                default:
                    Init(Iup.Image(w, h, pixelData));

                    if (palette != null)
                    {
                        for(int i=0;i<palette.Length;i++)
                        {
                            Handle.SetStrAttribute(Format.Int(i), Format.Color(palette[i]));
                        }

                    }

                    break;
            }

        }


        public static Glyph FromFile(string filename)
        {
            Bitmap bmp = Bitmap.FromFile(filename) as Bitmap;
            if (bmp == null)
                throw new Exception("Image load error");
            return FromBitmap(bmp);
        }

        public static Glyph FromBitmap(Bitmap bmp)
        {
            PixelFormat lockFormat;
            GlyphMode mode;
            int depth = 0;

            switch (bmp.PixelFormat)
            {
                case PixelFormat.Format16bppArgb1555:  //alpha formats
                case PixelFormat.Format32bppArgb:
                case PixelFormat.Format32bppPArgb:
                case PixelFormat.Format64bppArgb:
                case PixelFormat.Format64bppPArgb:
                    lockFormat = PixelFormat.Format32bppArgb;
                    mode=GlyphMode.RGBA;
                    depth = 4;
                    break;
                case PixelFormat.Format8bppIndexed: //indexed formats
                    lockFormat = PixelFormat.Format8bppIndexed;
                    mode=GlyphMode.Indexed;
                    depth = 1;
                    break;
                default: //true color formats 24 bit / no alpha:
                    lockFormat = PixelFormat.Format24bppRgb;
                    mode=GlyphMode.RGB;
                    depth = 3;
                    break;
            }


            BitmapData bmpdata=bmp.LockBits(new Rectangle(Point.Empty, bmp.Size), ImageLockMode.ReadOnly, lockFormat);
            int w=bmp.Width,h=bmp.Height;
            byte[] pixels = new byte[w*h * depth];
            Color[] palette=null;


            if (depth == 3 || depth == 4)
            {
                for (int y = 0; y < h; y++)
                {
                    IntPtr line = bmpdata.Scan0 + bmpdata.Stride * y;

                    for (int x = 0; x < w; x++)
                    {
                        byte a, r, g, b;
                        int rgb = Marshal.ReadInt32(line, x * depth);

                        if (depth == 4)
                            a = (byte)((rgb & 0xff000000) >> 24);
                        else
                            a = 255;
                        r = (byte)((rgb & 0xff0000) >> 16);
                        g = (byte)((rgb & 0xff00) >> 8);
                        b = (byte)(rgb & 0xff);


                        int pixofs = y * w * depth + x * depth;
                        pixels[pixofs++] = r;
                        pixels[pixofs++] = g;
                        pixels[pixofs++] = b;
                        if (depth == 4)
                            pixels[pixofs++] = a;

                    }
                }
            }
            else
            { //depth =1
                for (int y = 0; y < h; y++)
                {
                    IntPtr line = bmpdata.Scan0 + bmpdata.Stride * y;
                    Marshal.Copy(line, pixels, y * w,  w);
                }

                ColorPalette pal = bmp.Palette;
                palette=new Color[pal.Entries.Length];
                for (int i = 0; i < pal.Entries.Length; i++)
                    palette[i]=pal.Entries[i];
                    

            }
            

            bmp.UnlockBits(bmpdata);
            return new Glyph(w, h, mode, pixels,palette);
        }

        public Color this[int palidx]
        {
            get
            {
                return Parse.Color(Handle.GetStrAttribute(Format.Int(palidx)));
            }
            set
            {
                Handle.SetStrAttribute(Format.Int(palidx), Format.Color(value));
            }
        }


        /// <summary>
        /// The color used for transparency. If not defined uses the BackColor of the control that contains the image.
        /// </summary>
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

        public virtual int BitsPerPixel
        {
            get
            {
                return Handle.GetInt("BPP");
            }
        }

        public virtual int Channels
        {
            get
            {
                return Handle.GetInt("CHANNELS");
            }
        }


        /// <summary>
        /// Gets the height in pixels of the glyph.
        /// </summary>
        public virtual int Height
        {
            get
            {
                return Handle.GetInt("HEIGHT");
            }
        }

        /// <summary>
        /// Gets the width in pixels of the glyph.
        /// </summary>
        public virtual int Width
        {
            get
            {
                return Handle.GetInt("WIDTH");
            }
        }


        /// <summary>
        /// Gets the size in pixels of the glyph.
        /// </summary>
        public virtual Size PixelSize
        {
            get
            {

                return new Size(Width, Height);

                //HINT: rastersize does not work althu in documentation, maybe asc scuri about this?

                /*int w, h;
                Handle.GetIntInt("RASTERSIZE", out w, out h);
                return new Size(w, h);*/
            }
        }

        public Point HotSpot
        {
            get
            {

                string test = Handle.GetStrAttribute("HOTSPOT");
                return GetPoint("HOTSPOT");
            }

            set
            {
                Handle.SetStrAttribute("HOTSPOT", Format.Point(value));
            }
        }


        public IntPtr ScanLines
        {
            get
            {
                return Handle.GetAttribute("WID");
            }
        }
    }
}

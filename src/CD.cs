using System;
using System.Runtime.InteropServices;

namespace Tecgraf
{
   
    public enum LineJoin {
        Miter,
        Bevel,
        Round
    }

    public enum LineCap
    {
        Flat,
        Square,
        Round
    }

    public enum PolyMode {
        Fill,
        OpenLines,
        ClosedLines,
        Clip,
        Bezier,
        Region,
        Path
    }

    public enum ClipMode {
        Off,
        Area,
        Polygon,
        Region
    }

    public enum PathOp {
        New,
        MoveTo,
        LineTo,
        Arc,
        CurveTo,
        Close,
        Fill,
        Stroke,
        FillStroke,
        Clip
    }



    public static class CD
    {
        public static string Version { get { return PtrToStr(NativeCD.cdVersion()); } }
       
        //contexts
        public static IntPtr ContextPDF { get { return NativeCDPDF.cdContextPDF(); } }
        public static IntPtr ContextDBuffer { get { return NativeCD.cdContextDBuffer(); } }
        public static IntPtr ContextDBufferRGB { get { return NativeCD.cdContextDBufferRGB(); } }
        public static IntPtr ContextIup { get { return NativeIUPCD.cdContextIup(); } }

        internal static string PtrToStr(IntPtr ps)
        {
            if (ps == IntPtr.Zero)
                return null;
            return Marshal.PtrToStringAnsi(ps);
        }
    }

    public class Canvas:IDisposable
    {
        const int CD_QUERY = -1;
        public readonly IntPtr Handle;
        private bool disposed = false;
        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called.
            if (!this.disposed)
            {
                // If disposing equals true, dispose all managed 
                // and unmanaged resources.
                if (disposing)
                {
                    // Dispose managed resources.
                }

                // Call the appropriate methods to clean up 
                // unmanaged resources here.
                // If disposing is false, 
                // only the following code is executed.
                Kill();
                
            }
            disposed = true;
        }

        #region INITIALIZATION

        public Canvas(IntPtr context, IntPtr data) {
            Handle = NativeCD.cdCreateCanvasPtr(context, data);
            if(Handle==IntPtr.Zero)
                throw new Exception("Failed to create canvas. Control mapped?");
        }

        public Canvas(IntPtr context, string data) { 
            Handle = NativeCD.cdCreateCanvasStr(context, data);
            if (Handle == IntPtr.Zero)
                throw new Exception("Failed to create canvas. Control mapped?");
        }

        public void Activate() { NativeCD.cdCanvasActivate(Handle); }

        #endregion

        #region LINES

        public void Line(int x1, int y1, int x2, int y2) { NativeCD.cdCanvasLine(Handle, x1, y1, x2, y2); }
        public void Line(double x1, double y1, double x2, double y2) { NativeCD.cdfCanvasLine(Handle, x1, y1, x2, y2); }
        public void LineWorld(double x1, double y1, double x2, double y2) { NativeCD.wdCanvasLine(Handle, x1, y1, x2, y2); }

        public void Arc(int xc, int yc, int w, int h, double angle1, double angle2) { NativeCD.cdCanvasArc(Handle, xc, yc, w, h, angle1, angle2); }
        public void Arc(double xc, double yc, double w, double h, double angle1, double angle2) { NativeCD.cdfCanvasArc(Handle, xc, yc, w, h, angle1, angle2); }
        public void ArcWorld(double xc, double yc, double w, double h, double angle1, double angle2) { NativeCD.wdCanvasArc(Handle, xc, yc, w, h, angle1, angle2); }

        public void Rect(int xmin, int xmax, int ymin, int ymax) { NativeCD.cdCanvasRect(Handle, xmin, xmax, ymin, ymax); }
        public void Rect(double xmin, double xmax, double ymin, double ymax) { NativeCD.cdfCanvasRect(Handle, xmin, xmax, ymin, ymax); }
        public void RectWorld(double xmin, double xmax, double ymin, double ymax) { NativeCD.wdCanvasRect(Handle, xmin, xmax, ymin, ymax); }

        #endregion


        public void Box(int xmin, int xmax, int ymin, int ymax) { NativeCD.cdCanvasBox(Handle, xmin, xmax, ymin, ymax); }
        public void Box(double xmin, double xmax, double ymin, double ymax) { NativeCD.cdfCanvasBox(Handle, xmin, xmax, ymin, ymax); }
        public void BoxWorld(double xmin, double xmax, double ymin, double ymax) { NativeCD.wdCanvasBox(Handle, xmin, xmax, ymin, ymax); }

        
        
        public int Background
        {
            get { return NativeCD.cdCanvasBackground(Handle, CD_QUERY); }
            set { NativeCD.cdCanvasBackground(Handle, value); }
        }

        public int Foreground
        {
            get { return NativeCD.cdCanvasForeground(Handle, CD_QUERY); }
            set { NativeCD.cdCanvasForeground(Handle, value); }
        }

        public void Clear() { NativeCD.cdCanvasClear(Handle); }

        public void Flush() {NativeCD.cdCanvasFlush(Handle);}

        
        

        public void Kill()
        {
            NativeCD.cdKillCanvas(Handle);            
        }


        public int  LineWidth { get { return NativeCD.cdCanvasLineWidth(Handle, CD_QUERY); } set { NativeCD.cdCanvasLineWidth(Handle, value); } }
        public double LineWidthWorld { get { return NativeCD.wdCanvasLineWidth(Handle, CD_QUERY); } set { NativeCD.wdCanvasLineWidth(Handle, value); } }

        public LineJoin LineJoin { get { return (LineJoin)NativeCD.cdCanvasLineJoin(Handle, CD_QUERY); } set { NativeCD.cdCanvasLineJoin(Handle, (int)value); } }
        public LineCap LineCap { get { return (LineCap)NativeCD.cdCanvasLineCap(Handle, CD_QUERY); } set { NativeCD.cdCanvasLineCap(Handle, (int)value); } }

        public void Begin(PolyMode mode) { NativeCD.cdCanvasBegin(Handle, (int)mode); }
        public void Vertex(int x, int y) { NativeCD.cdCanvasVertex(Handle, x, y); }
        public void Vertex(double x, double y) { NativeCD.cdfCanvasVertex(Handle, x, y); }
        public void VertexWorld(double x, double y) { NativeCD.wdCanvasVertex(Handle, x, y); }
        public void End() { NativeCD.cdCanvasEnd(Handle); }
        public void PathSet(PathOp op) { NativeCD.cdCanvasPathSet(Handle, (int)op); }

        
        public ClipMode Clip
        {
            get { return (ClipMode)NativeCD.cdCanvasClip(Handle, CD_QUERY); }
            set { NativeCD.cdCanvasClip(Handle, (int)value); }
        }
        

        public void GetRegionBox(out int xmin,out int xmax,out int ymin,out int ymax) {NativeCD.cdCanvasGetRegionBox(Handle,out xmin,out xmax,out ymin,out ymax);}
        public void GetRegionBoxWorld(out double xmin,out double xmax,out double ymin,out double ymax) {NativeCD.wdCanvasGetRegionBox(Handle,out xmin,out xmax,out ymin,out ymax); }


        #region CONTROL
        public void SetAttribute(string name, string data) { NativeCD.cdCanvasSetAttribute(Handle, name, data);}
        public string GetAttribute(string name) { return CD.PtrToStr(NativeCD.cdCanvasGetAttribute(Handle, name)); }
        #endregion

        #region COORDINATE_SYSTEMS
        
        public void GetSize(out int width,out int height,out double width_mm,out double height_mm) {NativeCD.cdCanvasGetSize(Handle,out width,out height,out width_mm,out height_mm);}
        public int UpdateYAxis(out int y) {return NativeCD.cdCanvasUpdateYAxis(Handle,out y);}
        public double UpdateYAxis(out double y) {return NativeCD.cdfCanvasUpdateYAxis(Handle,out y);}
        public int InvertYAxis(int y) {return NativeCD.cdCanvasInvertYAxis(Handle,y);}
        public double InvertYAxis(double y) {return NativeCD.cdfCanvasInvertYAxis(Handle,y);}

        public void Origin(int x,int y) {NativeCD.cdCanvasOrigin(Handle,x,y);}
        public void Origin(double x,double y) {NativeCD.cdfCanvasOrigin(Handle,x,y);}
        public void GetOrigin(out int x,out int y) {NativeCD.cdCanvasGetOrigin(Handle,out x,out y);}
        public void GetOrigin(out double x,out double y) {NativeCD.cdfCanvasGetOrigin(Handle,out x,out y);}

        /*public Transform2 Transform
        {
            get
            {
                double[] m = new double[6];
                IntPtr raw=NativeCD.cdCanvasGetTransform(Handle);
                if (raw == IntPtr.Zero)
                    return Transform2.Identity;
                Marshal.Copy(raw, m, 0, 6);
                return new Transform2(m[0], m[1], m[2], m[3], m[4], m[5]);
            }

            set
            {
                if (value == null)
                    value = Transform2.Identity;
                double[] m = new double[] { value.ax, value.ay, value.bx, value.by, value.tx, value.ty };
                NativeCD.cdCanvasTransform(Handle, ref m[0]);
            }
        }*/

        public void MM2Pixel(int mm_dx, int mm_dy, out int dx, out int dy) { NativeCD.cdCanvasMM2Pixel(Handle, mm_dx, mm_dy, out dx, out dy); }
        public void MM2Pixel(double mm_dx, double mm_dy, out double dx, out double dy) { NativeCD.cdfCanvasMM2Pixel(Handle, mm_dx, mm_dy, out dx, out dy); }
        public void PixelToMM(int dx, int dy, out double mm_dx, out double mm_dy) { NativeCD.cdCanvasPixel2MM(Handle, dx, dy, out mm_dx, out mm_dy); }
        public void PixelToMM(double dx, double dy, out double mm_dx, out double mm_dy) { NativeCD.cdfCanvasPixel2MM(Handle, dx, dy, out mm_dx, out mm_dy); }

        /*public void TransformMultiply(Transform2 t)
        {
            if (t == null) return;
            double[] m = new double[] { t.ax, t.ay, t.bx, t.by, t.tx, t.ty };
            NativeCD.cdCanvasTransformMultiply(Handle, ref m[0]);
        }*/

        public void TransformRotate(double angle) {NativeCD.cdCanvasTransformRotate(Handle, angle);}
        public void TransformScale(double sx,double sy) { NativeCD.cdCanvasTransformScale(Handle,sx,sy); }
        public void TransformTranslate(double dx, double dy) { NativeCD.cdCanvasTransformTranslate(Handle, dx, dy); }
        public void TransformPoint(int x,int y,out int tx,out int ty) {NativeCD.cdCanvasTransformPoint(Handle,x,y,out tx,out ty);}
        public void TransformPoint(double x, double y, out double tx, out double ty) { NativeCD.cdfCanvasTransformPoint(Handle, x, y, out tx, out ty); }

        
        #endregion


        #region VECTOR_TEXT
        public void VectorText(int x, int y, string txt) { NativeCD.cdCanvasVectorText(Handle, x, y, txt); }
        public int VectorCharSize
        {
            get
            {
                return NativeCD.cdCanvasVectorCharSize(Handle, CD_QUERY);
            }
            set
            {
                NativeCD.cdCanvasVectorCharSize(Handle, value);
            }
        }

        
        #endregion


    }
}

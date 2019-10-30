using System;
using System.Text;
using System.Runtime.InteropServices;

internal static class NativeCD{

  static DynamicLinker dynlink = new DynamicLinker("cd");

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate IntPtr cdCreateCanvasPtrDelegate(IntPtr ctx,IntPtr data);
  internal static cdCreateCanvasPtrDelegate cdCreateCanvasPtr = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("cdCreateCanvas"),typeof(cdCreateCanvasPtrDelegate)) as cdCreateCanvasPtrDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate IntPtr cdCreateCanvasStrDelegate(IntPtr ctx,string data);
  internal static cdCreateCanvasStrDelegate cdCreateCanvasStr = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("cdCreateCanvas"),typeof(cdCreateCanvasStrDelegate)) as cdCreateCanvasStrDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate IntPtr cdContextDXFDelegate();
  internal static cdContextDXFDelegate cdContextDXF = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("cdContextDXF"),typeof(cdContextDXFDelegate)) as cdContextDXFDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate IntPtr cdVersionDelegate();
  internal static cdVersionDelegate cdVersion = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("cdVersion"),typeof(cdVersionDelegate)) as cdVersionDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate int cdCanvasActivateDelegate(IntPtr canvas);
  internal static cdCanvasActivateDelegate cdCanvasActivate = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("cdCanvasActivate"),typeof(cdCanvasActivateDelegate)) as cdCanvasActivateDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate void cdCanvasLineDelegate(IntPtr canvas,int x1,int y1,int x2,int y2);
  internal static cdCanvasLineDelegate cdCanvasLine = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("cdCanvasLine"),typeof(cdCanvasLineDelegate)) as cdCanvasLineDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate void cdfCanvasLineDelegate(IntPtr canvas,double x1,double y1,double x2,double y2);
  internal static cdfCanvasLineDelegate cdfCanvasLine = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("cdfCanvasLine"),typeof(cdfCanvasLineDelegate)) as cdfCanvasLineDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate void wdCanvasLineDelegate(IntPtr canvas,double x1,double y1,double x2,double y2);
  internal static wdCanvasLineDelegate wdCanvasLine = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("wdCanvasLine"),typeof(wdCanvasLineDelegate)) as wdCanvasLineDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate void cdCanvasArcDelegate(IntPtr canvas, int xc, int yc, int w, int h, double angle1, double angle2);
  internal static cdCanvasArcDelegate cdCanvasArc = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("cdCanvasArc"),typeof(cdCanvasArcDelegate)) as cdCanvasArcDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate void cdfCanvasArcDelegate(IntPtr canvas, double xc, double yc, double w, double h, double angle1, double angle2);
  internal static cdfCanvasArcDelegate cdfCanvasArc = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("cdfCanvasArc"),typeof(cdfCanvasArcDelegate)) as cdfCanvasArcDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate void wdCanvasArcDelegate(IntPtr canvas, double xc, double yc, double w, double h, double angle1, double angle2);
  internal static wdCanvasArcDelegate wdCanvasArc = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("wdCanvasArc"),typeof(wdCanvasArcDelegate)) as wdCanvasArcDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate void cdCanvasRectDelegate(IntPtr canvas, int xmin, int xmax, int ymin, int ymax);
  internal static cdCanvasRectDelegate cdCanvasRect = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("cdCanvasRect"),typeof(cdCanvasRectDelegate)) as cdCanvasRectDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate void cdfCanvasRectDelegate(IntPtr canvas, double xmin, double xmax, double ymin, double ymax);
  internal static cdfCanvasRectDelegate cdfCanvasRect = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("cdfCanvasRect"),typeof(cdfCanvasRectDelegate)) as cdfCanvasRectDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate void wdCanvasRectDelegate(IntPtr canvas, double xmin, double xmax, double ymin, double ymax);
  internal static wdCanvasRectDelegate wdCanvasRect = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("wdCanvasRect"),typeof(wdCanvasRectDelegate)) as wdCanvasRectDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate void cdCanvasBoxDelegate(IntPtr canvas, int xmin, int xmax, int ymin, int ymax);
  internal static cdCanvasBoxDelegate cdCanvasBox = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("cdCanvasBox"),typeof(cdCanvasBoxDelegate)) as cdCanvasBoxDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate void cdfCanvasBoxDelegate(IntPtr canvas, double xmin, double xmax, double ymin, double ymax);
  internal static cdfCanvasBoxDelegate cdfCanvasBox = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("cdfCanvasBox"),typeof(cdfCanvasBoxDelegate)) as cdfCanvasBoxDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate void wdCanvasBoxDelegate(IntPtr canvas, double xmin, double xmax, double ymin, double ymax);
  internal static wdCanvasBoxDelegate wdCanvasBox = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("wdCanvasBox"),typeof(wdCanvasBoxDelegate)) as wdCanvasBoxDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate void cdCanvasGetSizeDelegate(IntPtr canvas, out int width, out int height, out double width_mm, out double height_mm);
  internal static cdCanvasGetSizeDelegate cdCanvasGetSize = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("cdCanvasGetSize"),typeof(cdCanvasGetSizeDelegate)) as cdCanvasGetSizeDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate int cdCanvasUpdateYAxisDelegate(IntPtr canvas, out int y);
  internal static cdCanvasUpdateYAxisDelegate cdCanvasUpdateYAxis = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("cdCanvasUpdateYAxis"),typeof(cdCanvasUpdateYAxisDelegate)) as cdCanvasUpdateYAxisDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate double cdfCanvasUpdateYAxisDelegate(IntPtr canvas, out double y);
  internal static cdfCanvasUpdateYAxisDelegate cdfCanvasUpdateYAxis = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("cdfCanvasUpdateYAxis"),typeof(cdfCanvasUpdateYAxisDelegate)) as cdfCanvasUpdateYAxisDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate int cdCanvasInvertYAxisDelegate(IntPtr canvas, int y);
  internal static cdCanvasInvertYAxisDelegate cdCanvasInvertYAxis = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("cdCanvasInvertYAxis"),typeof(cdCanvasInvertYAxisDelegate)) as cdCanvasInvertYAxisDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate double cdfCanvasInvertYAxisDelegate(IntPtr canvas, double y);
  internal static cdfCanvasInvertYAxisDelegate cdfCanvasInvertYAxis = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("cdfCanvasInvertYAxis"),typeof(cdfCanvasInvertYAxisDelegate)) as cdfCanvasInvertYAxisDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate void cdCanvasMM2PixelDelegate(IntPtr canvas, double mm_dx, double mm_dy, out int dx, out int dy);
  internal static cdCanvasMM2PixelDelegate cdCanvasMM2Pixel = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("cdCanvasMM2Pixel"),typeof(cdCanvasMM2PixelDelegate)) as cdCanvasMM2PixelDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate void cdCanvasPixel2MMDelegate(IntPtr canvas, int dx, int dy, out double mm_dx, out double mm_dy);
  internal static cdCanvasPixel2MMDelegate cdCanvasPixel2MM = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("cdCanvasPixel2MM"),typeof(cdCanvasPixel2MMDelegate)) as cdCanvasPixel2MMDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate void cdfCanvasMM2PixelDelegate(IntPtr canvas, double mm_dx, double mm_dy, out double dx, out double dy);
  internal static cdfCanvasMM2PixelDelegate cdfCanvasMM2Pixel = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("cdfCanvasMM2Pixel"),typeof(cdfCanvasMM2PixelDelegate)) as cdfCanvasMM2PixelDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate void cdfCanvasPixel2MMDelegate(IntPtr canvas, double dx, double dy, out double mm_dx, out double mm_dy);
  internal static cdfCanvasPixel2MMDelegate cdfCanvasPixel2MM = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("cdfCanvasPixel2MM"),typeof(cdfCanvasPixel2MMDelegate)) as cdfCanvasPixel2MMDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate void cdCanvasOriginDelegate(IntPtr canvas, int x, int y);
  internal static cdCanvasOriginDelegate cdCanvasOrigin = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("cdCanvasOrigin"),typeof(cdCanvasOriginDelegate)) as cdCanvasOriginDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate void cdfCanvasOriginDelegate(IntPtr canvas, double x, double y);
  internal static cdfCanvasOriginDelegate cdfCanvasOrigin = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("cdfCanvasOrigin"),typeof(cdfCanvasOriginDelegate)) as cdfCanvasOriginDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate void cdCanvasGetOriginDelegate(IntPtr canvas, out int x, out int y);
  internal static cdCanvasGetOriginDelegate cdCanvasGetOrigin = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("cdCanvasGetOrigin"),typeof(cdCanvasGetOriginDelegate)) as cdCanvasGetOriginDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate void cdfCanvasGetOriginDelegate(IntPtr canvas, out double x, out double y);
  internal static cdfCanvasGetOriginDelegate cdfCanvasGetOrigin = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("cdfCanvasGetOrigin"),typeof(cdfCanvasGetOriginDelegate)) as cdfCanvasGetOriginDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate void cdCanvasTransformDelegate(IntPtr canvas, ref double matrix);
  internal static cdCanvasTransformDelegate cdCanvasTransform = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("cdCanvasTransform"),typeof(cdCanvasTransformDelegate)) as cdCanvasTransformDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate IntPtr cdCanvasGetTransformDelegate(IntPtr canvas);
  internal static cdCanvasGetTransformDelegate cdCanvasGetTransform = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("cdCanvasGetTransform"),typeof(cdCanvasGetTransformDelegate)) as cdCanvasGetTransformDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate void cdCanvasTransformMultiplyDelegate(IntPtr canvas, ref double matrix);
  internal static cdCanvasTransformMultiplyDelegate cdCanvasTransformMultiply = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("cdCanvasTransformMultiply"),typeof(cdCanvasTransformMultiplyDelegate)) as cdCanvasTransformMultiplyDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate void cdCanvasTransformRotateDelegate(IntPtr canvas, double angle);
  internal static cdCanvasTransformRotateDelegate cdCanvasTransformRotate = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("cdCanvasTransformRotate"),typeof(cdCanvasTransformRotateDelegate)) as cdCanvasTransformRotateDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate void cdCanvasTransformScaleDelegate(IntPtr canvas, double sx, double sy);
  internal static cdCanvasTransformScaleDelegate cdCanvasTransformScale = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("cdCanvasTransformScale"),typeof(cdCanvasTransformScaleDelegate)) as cdCanvasTransformScaleDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate void cdCanvasTransformTranslateDelegate(IntPtr canvas, double dx, double dy);
  internal static cdCanvasTransformTranslateDelegate cdCanvasTransformTranslate = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("cdCanvasTransformTranslate"),typeof(cdCanvasTransformTranslateDelegate)) as cdCanvasTransformTranslateDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate void cdCanvasTransformPointDelegate(IntPtr canvas, int x, int y, out int tx, out int ty);
  internal static cdCanvasTransformPointDelegate cdCanvasTransformPoint = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("cdCanvasTransformPoint"),typeof(cdCanvasTransformPointDelegate)) as cdCanvasTransformPointDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate void cdfCanvasTransformPointDelegate(IntPtr canvas, double x, double y, out double tx, out double ty);
  internal static cdfCanvasTransformPointDelegate cdfCanvasTransformPoint = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("cdfCanvasTransformPoint"),typeof(cdfCanvasTransformPointDelegate)) as cdfCanvasTransformPointDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate void cdCanvasSetAttributeDelegate(IntPtr canvas, string name, string data);
  internal static cdCanvasSetAttributeDelegate cdCanvasSetAttribute = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("cdCanvasSetAttribute"),typeof(cdCanvasSetAttributeDelegate)) as cdCanvasSetAttributeDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate IntPtr cdCanvasGetAttributeDelegate(IntPtr canvas, string name);
  internal static cdCanvasGetAttributeDelegate cdCanvasGetAttribute = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("cdCanvasGetAttribute"),typeof(cdCanvasGetAttributeDelegate)) as cdCanvasGetAttributeDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate void cdCanvasVectorTextDelegate(IntPtr canvas, int x, int y, string s);
  internal static cdCanvasVectorTextDelegate cdCanvasVectorText = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("cdCanvasVectorText"),typeof(cdCanvasVectorTextDelegate)) as cdCanvasVectorTextDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate void cdCanvasMultiLineVectorTextDelegate(IntPtr canvas, int x, int y, string s);
  internal static cdCanvasMultiLineVectorTextDelegate cdCanvasMultiLineVectorText = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("cdCanvasMultiLineVectorText"),typeof(cdCanvasMultiLineVectorTextDelegate)) as cdCanvasMultiLineVectorTextDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate int cdCanvasVectorCharSizeDelegate(IntPtr canvas, int size);
  internal static cdCanvasVectorCharSizeDelegate cdCanvasVectorCharSize = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("cdCanvasVectorCharSize"),typeof(cdCanvasVectorCharSizeDelegate)) as cdCanvasVectorCharSizeDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate void cdCanvasClearDelegate(IntPtr canvas);
  internal static cdCanvasClearDelegate cdCanvasClear = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("cdCanvasClear"),typeof(cdCanvasClearDelegate)) as cdCanvasClearDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate int cdCanvasForegroundDelegate(IntPtr canvas,int color);
  internal static cdCanvasForegroundDelegate cdCanvasForeground = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("cdCanvasForeground"),typeof(cdCanvasForegroundDelegate)) as cdCanvasForegroundDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate int cdCanvasBackgroundDelegate(IntPtr canvas,int color);
  internal static cdCanvasBackgroundDelegate cdCanvasBackground = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("cdCanvasBackground"),typeof(cdCanvasBackgroundDelegate)) as cdCanvasBackgroundDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate IntPtr cdContextDBufferDelegate();
  internal static cdContextDBufferDelegate cdContextDBuffer = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("cdContextDBuffer"),typeof(cdContextDBufferDelegate)) as cdContextDBufferDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate IntPtr cdContextImageRGBDelegate();
  internal static cdContextImageRGBDelegate cdContextImageRGB = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("cdContextImageRGB"),typeof(cdContextImageRGBDelegate)) as cdContextImageRGBDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate IntPtr cdContextDBufferRGBDelegate();
  internal static cdContextDBufferRGBDelegate cdContextDBufferRGB = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("cdContextDBufferRGB"),typeof(cdContextDBufferRGBDelegate)) as cdContextDBufferRGBDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate void cdCanvasFlushDelegate(IntPtr canvas);
  internal static cdCanvasFlushDelegate cdCanvasFlush = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("cdCanvasFlush"),typeof(cdCanvasFlushDelegate)) as cdCanvasFlushDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate void cdKillCanvasDelegate(IntPtr canvas);
  internal static cdKillCanvasDelegate cdKillCanvas = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("cdKillCanvas"),typeof(cdKillCanvasDelegate)) as cdKillCanvasDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate int cdCanvasLineWidthDelegate(IntPtr canvas,int width);
  internal static cdCanvasLineWidthDelegate cdCanvasLineWidth = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("cdCanvasLineWidth"),typeof(cdCanvasLineWidthDelegate)) as cdCanvasLineWidthDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate double wdCanvasLineWidthDelegate(IntPtr canvas,double width_mm);
  internal static wdCanvasLineWidthDelegate wdCanvasLineWidth = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("wdCanvasLineWidth"),typeof(wdCanvasLineWidthDelegate)) as wdCanvasLineWidthDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate int cdCanvasLineJoinDelegate(IntPtr canvas,int style);
  internal static cdCanvasLineJoinDelegate cdCanvasLineJoin = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("cdCanvasLineJoin"),typeof(cdCanvasLineJoinDelegate)) as cdCanvasLineJoinDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate int cdCanvasLineCapDelegate(IntPtr canvas,int style);
  internal static cdCanvasLineCapDelegate cdCanvasLineCap = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("cdCanvasLineCap"),typeof(cdCanvasLineCapDelegate)) as cdCanvasLineCapDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate void cdCanvasBeginDelegate(IntPtr canvas,int mode);
  internal static cdCanvasBeginDelegate cdCanvasBegin = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("cdCanvasBegin"),typeof(cdCanvasBeginDelegate)) as cdCanvasBeginDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate void cdCanvasVertexDelegate(IntPtr canvas,int x,int y);
  internal static cdCanvasVertexDelegate cdCanvasVertex = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("cdCanvasVertex"),typeof(cdCanvasVertexDelegate)) as cdCanvasVertexDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate void cdfCanvasVertexDelegate(IntPtr canvas,double x,double y);
  internal static cdfCanvasVertexDelegate cdfCanvasVertex = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("cdfCanvasVertex"),typeof(cdfCanvasVertexDelegate)) as cdfCanvasVertexDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate void wdCanvasVertexDelegate(IntPtr canvas, double x, double y);
  internal static wdCanvasVertexDelegate wdCanvasVertex = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("wdCanvasVertex"),typeof(wdCanvasVertexDelegate)) as wdCanvasVertexDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate void cdCanvasEndDelegate(IntPtr canvas);
  internal static cdCanvasEndDelegate cdCanvasEnd = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("cdCanvasEnd"),typeof(cdCanvasEndDelegate)) as cdCanvasEndDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate void cdCanvasPathSetDelegate(IntPtr canvas, int action);
  internal static cdCanvasPathSetDelegate cdCanvasPathSet = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("cdCanvasPathSet"),typeof(cdCanvasPathSetDelegate)) as cdCanvasPathSetDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate int cdCanvasClipDelegate(IntPtr canvas,int mode);
  internal static cdCanvasClipDelegate cdCanvasClip = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("cdCanvasClip"),typeof(cdCanvasClipDelegate)) as cdCanvasClipDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate void cdCanvasGetRegionBoxDelegate(IntPtr canvas, out int xmin, out int xmax, out int ymin, out int ymax);
  internal static cdCanvasGetRegionBoxDelegate cdCanvasGetRegionBox = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("cdCanvasGetRegionBox"),typeof(cdCanvasGetRegionBoxDelegate)) as cdCanvasGetRegionBoxDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate void wdCanvasGetRegionBoxDelegate(IntPtr canvas,out double xmin, out double xmax, out double ymin, out double ymax);
  internal static wdCanvasGetRegionBoxDelegate wdCanvasGetRegionBox = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("wdCanvasGetRegionBox"),typeof(wdCanvasGetRegionBoxDelegate)) as wdCanvasGetRegionBoxDelegate;

}

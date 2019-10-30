using System;
using System.Text;
using System.Runtime.InteropServices;

internal static class cd_c {

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
  internal delegate void cdCanvasBoxDelegate(IntPtr canvas, int xmin, int xmax, int ymin, int ymax);
  internal static cdCanvasBoxDelegate cdCanvasBox = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("cdCanvasBox"),typeof(cdCanvasBoxDelegate)) as cdCanvasBoxDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate void cdfCanvasBoxDelegate(IntPtr canvas, double xmin, double xmax, double ymin, double ymax);
  internal static cdfCanvasBoxDelegate cdfCanvasBox = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("cdfCanvasBox"),typeof(cdfCanvasBoxDelegate)) as cdfCanvasBoxDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate void wdCanvasBoxDelegate(IntPtr canvas, double xmin, double xmax, double ymin, double ymax);
  internal static wdCanvasBoxDelegate wdCanvasBox = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("wdCanvasBox"),typeof(wdCanvasBoxDelegate)) as wdCanvasBoxDelegate;

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
  internal delegate void cdCanvasMM2PixelDelegate(IntPtr canvas, double mm_dx, double mm_dy, out int dx, out int dy);
  internal static cdCanvasMM2PixelDelegate cdCanvasMM2Pixel = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("cdCanvasMM2Pixel"),typeof(cdCanvasMM2PixelDelegate)) as cdCanvasMM2PixelDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate void cdfCanvasMM2PixelDelegate(IntPtr canvas, double mm_dx, double mm_dy, out double dx, out double dy);
  internal static cdfCanvasMM2PixelDelegate cdfCanvasMM2Pixel = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("cdfCanvasMM2Pixel"),typeof(cdfCanvasMM2PixelDelegate)) as cdfCanvasMM2PixelDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate void cdCanvasPixel2MMDelegate(IntPtr canvas, int dx, int dy, out double mm_dx, out double mm_dy);
  internal static cdCanvasPixel2MMDelegate cdCanvasPixel2MM = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("cdCanvasPixel2MM"),typeof(cdCanvasPixel2MMDelegate)) as cdCanvasPixel2MMDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate void cdfCanvasPixel2MMDelegate(IntPtr canvas, double dx, double dy, out double mm_dx, out double mm_dy);
  internal static cdfCanvasPixel2MMDelegate cdfCanvasPixel2MM = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("cdfCanvasPixel2MM"),typeof(cdfCanvasPixel2MMDelegate)) as cdfCanvasPixel2MMDelegate;

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

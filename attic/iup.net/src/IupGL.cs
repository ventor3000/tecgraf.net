using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tecgraf
{
    public static class IupGL
    {
        public static void Open() { NativeIUPGL.IupGLCanvasOpen(); }
        public static IupHandle Canvas(string action=null) { 
            IupHandle res=IupHandle.Create(NativeIUPGL.IupGLCanvas(action)); 
            if(res==null)
                throw new Exception("Failed to create OpenGL canvas, was IupGL Open():ed correctly?");
            return res;
        
        }
        public static void MakeCurrent(IupHandle ih) { NativeIUPGL.IupGLMakeCurrent(IupHandle.GetCHandle(ih)); }
        public static bool IsCurrent(IupHandle ih) { return NativeIUPGL.IupGLIsCurrent(IupHandle.GetCHandle(ih)) != 0; }
        public static void SwapBuffers(IupHandle ih) { NativeIUPGL.IupGLSwapBuffers(IupHandle.GetCHandle(ih)); }
        public static void Palette(IupHandle ih, int index, float r, float g, float b) { NativeIUPGL.IupGLPalette(IupHandle.GetCHandle(ih), index, r, g, b); }
        public static void UseFont(IupHandle ih, int first, int count, int list_base) { NativeIUPGL.IupGLUseFont(IupHandle.GetCHandle(ih), first, count, list_base); }
        public static void Wait(bool gl) { NativeIUPGL.IupGLWait(gl ? 1 : 0); }
    }
}

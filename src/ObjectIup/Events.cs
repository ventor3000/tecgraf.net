using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tecgraf.ObjectIup
{

    public class IupEventArgs : EventArgs
    {
        public CBResult Result=CBResult.Default;
    }

    public class KeyEventArgs : IupEventArgs
    {
        public Key Key;

        public KeyEventArgs(Key k)
        {
            this.Key = k;
        }
    }


    public class MouseEventArgs : IupEventArgs
    {
        public MouseButton Button;
        public int X;
        public int Y;
        public ModStatus Status;

        public MouseEventArgs(MouseButton button, int x, int y, ModStatus status)
        {
            this.Button = button;
            this.X = x;
            this.Y = y;
            this.Status = status;
        }

    }

    public class ShowEventArgs : IupEventArgs
    {
        public ShowState State;

        public ShowEventArgs(ShowState s)
        {
            State = s;
        }
    }


    public class CopyDataEventArgs : IupEventArgs
    {
        public string CommandLine;

        public CopyDataEventArgs(string cmdline)
        {
            CommandLine = cmdline;
        }
    }


    public class DropFilesEventArgs : IupEventArgs
    {
        public string FileName;
        public int Index;
        public int X;
        public int Y;

        public DropFilesEventArgs(string fname, int idx, int x, int y)
        {
            this.FileName = fname;
            this.Index = idx;
            this.X = x;
            this.Y = y;
        }
    }

    public class PointEventArgs : IupEventArgs
    {
        public int X, Y;

        public PointEventArgs(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }

    public class SizeEventArgs : IupEventArgs
    {
        public int Width,Height;

        public SizeEventArgs(int w, int h)
        {
            this.Width=w;
            this.Height=h;
        }
    }

    public class TrayClickEventArgs : IupEventArgs
    {
        public MouseButton Button;
        public bool Pressed;
        public bool DoubleClick;

        public TrayClickEventArgs(MouseButton btn, bool pressed, bool dclick)
        {
            this.Button = btn;
            this.Pressed = pressed;
            this.DoubleClick = dclick;
        }
    }

    
}

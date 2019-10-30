

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Tecgraf;
using Tecgraf.ObjectIup;


namespace WindowsFormsApplication1
{
    static class Program
    {

        static IupHandle menu;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Iup.Open();


            Dialog dlg = new Dialog("My dialog") { Expand = Expand.Yes};

            
            Glyph gl=Glyph.FromFile("c:\\temp\\egg24.bmp");
            VBox vbox = new VBox(dlg) { Align = HAlign.Center,Margin=new Size(18,8),Gap=4 };
            Button escbtn=new Button(vbox, "esc") {BackColor=Color.Red,Expand=Expand.Yes,Alignment=Alignment.BottomRight };
            Button enterbtn=new Button(vbox, "enter") { Expand = Expand.No };
            new Button(vbox, "gamma") { BackColor = Color.Red, Expand = Expand.Yes, Alignment = Alignment.BottomRight,Flat=true };
            Button btn=new Button(vbox, "delta") { Expand = Expand.No ,Flat=true,Glyph=gl};

            Text txt = new Text(vbox);


            btn.CBClick += delegate {


                Point p = dlg.ScreenPosition;
                Point p2 = btn.ScreenPosition;


                int debug = 0;
            
            };

            dlg.MenuBox=true;

            dlg.Shrink = false;
           // dlg.CBDropFiles += dlg_CBDropFiles;
            dlg.Tray = true;
            dlg.TrayTip = "Hello world";
            dlg.TrayGlyph = gl;

            dlg.CBMove += dlg_CBMove;

            dlg.CBClose += dlg_CBClose;
            dlg.CBResize += dlg_CBResize;

            dlg.StartFocus = btn;

            dlg.CBTrayClick += dlg_CBTrayClick;

            dlg.Show();

            

            Iup.MainLoop();


            dlg.Dispose();
            dlg = null;
            
            GC.Collect();
        }



        static bool htb = true;
        static void dlg_CBTrayClick(object sender, TrayClickEventArgs e)
        {
            Dialog d = sender as Dialog;
            if (e.Pressed)
            {
                d.HideTaskbar = htb;
                htb = !htb;
            }

            
        }

        static void dlg_CBResize(object sender, SizeEventArgs e)
        {
            Dialog d = sender as Dialog;
            d.Title = e.Width.ToString() + "  " + e.Height.ToString();
        }

        static void dlg_CBMove(object sender, PointEventArgs e)
        {
            
        }


        static bool first = true;

        static void dlg_CBClose(object sender, IupEventArgs e)
        {

           
            
        }

        static void dlg_CBDropFiles(object sender, DropFilesEventArgs e)
        {
            

        }

        
      


    }
}

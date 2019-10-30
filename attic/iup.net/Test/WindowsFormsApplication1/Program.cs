

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Tecgraf;
//using Tecgraf.CDSharp;


namespace WindowsFormsApplication1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Iup.Open();
            IupControls.Open();
            IupGL.Open();

            IupHandle button,bkbox;

            
            using (IupHandle dlg = Iup.Dialog(
                Iup.Vbox(
                    LabelText("Namn:"),
                    LabelText("Adress:"),
                    LabelText("Gata:"),
                    button=Iup.Button("OK")
                 ).SetAttributes("ALIGNMENT=ARIGHT,NGAP=4")
                 
              )
            )
            {
                //openitem.SetCallback ("K_cO", new CallbackKeyPressCB (OnKeyPress));


                byte[] img=new byte[100*100*3];
                img[10] = 25;
                IupHandle iupimg = Iup.ImageRGB(100, 100, img);



                var ep=Iup.ElementPropertiesDialog(button);
                ep.Show();


                dlg.Show();
                Iup.MainLoop();
            }





            Iup.Close();

        }


        static IupHandle LabelText(string caption)
        {
            return Iup.Hbox(
                Iup.Label(caption),
                Iup.Text(null),
                Iup.Button("...")
            ).SetAttributes("NGAP=4");
        }

        

        private static CBResult ButtonClick(IupHandle sender)
        {

            

            return CBResult.Default;
        }

		static CBResult OnButton (IupHandle sender)
		{
			//throw new NotImplementedException ();

			return CBResult.Default;
		}


		/*static CBResult OnKeyPress (IupHandle sender, Key key, bool pressed)
		{
			Iup.Message ("HELLO", "WORLD");
			return CBResult.Default;
		}*/
    }
}

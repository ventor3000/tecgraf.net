using System;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using System.Runtime.InteropServices;

namespace Generator
{
    
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            string module = null;
            string dllname = null;
            
            string[] lines = File.ReadAllLines(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + Path.DirectorySeparatorChar + "imports.lst");

            Dictionary<string, List<string>> modules = new Dictionary<string, List<string>>();

            foreach (string _line in lines)
            {
                string line = _line.Trim();
                if (line.StartsWith("#") || line == "")
                    continue;

                string left, right;
                SplitAt(line, out left, out right, ' ');

                string importfunc, netfunc; //function of imported name and of the .net name. Normally the same but can be overridden by netname=importname in imports file
                GetFunctionNames(left,out netfunc,out importfunc);

                if (left == "module")
                {
                    SplitAt(right, out dllname,out module, ',');
                }
                else
                {
                    List<string> targetcode = GetModuleLines(dllname,module, modules);
                    string retval, args;
                    SplitAt(right, out retval, out args, ',');

                    if (args == null)
                        args = "";
                    if (left == null)
                        left = "void";

                    targetcode.Add("  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]");
                    targetcode.Add(string.Format("  internal delegate {0} {1}Delegate({2});", retval, netfunc, args));
                    //targetcode.Add(string.Format("  internal static {0}Delegate {0};",left));

                    targetcode.Add(string.Format(
                      "  internal static {0}Delegate {0} = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction(\"{1}\"),typeof({0}Delegate)) as {0}Delegate;",
                      netfunc, importfunc
                      ));



                    targetcode.Add("");
                }
            }

            foreach (var mod in modules)
            {
                List<string> targetcode = mod.Value;
                targetcode.Add("}");

                //todo: write static constructor

                string fname = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + Path.DirectorySeparatorChar + mod.Key + ".cs";
                Console.WriteLine("Writing " + fname);
                File.WriteAllLines(fname, targetcode.ToArray());
            }
        }

        private static void GetFunctionNames(string left, out string netfunc, out string importfunc)
        {
            string[] strs = left.Trim().Split('=');
            if (strs.Length == 1)
            {
                netfunc = strs[0].Trim();
                importfunc = netfunc;
            }
            else if (strs.Length == 2)
            {
                netfunc = strs[0].Trim();
                importfunc = strs[1].Trim();
            }
            else
                throw new Exception("Invalid file when splitting function name @ =");
        }

        private static List<string> GetModuleLines(string dllname, string module, Dictionary<string, List<string>> modules)
        {
            List<string> lines;
            if (!modules.TryGetValue(module, out lines))
            {
                lines = new List<string>();
                lines.Add("using System;");
                lines.Add("using System.Text;");
                lines.Add("using System.Runtime.InteropServices;");
                lines.Add("");
                lines.Add("internal static class " + module +"{");
                lines.Add("");
                lines.Add("  static DynamicLinker dynlink = new DynamicLinker(\"" + dllname + "\");");
                lines.Add("");


                modules[module] = lines;
            }

            return lines;
        }





        private static void SplitAt(string line, out string left, out string right, char splitchar)
        {
            line = line.Trim();

            int spos = line.IndexOf(splitchar);

            if (spos >= 0)
            {
                left = line.Substring(0, spos).Trim();
                right = line.Substring(spos + 1).Trim();
            }
            else
            {
                left = line.Trim();
                right = null;
            }
        }
    }
}

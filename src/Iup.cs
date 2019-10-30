using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Drawing;
using System.Globalization;

/*Resolve:
 * Dashed attribut på progressbar fungerar ej i windows
 * CenterParent fungerar ej i Popup och ShowXY (blir center screen)
 * 
 * */

// TODO: Check all functions as of IUP 3.10.1 exists
// TODO: Document all public IUP functions
// TODO: port the new theming reference from nimrod
// TODO: Implement iup utilities class to easily load images etc.
// TODO: Make all IntPtr handles go away in public api
// TODO: report bug in GTK with sizer having a scintilla and a multiline text in a splitter
// TODO: SaveImageAsText not working correctly (?)
// TODO: documentation bug in iup scintilla KEYWORDS0, KEYWORD0 in sample of scintilla




namespace Tecgraf
{

    public static class Iup
    {

        //private static object theming_ref;    //holds a reference to a theming object in windows so that its not garbage collected

        public static Result Open()
        {

            AppendWindowsPath();

            //EnableThemingInScope.EnableThemingInWindows();
            Result res=(Result)NativeIUP.IupOpen(IntPtr.Zero, IntPtr.Zero);


            // In .NET we always want unicode
            Iup.SetStrGlobal("UTF8MODE", "YES");
            Iup.SetStrGlobal("UTF8MODE_FILE", "YES");

            return res;
        }


        private static void AppendWindowsPath()
        {

            var osstr=System.Environment.OSVersion.Platform.ToString().ToUpper();
            if (!(osstr.StartsWith("WIN") || osstr.StartsWith("XBOX")))
                return; //not a windows system            

            try //first try to add lib32/64 next to exefile
            {
                //adds lib32/lib64 path to environment path if they exists

                string exepath = Environment.GetCommandLineArgs()[0];

                for (int i = 0; i < 3; i++)
                { //scan directories upwards

                    exepath=Path.GetDirectoryName(exepath); //remove one level, scanning upwards from exefile

                    string trimpath = Path.Combine(Path.GetDirectoryName(exepath), "..", IntPtr.Size == 8 ? "lib64" : "lib32");

                    trimpath = Path.GetFullPath(trimpath);

                    if (Directory.Exists(trimpath) )
                    {
                        string oldpath = Environment.GetEnvironmentVariable("PATH");
                        Environment.SetEnvironmentVariable("PATH", trimpath + ";" + oldpath);
                        oldpath = Environment.GetEnvironmentVariable("PATH");
                        return; //we now have a path looking for the dll:s
                    }
                }
            }
            catch (Exception exc)
            {

            }

            

        }

        public static void Close() { NativeIUP.IupClose(); }

        public static int MainLoop() { return NativeIUP.IupMainLoop(); }
        public static CBResult LoopStep() { return (CBResult)NativeIUP.IupLoopStep(); }
        public static CBResult LoopStepWait() { return (CBResult)NativeIUP.IupLoopStepWait(); }
        public static int MainLoopLevel { get { return NativeIUP.IupMainLoopLevel(); } }
        public static void Flush() { NativeIUP.IupFlush(); }
        public static void ExitLoop() { NativeIUP.IupExitLoop(); }

        public static bool RecordInput(string filename, RecordMode mode) {return (Result)NativeIUP.IupRecordInput(filename, (int)mode)==Result.NoError;}
        public static bool PlayInput(string filename) { return (Result)NativeIUP.IupPlayInput(filename)==Result.NoError; }

        
        public static bool Help(string url) { return NativeIUP.IupHelp(url) == 1; }
        public static string Load(string filename) { return UTF8ToStr(NativeIUP.IupLoad(filename)); }
        public static string LoadBuffer(string filename) { return UTF8ToStr(NativeIUP.IupLoadBuffer(filename)); }

        public static string Version { get { return UTF8ToStr(NativeIUP.IupVersion()); } }
        public static string VersionDate { get { return UTF8ToStr(NativeIUP.IupVersionDate()); } }
        public static int VersionNumber { get { return NativeIUP.IupVersionNumber(); } }
        
        public static string Language { get { return UTF8ToStr(NativeIUP.IupGetLanguage()); } set { NativeIUP.IupSetLanguage(value); } }
        public static void StoreLanguageString(string name, string str) { NativeIUP.IupStoreLanguageString(name, str); }
        public static string GetLanguageString(string name) { return UTF8ToStr(NativeIUP.IupGetLanguageString(name)); }
        public static void SetLanguagePack(IupHandle ih) { NativeIUP.IupSetLanguagePack(IupHandle.GetCHandle(ih)); }

        public static void SetGlobal(string name, IntPtr value) { NativeIUP.IupSetGlobal(name, value); }
        public static void SetStrGlobal(string name, string value) { NativeIUP.IupSetStrGlobal(name, value); }
        public static string GetGlobal(string name) { return UTF8ToStr(NativeIUP.IupGetGlobal(name)); }
        public static IntPtr GetGlobalPtr(string name) { return NativeIUP.IupGetGlobal(name); }
        public static IupHandle GetFocus() { return IupHandle.Create(NativeIUP.IupGetFocus()); }
        public static CBDefault GetFunction(string name) { return NativeIUP.IupGetFunction(name); }
        public static CBDefault SetFunction(string name, Delegate func) { return NativeIUP.IupSetFunction(name, IupHandle.MapCallback(IntPtr.Zero, name, func)); }
        public static IupHandle GetHandle(string name) { return IupHandle.Create(NativeIUP.IupGetHandle(name)); }

        public static string[] GetAllNames() { return GetCharArrayCountFunc(new CharArrayCountDelegate(NativeIUP.IupGetAllNames)); }
        public static string[] GetAllDialogs() { return GetCharArrayCountFunc(new CharArrayCountDelegate(NativeIUP.IupGetAllDialogs)); }

        public static string[] GetAllClasses() { return GetCharArrayCountFunc(new CharArrayCountDelegate(NativeIUP.IupGetAllClasses)); }
        public static string[] GetClassAttributes(string classname) { return GetNamedCharArrayCountFunc(classname, new NamedCharArrayCountDelegate(NativeIUP.IupGetClassAttributes)); }
        public static string[] GetClassCallbacks(string classname) { return GetNamedCharArrayCountFunc(classname, new NamedCharArrayCountDelegate(NativeIUP.IupGetClassCallbacks)); }

        public static void SetClassDefaultAttribute(string classname, string name, string value) { NativeIUP.IupSetClassDefaultAttribute(classname, name, value); }
        

        public static IupHandle Create(string classname) { return IupHandle.Create(NativeIUP.IupCreate(classname)); }
        public static IupHandle Create(string classname, params IntPtr[] param) { return IupHandle.Create(NativeIUP.IupCreatev(classname, ref param[0])); }

        //Element creation
        public static IupHandle Fill() { return IupHandle.Create(NativeIUP.IupFill()); }
        public static IupHandle Radio(IupHandle child) { return IupHandle.Create(NativeIUP.IupRadio(IupHandle.GetCHandle(child))); }
        public static IupHandle Vbox(params IupHandle[] children) { return IupHandle.Create(NativeIUP.IupVboxv(PtrArrayOf(children))); }
        public static IupHandle Zbox(params IupHandle[] children) { return IupHandle.Create(NativeIUP.IupZboxv(PtrArrayOf(children))); }
        public static IupHandle Hbox(params IupHandle[] children) { return IupHandle.Create(NativeIUP.IupHboxv(PtrArrayOf(children))); }
        public static IupHandle Normalizer(params IupHandle[] ih_list) { return IupHandle.Create(NativeIUP.IupNormalizerv(PtrArrayOf(ih_list))); }
        public static IupHandle CBox(params IupHandle[] children) { return IupHandle.Create(NativeIUP.IupCboxv(PtrArrayOf(children))); }
        public static IupHandle SBox(IupHandle child) { return IupHandle.Create(NativeIUP.IupSbox(IupHandle.GetCHandle(child))); }
        public static IupHandle Split(IupHandle child1, IupHandle child2) { return IupHandle.Create(NativeIUP.IupSplit(IupHandle.GetCHandle(child1), IupHandle.GetCHandle(child2))); }
        public static IupHandle ScrollBox(IupHandle child) { return IupHandle.Create(NativeIUP.IupScrollBox(IupHandle.GetCHandle(child))); }
        public static IupHandle GridBox(params IupHandle[] children) { return IupHandle.Create(NativeIUP.IupGridBoxv(PtrArrayOf(children))); }
        public static IupHandle Expander(IupHandle child) { return IupHandle.Create(NativeIUP.IupExpander(IupHandle.GetCHandle(child))); }
        public static IupHandle DetachBox(IupHandle child) { return IupHandle.Create(NativeIUP.IupDetachBox(IupHandle.GetCHandle(child))); }
        public static IupHandle BackgroundBox(IupHandle child) { return IupHandle.Create(NativeIUP.IupBackgroundBox(IupHandle.GetCHandle(child))); }

        
        public static IupHandle Frame(IupHandle child) { return IupHandle.Create(NativeIUP.IupFrame(IupHandle.GetCHandle(child))); }
        public static IupHandle Item(string title, string action=null) { return IupHandle.Create(NativeIUP.IupItem(title, action)); }
        public static IupHandle Image(int width, int height, byte[] pixmap) { return IupHandle.Create(NativeIUP.IupImage(width, height, pixmap)); }
        public static IupHandle ImageRGB(int width, int height, byte[] pixmap) { return IupHandle.Create(NativeIUP.IupImageRGB(width, height, pixmap)); }
        public static IupHandle ImageRGBA(int width, int height, byte[] pixmap) { return IupHandle.Create(NativeIUP.IupImageRGBA(width, height, pixmap)); }
        public static IupHandle Submenu(string title, IupHandle child) { return IupHandle.Create(NativeIUP.IupSubmenu(title, IupHandle.GetCHandle(child))); }
        public static IupHandle Separator() { return IupHandle.Create(NativeIUP.IupSeparator()); }
        public static IupHandle Menu(params IupHandle[] children) { return IupHandle.Create(NativeIUP.IupMenuv(PtrArrayOf(children))); }
        public static IupHandle Button(string title, string action = null) { return IupHandle.Create(NativeIUP.IupButton(title, action)); }

        public static IupHandle Canvas(string action=null) { return IupHandle.Create(NativeIUP.IupCanvas(action)); }
        public static IupHandle Dialog(IupHandle child) { return IupHandle.Create(NativeIUP.IupDialog(IupHandle.GetCHandle(child))); }
        public static IupHandle User() { return IupHandle.Create(NativeIUP.IupUser()); }
        public static IupHandle Label(string title) { return IupHandle.Create(NativeIUP.IupLabel(title)); }
        public static IupHandle List(string action=null) { return IupHandle.Create(NativeIUP.IupList(action)); }
        public static IupHandle Text(string action=null) { return IupHandle.Create(NativeIUP.IupText(action)); }
        public static IupHandle Toggle(string title, string action=null) { return IupHandle.Create(NativeIUP.IupToggle(title, action)); }
        public static IupHandle Timer() { return IupHandle.Create(NativeIUP.IupTimer()); }
        public static IupHandle Clipboard() { return IupHandle.Create(NativeIUP.IupClipboard()); }
        public static IupHandle ProgressBar() { return IupHandle.Create(NativeIUP.IupProgressBar()); }
        public static IupHandle Val(bool horizontal) { return IupHandle.Create(NativeIUP.IupVal(horizontal ? "HORIZONTAL" : "VERTICAL")); }
        public static IupHandle Tabs(params IupHandle[] children) { return IupHandle.Create(NativeIUP.IupTabsv(PtrArrayOf(children))); }
        public static IupHandle Tree() { return IupHandle.Create(NativeIUP.IupTree()); }
        public static IupHandle Link(string url, string title) { return IupHandle.Create(NativeIUP.IupLink(url, title)); }


        public static bool SaveImageAsText(IupHandle ih, string filename, SaveImageFormat format, string name)
        {
            return NativeIUP.IupSaveImageAsText(IupHandle.GetCHandle(ih), filename, format.ToString().ToUpper(), name) != 0;
        }

        public static void TextConvertLinColToPos(IupHandle ih,int lin,int col,out int pos) {
            NativeIUP.IupTextConvertLinColToPos(IupHandle.GetCHandle(ih),lin,col,out pos);
        }
       
        public static void TextConvertPosToLinCol(IupHandle ih,int pos,out int lin,out int col) {
            NativeIUP.IupTextConvertPosToLinCol(IupHandle.GetCHandle(ih),pos,out lin,out col);
        }

        public static int ConvertXYToPos(IupHandle ih, int x, int y) { return NativeIUP.IupConvertXYToPos(IupHandle.GetCHandle(ih), x, y); }


        public static bool TreeSetUserId(IupHandle ih_tree, int id, IntPtr userid)
        {
            return NativeIUP.IupTreeSetUserId(IupHandle.GetCHandle(ih_tree), id, userid) != 0;
        }

        public static IntPtr TreeGetUserId(IupHandle ih_tree, int id)
        {
            return NativeIUP.IupTreeGetUserId(IupHandle.GetCHandle(ih_tree), id);
        }

        public static int TreeGetId(IupHandle ih_tree, IntPtr userid)
        {
            return NativeIUP.IupTreeGetId(IupHandle.GetCHandle(ih_tree), userid);
        }

        public static void TreeSetAttributeHandle(IupHandle ih, string name, int id, IupHandle ih_named)
        {
            NativeIUP.IupTreeSetAttributeHandle(IupHandle.GetCHandle(ih), name, id, IupHandle.GetCHandle(ih_named));
        }

        

        #region PREDIFINED DIALOGS

        public static IupHandle FileDlg() { return IupHandle.Create(NativeIUP.IupFileDlg()); }
        public static IupHandle MessageDlg() { return IupHandle.Create(NativeIUP.IupMessageDlg()); }
        public static IupHandle ColorDlg() { return IupHandle.Create(NativeIUP.IupColorDlg()); }
        public static IupHandle FontDlg() { return IupHandle.Create(NativeIUP.IupFontDlg()); }
        public static IupHandle IupProgressDlg() {return IupHandle.Create(NativeIUP.IupProgressDlg());}


        public static GetFileResult GetFile(ref string file)
        {
            //TODO: this does not work with UTF8

            StringBuilder sb = new StringBuilder(4097);  //max 4096 chars according to IUP docs. +1 for safety for zero term.
            if (file != null) sb.Append(file);
            GetFileResult res = (GetFileResult)NativeIUP.IupGetFile(sb);
            file = sb.ToString();
            return res;
        }
        public static void Message(string title, string message) { NativeIUP.IupMessage(title, message); }
        public static int Alarm(string title, string message, string button1, string button2, string button3) { return NativeIUP.IupAlarm(title, message, button1, button2, button3); }


        /// <summary>
        /// Multiselect version of ListDialog.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="max_col"></param>
        /// <param name="max_lin"></param>
        /// <param name="list"></param>
        /// <param name="selected"></param>
        /// <returns></returns>
        public static int[] ListDialog(string title, int max_col, int max_lin, IEnumerable<string> list, params int[] selected)
        {

            string[] _list = new List<string>(list).ToArray();

            int[] m = new int[_list.Length];
            for (int l = 0; l < m.Length; l++)
            {
                if (Array.IndexOf<int>(selected, l) >= 0)
                    m[l] = 1;
                else
                    m[l] = 0;
            }

            int res = NativeIUP.IupListDialog(2, title, _list.Length, _list, 0, max_col, max_lin, m);
            if (res == -1)
                return null;

            List<int> retarr = new List<int>();
            for (int l = 0; l < m.Length; l++)
                if (m[l] != 0)
                    retarr.Add(l);

            return retarr.ToArray();
        }


        /// <summary>
        /// Single select version of ListDialog.
        /// </summary>
        /// <param name="title">Text in dialogs title bar.</param>
        /// <param name="max_col">Number of columns in list.</param>
        /// <param name="max_lin">Number of lines in list.</param>
        /// <param name="list">A collection of string to be shown in the list.</param>
        /// <param name="selected">Index of the pre-selected item, starting with 0 for the first item.</param>
        /// <returns>The selected item index or -1 if canceled.</returns>
        public static int ListDialog(string title, int max_col, int max_lin, IEnumerable<string> list, int selected)
        {
            string[] opts = new List<string>(list).ToArray();
            return NativeIUP.IupListDialog(1, title, opts.Length, opts, selected + 1, max_col, max_lin, null);
        }


        private delegate int CharArrayCountDelegate(ref IntPtr names, int max_n);
        static string[] GetCharArrayCountFunc(CharArrayCountDelegate d)
        {
            IntPtr zero = IntPtr.Zero;
            int num = d(ref zero, 0);
            IntPtr[] ptrs = new IntPtr[num];
            if (num == 0) return new string[0];
            num = d(ref ptrs[0], num);
            string[] res = new string[num];
            for (int l = 0; l < num; l++)
                res[l] = UTF8ToStr(ptrs[l]);
            return res;

        }

        private delegate int NamedCharArrayCountDelegate(string name, ref IntPtr names, int max_n);
        static string[] GetNamedCharArrayCountFunc(string name, NamedCharArrayCountDelegate d)
        {   //TODO: there is a bug here when used with GetClassAttributes, num becomes diffren in the two calls!
            IntPtr zero = IntPtr.Zero;
            int num = d(name, ref zero, 0);
            IntPtr[] ptrs = new IntPtr[num];
            if (num == 0) return new string[0];
            num = d(name, ref ptrs[0], num);
            string[] res = new string[num];
            for (int l = 0; l < num; l++)
                res[l] = UTF8ToStr(ptrs[l]);
            return res;

        }

        /// <summary>
        /// Shows a text input dialog to the user. Maximum length of entered text is 10000 characters.
        /// </summary>
        /// <param name="title">Text in the dialogs title bar.</param>
        /// <param name="text">The initial text of dialog. Can be null for empty string.</param>
        /// <returns>True if successful or false on cancel.</returns>
        public static bool GetText(string title, ref string text)
        {
            IntPtr cstring=IntPtr.Zero;

            try
            {
                // According to manual 10240 characters maximum+2 extra for zero term safety etc.
                cstring = Marshal.AllocHGlobal(10242);

                int cnt = 0;
                if (text != null)
                {
                    byte[] utfcode = Encoding.UTF8.GetBytes(text);

                    if (utfcode.Length > 10240)
                        Array.Resize<byte>(ref utfcode, 10240);

                    cnt = utfcode.Length;
                    Marshal.Copy(utfcode, 0, cstring, cnt);
                }

                Marshal.WriteByte(cstring, cnt, 0);

                if (NativeIUP.IupGetText(title, cstring) != 0)
                {
                    text = IupHandle.UTF8ToStr(cstring);
                    return true;
                }

                return false;
            }
            finally {
                if(cstring!=IntPtr.Zero)
                    Marshal.FreeHGlobal(cstring);
            }
        }


        public static bool GetColor(int x, int y, ref byte red, ref byte green, ref byte blue)
        {
            if (NativeIUP.IupGetColor(x, y, ref red, ref green, ref blue) == 0)
                return false;
            return true;
        }

        public static bool GetColor(int x, int y, ref Color color)
        {
            byte r = color.R;
            byte g = color.G;
            byte b = color.B;
            if (!GetColor(x, y, ref r, ref g, ref b))
                return false;
            color = Color.FromArgb((r << 16) | (g << 8) | b);
            return true;
        }

        public static IupHandle LayoutDialog(IupHandle dialog) {return IupHandle.Create(NativeIUP.IupLayoutDialog(IupHandle.GetCHandle(dialog)));}

        public static IupHandle ElementPropertiesDialog(IupHandle element) { return IupHandle.Create(NativeIUP.IupElementPropertiesDialog(IupHandle.GetCHandle(element))); }

        #endregion PREDEFINED_DIALOGS


        #region UTILITIES

        private static IntPtr[] PtrArrayOf(params IupHandle[] h)
        {
            if (h == null) return null;

            IntPtr[] res = new IntPtr[h.Length + 1];  //one extra element for zero termination
            int c = 0;
            foreach (IupHandle ih in h)
            {
                if (ih != null)
                    res[c++] = IupHandle.GetCHandle(ih);
                else
                    res[c++] = IntPtr.Zero;
            }
            res[c] = IntPtr.Zero; //zero terminate array
            return res;
        }

        internal static string UTF8ToStr(IntPtr ptr)
        {
            //Just a shortcut!
            return IupHandle.UTF8ToStr(ptr);
        }

        #endregion



    }

    public class IupHandle : IDisposable
    {

        readonly IntPtr Handle;
        bool disposed = false;

        public static readonly IupHandle Zero = new IupHandle(IntPtr.Zero);

        private IupHandle(IntPtr cobject) 
        {
            //pirvate constructor. Handles should always be created with Create() function
            this.Handle = cobject;
        }

       /* ~Ihandle()
        {
            Dispose(false);
        }*/

        public static IntPtr GetCHandle(IupHandle from)
        {
            if (from == null) return IntPtr.Zero;
            return from.Handle;
        }


        public static IupHandle Create(IntPtr ih)
        {
            if (ih == IntPtr.Zero)
                return null;

            return new IupHandle(ih);
        }

        public override bool Equals(object obj)
        {
            IupHandle h = obj as IupHandle;
            if(h!=null)
                return Handle.Equals(h.Handle);
            else
                return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return Handle.GetHashCode();
        }

        public static bool operator ==(IupHandle a, IupHandle b)
        {
            if ((object)a == null)
            {
                if ((object)b == null)
                    return true;
                return false;
            }
            else if ((object)b == null)
                return false;

            return a.Handle == b.Handle;
        }

        public static bool operator !=(IupHandle a, IupHandle b)
        {
            return !(a == b);
        }  



        static internal unsafe string UTF8ToStr(IntPtr cstr)
        {

            if (cstr == IntPtr.Zero)
                return null;

            byte* walk = (byte*)cstr;

            // find the end of the string
            while (*walk != 0)
                walk++;

            int length = (int)(walk - (byte*)cstr);

            // should not be null terminated
            byte[] strbuf = new byte[length];
            // skip the trailing null
            Marshal.Copy(cstr, strbuf, 0, length);
            string data = Encoding.UTF8.GetString(strbuf);
            return data;
        }



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
                    RecursiveUnmapCallbacks(this);
                    Destroy();
                }

                // Call the appropriate methods to clean up 
                // unmanaged resources here.
                // If disposing is false, 
                // only the following code is executed.

            }
            disposed = true;
        }

        private void RecursiveUnmapCallbacks(IupHandle Handle)
        {
            if (Handle == null)
                return;
            IupHandle ih = Handle;

            int ch = ih.GetChildCount();
            for (int ci = 0; ci < ch; ci++)
                RecursiveUnmapCallbacks(ih.GetChild(ci));



            if (CallbackMap.ContainsKey(Handle.Handle))
                CallbackMap.Remove(Handle.Handle);
        }

        public string this[string attrname]
        {
            set { SetStrAttribute(attrname, value); }
            get { return GetStrAttribute(attrname); }
        }




        private static Dictionary<IntPtr, Dictionary<string, Delegate>> CallbackMap = new Dictionary<IntPtr, Dictionary<string, Delegate>>();
        internal static IntPtr MapCallback(IntPtr ihcobject, string name, Delegate value)
        {
            //NOTE: ihcobject which is IntPtr.Zero is used for global functions, not owned by an object

            //have to remember c-style function pointers to avoid garbage collection
            IntPtr lastcb;
            if (value != null)
                lastcb = Marshal.GetFunctionPointerForDelegate(value);
            else
                lastcb = IntPtr.Zero;

            if (value != null) //insert value
            {
                if (!CallbackMap.ContainsKey(ihcobject))    //need to keep reference to callback to avoid garbage collect it
                    CallbackMap[ihcobject] = new Dictionary<string, Delegate>();
                CallbackMap[ihcobject][name] = value;
            }
            else
            { //remove value
                if (CallbackMap.ContainsKey(ihcobject) && CallbackMap[ihcobject].ContainsKey(name))
                    CallbackMap[ihcobject].Remove(name);
            }
            return lastcb;
        }



        /// <summary>
        /// Mark the element to be redraw when the control returns to the system.
        /// </summary>
        public void Update() { NativeIUP.IupUpdate(Handle); }

        /// <summary>
        /// Mark the elements children to be redraw when the control returns to the system.
        /// </summary>
        public void UpdateChildren() { NativeIUP.IupUpdateChildren(Handle); }

        /// <summary>
        /// Force the element and its children to be redraw immediately.
        /// </summary>
        /// <param name="children">If the children should be redrawn.</param>
        public void Redraw(bool children) { NativeIUP.IupRedraw(Handle, children ? 1 : 0); }

        /// <summary>
        /// Updates the size and layout of controls after changing size attributes. 
        /// Can be used for any element inside a dialog, the layout of the dialog will be updated. 
        /// It can change the layout of all the controls inside the dialog 
        /// because of the dynamic layout positioning.
        /// </summary>
        public void Refresh() { NativeIUP.IupRefresh(Handle); }

        /// <summary>
        /// Updates the size and layout of controls after changing size attributes. 
        /// Can be used for any element inside a dialog, only its children will be updated. 
        /// It can change the layout of all the controls inside the given element 
        /// because of the dynamic layout positioning.
        /// </summary>
        public void RefreshChildren() { NativeIUP.IupRefreshChildren(Handle); }

        public void Destroy() { NativeIUP.IupDestroy(Handle); }
        public void Detach() { NativeIUP.IupDetach(Handle); }
        public IupHandle Append(IupHandle child) { return new IupHandle(NativeIUP.IupAppend(Handle, IupHandle.GetCHandle(child))); }
        public IupHandle Insert(IupHandle ref_child, IupHandle child) { return new IupHandle(NativeIUP.IupInsert(Handle, IupHandle.GetCHandle(ref_child), IupHandle.GetCHandle(child))); }
        public IupHandle GetChild(int pos) { return new IupHandle(NativeIUP.IupGetChild(Handle, pos)); }
        public int GetChildPos(IupHandle child) { return NativeIUP.IupGetChildPos(Handle, IupHandle.GetCHandle(child)); }
        public int GetChildCount() { return NativeIUP.IupGetChildCount(Handle); }
        public IupHandle GetNextChild(IupHandle child) { return new IupHandle(NativeIUP.IupGetNextChild(Handle, IupHandle.GetCHandle(child))); }
        public IupHandle GetBrother() { return new IupHandle(NativeIUP.IupGetBrother(Handle)); }
        public IupHandle GetParent() { return new IupHandle(NativeIUP.IupGetParent(Handle)); }
        public IupHandle GetDialog() { return new IupHandle(NativeIUP.IupGetDialog(Handle)); }
        public IupHandle GetDialogChild(string name) { return new IupHandle(NativeIUP.IupGetDialogChild(Handle, name)); }

        /// <summary>
        /// Defines a set of attributes for an interface element.
        /// </summary>
        /// <param name="ih">Identifier of the interface element.</param>
        /// <param name="str">string with the attributes in the format "v1=a1, v2=a2,..." where vi is the name of an attribute and ai is its value.</param>
        /// <returns>return 'this' if all attributes were defined, or null otherwise.</returns>
        public IupHandle SetAttributes(string str) {  return IupHandle.Create(NativeIUP.IupSetAttributes(Handle, str)); }

        public string GetStrAttribute(string name) { return UTF8ToStr(NativeIUP.IupGetAttribute(Handle, name)); }
        public IntPtr GetAttribute(string name) { return NativeIUP.IupGetAttribute(Handle, name); }
        
        public string GetAttributes(IupHandle ih) { return UTF8ToStr(NativeIUP.IupGetAttributes(Handle)); }
        
        
        public int GetInt(string name) { return NativeIUP.IupGetInt(Handle, name); }
        public int GetInt2(string name) { return NativeIUP.IupGetInt2(Handle, name); }
        public int GetIntInt(string name, out int i1, out int i2) { return NativeIUP.IupGetIntInt(Handle, name, out i1, out i2); }
        public float GetFloat(string name) { return NativeIUP.IupGetFloat(Handle, name); }
        public void GetRGB(string name, out byte r, out byte g, out byte b) { NativeIUP.IupGetRGB(Handle, name, out r, out g, out b); }

        public void ResetAttribute(string name) { NativeIUP.IupResetAttribute(Handle, name); }
        public string[] GetAllAttributes(IupHandle ih)
        {
            IntPtr zero = IntPtr.Zero;
            int numattrib = NativeIUP.IupGetAllAttributes(Handle, ref zero, 0);
            IntPtr[] atts = new IntPtr[numattrib];

            if (numattrib == 0) return new string[0];
            numattrib = NativeIUP.IupGetAllAttributes(Handle, ref atts[0], numattrib);
            string[] res = new string[numattrib];

            for (int l = 0; l < atts.Length; l++)
                res[l] = UTF8ToStr(atts[l]);

            return res;
        }



      
        public override string ToString()
        {
            if (Handle == IntPtr.Zero)
                return "<null>";
            return GetClassName();
        }

        /// <summary>
        /// Moves an interface element from one position in the hierarchy tree to another. 
        /// Both new_parent and child must be mapped or unmapped at the same time. 
        /// If ref_child is Ihandle.Zero, then it will append the child to the new_parent. 
        /// If ref_child is NOT Ihandle.Zero then it will insert child before ref_child inside the new_parent.
        /// </summary>
        /// <returns>Result.Error on error, otherwise Result.NoError</returns>
        public Result Reparent(IupHandle new_parent, IupHandle ref_child) { return (Result)NativeIUP.IupReparent(Handle, IupHandle.GetCHandle(new_parent), IupHandle.GetCHandle(ref_child)); }
        public Result Popup(int x, int y) { return (Result)NativeIUP.IupPopup(Handle, x, y); } //TODO: DialogPos variants...
        public Result Show() { return (Result)NativeIUP.IupShow(Handle); }
        public Result ShowXY(int x, int y) { return (Result)NativeIUP.IupShowXY(Handle, x, y); }
		public Result ShowXY(DialogPos x, int y) { return (Result)NativeIUP.IupShowXY(Handle, (int)x, y); }
		public Result ShowXY(int x, DialogPos y) { return (Result)NativeIUP.IupShowXY(Handle, x, (int)y); }
		public Result ShowXY(DialogPos x, DialogPos y) { return (Result)NativeIUP.IupShowXY(Handle, (int)x, (int)y); }
        public Result Hide() { return (Result)NativeIUP.IupHide(Handle); }
        public Result Map() { return (Result)NativeIUP.IupMap(Handle); }
        public void Unmap() { NativeIUP.IupUnmap(Handle); }

        public void SetAttribute(string name, IntPtr value) { NativeIUP.IupSetAttribute(Handle, name, value); }
        public void SetStrAttribute(string name, string value) { NativeIUP.IupSetStrAttribute(Handle, name, value); }
        public void SetInt(string name,int value) { NativeIUP.IupSetInt(Handle,name, value); }
        public void SetFloat(string name, float value) { NativeIUP.IupSetFloat(Handle, name, value); }
        public void SetRGB(string name, byte r, byte g, byte b) { NativeIUP.IupSetRGB(Handle, name, r, g, b); }


        public void SetAttributeId(string name, int id, IntPtr value) { NativeIUP.IupSetAttributeId(Handle, name, id, value); }
        public void SetStrAttributeId(string name, int id, string value) { NativeIUP.IupSetStrAttributeId(Handle, name, id, value); }
        public void SetIntId(string name, int id, int value) { NativeIUP.IupSetIntId(Handle, name, id, value); }
        public void SetFloatId(string name, int id, float value) { NativeIUP.IupSetFloatId(Handle, name, id, value); }
        public void SetRGBId(string name, int id, byte r, byte g, byte b) { NativeIUP.IupSetRGBId(Handle, name, id, r, g, b); }



        public IntPtr GetAttributeId(string name, int id) { return NativeIUP.IupGetAttributeId(Handle, name, id); }
        public string GetStrAttributeId(string name, int id) { return UTF8ToStr(NativeIUP.IupGetAttributeId(Handle, name, id)); }
        public float GetFloatId(string name, int id) { return NativeIUP.IupGetFloatId(Handle, name, id); }
        public int GetIntId(string name, int id) { return NativeIUP.IupGetIntId(Handle, name, id); }
        public void GetRGBId(string name, int id, out byte r, out byte g, out byte b) { NativeIUP.IupGetRGBId(Handle, name, id, out r, out g, out b); }


        public void SetAttributeId2(string name, int lin, int col, IntPtr value) { NativeIUP.IupSetAttributeId2(Handle, name, lin, col, value); }
        public void SetStrAttributeId2(string name, int lin,int col, string value) { NativeIUP.IupSetStrAttributeId2(Handle, name, lin,col, value); }
        public void SetIntId2(string name, int lin,int col, int value) { NativeIUP.IupSetIntId2(Handle, name, lin,col, value); }
        public void SetFloatId2(string name, int lin,int col, float value) { NativeIUP.IupSetFloatId2(Handle, name, lin,col, value); }
        public void SetRGBId2(string name, int lin,int col, byte r, byte g, byte b) { NativeIUP.IupSetRGBId2(Handle, name, lin,col, r, g, b); }


        public IntPtr GetAttributeId2(string name, int lin, int col) {return NativeIUP.IupGetAttributeId2(Handle, name, lin, col); }
        public string GetStrAttributeId2(string name, int lin, int col) { return UTF8ToStr(NativeIUP.IupGetAttributeId2(Handle, name, lin, col)); }
        public int GetIntId2(string name, int lin, int col) { return NativeIUP.IupGetIntId2(Handle, name, lin, col); }
        public float GetFloatId2(string name, int lin, int col) { return NativeIUP.IupGetFloatId2(Handle, name, lin, col); }
        public void GetRGBId2(string name, int lin,int col, out byte r, out byte g, out byte b) { NativeIUP.IupGetRGBId2(Handle, name, lin,col, out r, out g, out b); }

        public IupHandle SetFocus(IupHandle ih) { return  new IupHandle(NativeIUP.IupSetFocus(Handle)); }
        public IupHandle PreviousField(IupHandle ih) { return new IupHandle(NativeIUP.IupPreviousField(Handle)); }
        public IupHandle NextField(IupHandle ih) { return new IupHandle(NativeIUP.IupNextField(Handle)); }

        public Delegate GetCallback(string name) { 
            Dictionary<string,Delegate> ctlmap;
            Delegate res=null;

            if (CallbackMap.TryGetValue(Handle, out ctlmap)) //get global delegate map
                ctlmap.TryGetValue(name, out res); //an try to fetch the result
            return res;
        } 

        public IntPtr SetCallback(string name, Delegate cb) { return NativeIUP.IupSetCallback(Handle, name, IupHandle.MapCallback(Handle, name, cb)); }
       // public Callback GetCallback(string name) { return NativeIUP.IupGetCallback(Handle, name); }

        public IupHandle SetHandle(string name) { return new IupHandle(NativeIUP.IupSetHandle(name, Handle)); }
        public string GetName() { return UTF8ToStr(NativeIUP.IupGetName(Handle)); }
        public void SetAttributeHandle(string name,IupHandle ih_named) { NativeIUP.IupSetAttributeHandle(Handle, name, IupHandle.GetCHandle(ih_named)); } 
        public IupHandle GetAttributeHandle(string name) { return new IupHandle(NativeIUP.IupGetAttributeHandle(Handle, name)); }
        public string GetClassName() { return UTF8ToStr(NativeIUP.IupGetClassName(Handle)); }
        public string GetClassType() { return UTF8ToStr(NativeIUP.IupGetClassType(Handle)); }
        public void SaveClassAttributes() { NativeIUP.IupSaveClassAttributes(Handle); }
        public void CopyClassAttributes(IupHandle dest_ih) { NativeIUP.IupCopyClassAttributes(Handle, dest_ih.Handle); }
        public bool ClassMatch(string classname) {return NativeIUP.IupClassMatch(Handle,classname)!=0;}
    }

    
}




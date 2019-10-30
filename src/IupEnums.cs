using System;
using System.Collections.Generic;
using System.Text;

namespace Tecgraf
{
    public enum MouseButton
    {
        Left='1',
        Middle='2',
        Right='3',
        Button4='4',
        Button5='5'
    }


    /// <summary>
    /// State for dialog in SHOW_CB callback
    /// </summary>
    public enum ShowState {
        Show,
        Restore,
        Minimize,
        Maximize,
        Hide
    }
    

    

    /// <summary>
    /// Callback return values
    /// </summary>
    public enum CBResult
    {
        Ignore = -1,
        Default = -2,
        Close = -3,
        Continue = -4
    }

    /// <summary>
    /// Popup and IupShowXY Parameter Values 
    /// </summary>
    public enum DialogPos:int
    {
        Center = 0xFFFF,  /* 65535 */
        Left = 0xFFFE,  /* 65534 */
        Right = 0xFFFD,  /* 65533 */
        MousePos = 0xFFFC,  /* 65532 */
        Current = 0xFFFB,  /* 65531 */
        CenterParent = 0xFFFA,  /* 65530 */
        Top = Left,
        Bottom = Right
    }

    public enum GetFileResult {
        NewFile=1,
        ExistingFile=0,
        Cancel=-1
    }

    /// <summary>
    /// Common return values.
    /// </summary>
    public enum Result
    {
        Error = 1,
        NoError = 0,
        Invalid = -1,
        Opened = -1,
    }

    
    public enum Normalize
    {
        No,
        Yes,
        Vertical,
        Horizontal
    }

    

    /*public enum VAlign
    {
        Top,
        Center,
        Bottom
    }

    public enum HAlign
    {
        Left,
        Center,
        Right
    }*/

    
    public enum ZOrder
    {
        Top,
        Bottom
    }

    public enum Scrollbar
    {
        Yes,
        No,
        Horizontal,
        Vertical
    }

    public enum Separator
    {
        Horizontal,
        Vertical
    }

    public enum Orientation
    {
        Horizontal,
        Vertical
    }

    public enum TabType
    {
        Left,
        Right,
        Bottom,
        Top
    }

    public enum TextFilter
    {
        None,
        LowerCase,
        UpperCase,
        Number
    }

    public static class TextMasks
    {
        public const string Int="[+/-]?/d+";
        public const string UInt="/d+";
        public const string Float="[+/-]?(/d+/.?/d*|/./d+)";
        public const string UFloat="(/d+/.?/d*|/./d+)";
        public const string EFLoat="[+/-]?(/d+/.?/d*|/./d+)([eE][+/-]?/d+)?";
    }

    public enum SpinAlign
    {
        Left,
        Right
    }

    public enum TreeNodeStatus
    {
        Unselected = 0,
        Selected = 1
    }


    public enum SaveImageFormat
    {
        Led,
        Lua,
        C
    }

    public enum RecordMode {
        RecordBinary=0,
        RecordText=1
    }
     
}

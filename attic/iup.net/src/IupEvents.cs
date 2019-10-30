using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Tecgraf
{
    
    
    //TODO: report TABCHANGEPOS_CB not documented in iupcbs.h


    /// <summary>
    /// Idle callback
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate CBResult CBIdle(
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(IupHandleMarshaller))] IupHandle sender);


    /// <summary>
    /// GLOBALKEYPRESS_CB
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void CBGlobalKeyPress(
        Key key, 
        [MarshalAs(UnmanagedType.Bool)] bool pressed);

    /// <summary>
    /// GLOBALMOTION_CB
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void CBGlobalMotion(
        int x, 
        int y,
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(IupStatusMarshaller))] ModStatus status);

    /// <summary>
    /// GLOBALBUTTON_CB
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void CBGlobalButton(
        MouseButton button, 
        [MarshalAs(UnmanagedType.Bool)]bool pressed, 
        int x, 
        int y,
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(IupStatusMarshaller))] ModStatus status);  
    
    /// <summary>
    /// GLOBALWHEEL_CB
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void CBGlobalWheel(
        float delta,
        int x,
        int y,
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(IupStatusMarshaller))] ModStatus status);

    /// <summary>
    /// Default callback (NCOLS_CB, NLINES_CB, and many more)
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate CBResult CBDefault(
        [MarshalAs(UnmanagedType.CustomMarshaler,MarshalTypeRef=typeof(IupHandleMarshaller))] IupHandle sender);

    /// <summary>
    /// SPIN_CB (Spin)
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate CBResult CBSpin(
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(IupHandleMarshaller))] IupHandle sender, 
        int incr);

    /// <summary>
    /// EXTENDED_CB (Colorbar)
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate CBResult CBExtended(
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(IupHandleMarshaller))] IupHandle sender, 
        int cell);


    /// <summary>
    /// RIGHTCLICK_CB (Tree)
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate CBResult CBRightClick(
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(IupHandleMarshaller))] IupHandle sender, 
        int id);

    /// <summary>
    /// BRANCHCLOSE_CB (Tree)
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate CBResult CBBranchClose(
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(IupHandleMarshaller))] IupHandle sender, 
        int id);

    /// <summary>
    /// BRANCHOPEN_CB (Tree)
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate CBResult CBBranchOpen(
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(IupHandleMarshaller))] IupHandle sender, 
        int id);

    /// <summary>
    /// EXECUTELEAF_CB (Tree)
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate CBResult CBExecuteLeaf(
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(IupHandleMarshaller))] IupHandle sender, 
        int id);

    /// <summary>
    /// SHOWRENAME_CB (Tree)
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate CBResult CBShowRename(
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(IupHandleMarshaller))] IupHandle sender, 
        int id);

    /// <summary>
    /// SHOW_CB
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate CBResult CBShow(
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(IupHandleMarshaller))] IupHandle sender, 
        ShowState state);

    /// <summary>
    /// TOGGLE_ACTION
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate CBResult CBAction_Toggle(
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(IupHandleMarshaller))] IupHandle sender, 
        [MarshalAs(UnmanagedType.Bool)] bool on);

    /// <summary>
    /// WIDTH_CB (Cells)
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int CBWidth(
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(IupHandleMarshaller))] IupHandle sender, 
        int column);

    /// <summary>
    /// HEIGHT_CB (Cells)
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int CBHeight(
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(IupHandleMarshaller))] IupHandle sender,
        int line);


    /// <summary>
    /// K_ANY
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate CBResult CBKAny(
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(IupHandleMarshaller))] IupHandle sender, 
        Key key);

    /// <summary>
    /// VSPAN_CB (Cells)
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate CBResult CBVSpan(
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(IupHandleMarshaller))] IupHandle sender, 
        int line, 
        int column);


    /// <summary>
    /// HSPAN_CB (Cells)
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate CBResult CBHSpan(
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(IupHandleMarshaller))] IupHandle sender,
        int line,
        int column);


    /// <summary>
    /// SCROLLING_CB (Cells)
    /// Called when the scrollbars are activated.
    /// </summary>
    /// <param name="sender">Identifier of the element that activated the event.</param>
    /// <param name="line">The first visible line index (in grid coordinates).</param>
    /// <param name="column">The first visible column index (in grid coordinates).</param>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate CBResult CBScrolling(
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(IupHandleMarshaller))] IupHandle sender,
        int line,
        int column);


    /// <summary>
    /// SWITCH_CB (Colorbar)
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate CBResult CBSwitch(
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(IupHandleMarshaller))] IupHandle sender,
        int primCell,
        int secCell);
    

    /// <summary>
    /// SELECT_CB (Colorbar)
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate CBResult CallbackSelectCB(
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(IupHandleMarshaller))] IupHandle sender,
        int cell,
        int type); // (TODO: create enum for IUP_PRIMARY (-1) / IUP_SECONDARY (-2) type)


    /// <summary>
    /// SELECTION_CB (Tree)
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate CBResult CBSelection(
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(IupHandleMarshaller))] IupHandle sender,
        int id,
        TreeNodeStatus status);

    /// <summary>
    /// DROPCHECK_CB (Matrix)
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate CBResult CBDropCheck(
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(IupHandleMarshaller))] IupHandle sender,
        int lin,
        int col);

    /// <summary>
    /// SCROLLTOP_CB (Matrix)
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate CBResult CBScrollTop (
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(IupHandleMarshaller))] IupHandle sender,
        int lin,
        int col);


    /// <summary>
    /// RESIZE_CB
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate CBResult CBResize(
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(IupHandleMarshaller))] IupHandle sender, 
        int width, 
        int height);


    /// <summary>
    /// TABCHANGEPOS_CB
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate CBResult CBTabChangePos(
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(IupHandleMarshaller))] IupHandle sender,
        int new_pos,
        int old_pos);


    /// <summary>
    /// MOUSEMOVE_CB (Matrix)
    /// sender: Identifier of the matrix interacting with the user.
    /// lin, col: Coordinates of the cell that the mouse cursor is currently on.
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate CBResult CBMouseMove_Matrix(
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(IupHandleMarshaller))] IupHandle sender,
        int lin,
        int col);

    /// <summary>
    /// ENTERITEM_CB (Matrix)
    /// sender: Identifier of the matrix interacting with the user.
    /// lin, col: Coordinates of the cell that the mouse cursor is currently on.
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate CBResult CBEnterItem(
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(IupHandleMarshaller))] IupHandle sender,
        int lin,
        int col);

    /// <summary>
    /// Delegate for LEAVEITEM_CB (matrix)
    /// </summary>
    /// <param name="sender">Identifier of the matrix interacting with the user.</param>
    /// <param name="lin">Line index of the cell the mouse cursor is currently on.</param>
    /// <param name="col">Column index of the cell the mouse cursor is currently on.</param>
    /// <returns>CBResult.Ignore prevents the current cell from changing, but this will 
    /// not work when the matrix is losing focus.  If you try to move to beyond matrix 
    /// borders the cell will lose focus and then get it again, so LEAVEITEM_CB and ENTERITEM_CB will be called.</returns>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate CBResult CBLeaveItem(
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(IupHandleMarshaller))] IupHandle sender,
        int lin,
        int col);

    /// <summary>
    /// CARET_CB
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate CBResult CBCaret(
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(IupHandleMarshaller))] IupHandle sender,
        int width,
        int height); //TODO: this has one more argument (pos) ? Error in header file, correct in docs.


    /// <summary>
    /// KEYPRESS_CB
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate CBResult CBKeyPress(
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(IupHandleMarshaller))] IupHandle sender, 
        Key key,
        [MarshalAs(UnmanagedType.Bool)]bool pressed);  


    /// <summary>
    /// TRAYCLICK_CB (Dialog)
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate CBResult CBTrayClick(
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(IupHandleMarshaller))] IupHandle sender, 
        int button,
        [MarshalAs(UnmanagedType.Bool)]bool pressed,
        [MarshalAs(UnmanagedType.Bool)]bool doubleclick);

    


    /// <summary>
    /// EDITION_CB (Matrix)
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate CBResult CBEdititon(
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(IupHandleMarshaller))] IupHandle sender,
        int line,
        int column,
        [MarshalAs(UnmanagedType.Bool)]bool mode,
        [MarshalAs(UnmanagedType.Bool)]bool update  //TODO: report to scuri this is not in callbacks header
    );

    

    /// <summary>
    /// DRAGDROP_CB
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate CBResult CBDragDrop(
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(IupHandleMarshaller))] IupHandle sender, 
        int drag_id,
        int drop_id, 
        [MarshalAs(UnmanagedType.Bool)] bool isshift, 
        [MarshalAs(UnmanagedType.Bool)] bool iscontrol);


    /// <summary>
    /// Old DRAW_CB
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate CBResult CBDraw_Old(
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(IupHandleMarshaller))] IupHandle sender,
        int lin,
        int col,
        int x1,
        int x2,
        int y1,
        int y2);

    /// <summary>
    /// DRAW_CB
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate CBResult CBDraw(
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(IupHandleMarshaller))] IupHandle sender, 
        int lin, 
        int col,
        int x1, 
        int x2, 
        int y1,
        int y2,
        IntPtr cdcanvas); //TODO: forward this as real canvas when we can do that

    
    /// <summary>
    /// CANVAS_ACTION
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate CBResult CBAction_Canvas(
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(IupHandleMarshaller))] IupHandle sender, 
        float posx,
        float posy);

    

    /// <summary>
    /// SCROLL_CB  
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)] 
    public delegate CBResult CBScroll(
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(IupHandleMarshaller))] IupHandle sender, 
        int op,  //TODO: make op an enum
        float posx,
        float posy);


    /// <summary>
    /// WHEEL_CB
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate CBResult CBWheel(
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(IupHandleMarshaller))] IupHandle sender, 
        float delta, 
        int x, 
        int y,
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(IupStatusMarshaller))] ModStatus status); 


    /// <summary>
    /// DRAGDATA_CB
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate CBResult CBDragData(
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(IupHandleMarshaller))] IupHandle sender, 
        string type,
        IntPtr data,
        int size
    );

    /// <summary>
    /// DROPDATA_CB
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate CBResult CBDropData(
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(IupHandleMarshaller))] IupHandle sender, 
        string type, 
        IntPtr data, 
        int size, 
        int x, 
        int y);

    /// <summary>
    /// DROPFILES_CB
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate CBResult CBDropFiles(
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(IupHandleMarshaller))] IupHandle sender, 
        string filename, 
        int num, 
        int x, 
        int y);


    /// <summary>
    /// DROP_CB
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate CBResult CBDrop(
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(IupHandleMarshaller))] IupHandle sender,
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(IupHandleMarshaller))] IupHandle drop, 
        int line, 
        int column);  

    /// <summary>
    /// TABCHANGE_CB (Tabs)
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate CBResult CBTabChange(
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(IupHandleMarshaller))] IupHandle sender,
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(IupHandleMarshaller))] IupHandle new_tab,
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(IupHandleMarshaller))] IupHandle old_tab);  


    
    
    /// <summary>
    /// FILE_CB (FileDlg)
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate CBResult CBFile(
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(IupHandleMarshaller))] IupHandle sender, 
        string filename,
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(IupStatusMarshaller))] ModStatus status);  //TODO: change to enum, needs custom marshaller

    /// <summary>
    /// MULTISELECT_CB (List)
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate CBResult CBMultiSelect(
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(IupHandleMarshaller))] IupHandle sender, 
        string value);

    /// <summary>
    /// COPYDATA_CB (Dialog)
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate CBResult CBCopyData(
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(IupHandleMarshaller))] IupHandle sender, 
        string cmdLine, 
        int size);

    /// <summary>
    /// RENAME_CB (Tree)
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate CBResult CBRename(
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(IupHandleMarshaller))] IupHandle sender, 
        int id, 
        string title);  

     /// <summary>
    /// EDIT_CB (List)
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate CBResult CBEdit(
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(IupHandleMarshaller))] IupHandle sender, 
        int ch, 
        string newtext);  
   
    /// <summary>
    /// TEXT_ACTION
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate CBResult CBAction_Text(
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(IupHandleMarshaller))] IupHandle sender, 
        int ch, 
        string newtext);  

    /// <summary>
    /// LIST_ACTION (List)
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate CBResult CBAction_List(
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(IupHandleMarshaller))] IupHandle sender, 
        string text, 
        int item, 
        [MarshalAs(UnmanagedType.Bool)] bool state);

    /// <summary>
    /// VALUE_EDIT_CB
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate CBResult CBValueEdit(
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(IupHandleMarshaller))] IupHandle sender, 
        int line, 
        int column, 
        string newvalue);


     /// <summary>
    /// CLICK_CB (Matrix)
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate CBResult CBClick(
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(IupHandleMarshaller))] IupHandle sender, 
        int line, 
        int column,
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(IupStatusMarshaller))] ModStatus status);


    /// <summary>
    /// MOTION_CB
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate CBResult CBMotion(
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(IupHandleMarshaller))] IupHandle sender, 
        int x, 
        int y, 
        [MarshalAs(UnmanagedType.CustomMarshaler,MarshalTypeRef = typeof(IupStatusMarshaller))] ModStatus status); 
  

    /// <summary>
    /// TOUCH_CB 
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate CBResult CBTouch(
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(IupHandleMarshaller))] IupHandle sender, 
        int id, 
        int x, 
        int y, 
        string state);  //TODO: use state class

    /// <summary>
    /// DBLCLICK_CB  (List)
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate CBResult CBDblClick( //TODO: wrongly documented in header file, do NOT take 3 integers
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(IupHandleMarshaller))] IupHandle sender, 
        int item, 
        string text); 

    /// <summary>
    /// MATRIX_ACTION (Matrix)
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate CBResult CBAction_Matrix(
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(IupHandleMarshaller))] IupHandle sender, 
        int key,
        int line, 
        int column, 
        [MarshalAs(UnmanagedType.Bool)] bool edition, 
        string value);


    
    /// <summary>
    /// MOUSEMOTION_CB (Cells)
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate CBResult CBMouseMotion(
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(IupHandleMarshaller))] IupHandle sender, 
        int line, 
        int column, 
        int x, 
        int y,
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(IupStatusMarshaller))] ModStatus status); 

    /// <summary>
    /// BUTTON_CB
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate CBResult CBButton(
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(IupHandleMarshaller))] IupHandle sender, 
        MouseButton button, 
        [MarshalAs(UnmanagedType.Bool)]bool pressed, 
        int x, 
        int y,
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(IupStatusMarshaller))] ModStatus status);


    /// <summary>
    /// MOUSECLICK_CB (Matrix)
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate CBResult CBMouseClick(
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(IupHandleMarshaller))] IupHandle sender, 
        MouseButton button, 
        [MarshalAs(UnmanagedType.Bool)] bool pressed, 
        int line, 
        int column, 
        int x, 
        int y,
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(IupStatusMarshaller))] ModStatus status);  

    /// <summary>
    /// MULTISELECTION_CB
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate CBResult CBMultiSelection(
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(IupHandleMarshaller))] IupHandle sender, 
        IntPtr ids,
        int n);

     /// <summary>
    /// MULTIUNSELECTION_CB
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate CBResult CBMultiUnselection(
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(IupHandleMarshaller))] IupHandle sender, 
        IntPtr ids,
        int n);


    /// <summary>
    /// MOUSEMOVE_CB (Dial)
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate CBResult CBMouseMove_Dial(
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(IupHandleMarshaller))] IupHandle sender, 
        double angle);  


    /// <summary>
    /// BUTTON_PRESS_CB (Dial)
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate CBResult CBButtonPress(
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(IupHandleMarshaller))] IupHandle sender, 
        double angle);  

    /// <summary>
    /// BUTTON_RELEASE_CB (Dial)
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate CBResult CBButtonRelease(
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(IupHandleMarshaller))] IupHandle sender, 
        double angle);  


    /// <summary>
    /// FGCOLOR_CB (Matrix)
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate CBResult CBFGColor(
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(IupHandleMarshaller))] IupHandle sender, 
        int lin, 
        int col, 
        ref int red, 
        ref int green, 
        ref int blue);

    /// <summary>
    /// BGCOLOR_CB (Matrix)
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate CBResult CBBGColor(
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(IupHandleMarshaller))] IupHandle sender, 
        int lin, 
        int col, 
        ref int red, 
        ref int green, 
        ref int blue);  


    /// <summary>
    /// DROPSELECT_CB (Matrix)
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate CBResult CBDropSelect(
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(IupHandleMarshaller))] IupHandle sender, 
        int line, 
        int column,
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(IupHandleMarshaller))] IupHandle drop, 
        string text, 
        int index, 
        [MarshalAs(UnmanagedType.Bool)] bool selected);


    /// <summary>
    /// DRAG_CB  (ColorBrowser)
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate CBResult CBDrag([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(IupHandleMarshaller))] IupHandle sender, byte red, byte green, byte blue);


    /// <summary>
    /// CHANGE_CB  (ColorBrowser)
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate CBResult CBChange([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(IupHandleMarshaller))] IupHandle sender, byte red, byte green, byte blue);


    /// <summary>
    /// MULTITOUCH_CB (Tuio client)
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate CBResult CBMultiTouch(
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(IupHandleMarshaller))] IupHandle sender, 
        int count, 
        IntPtr pid, 
        IntPtr px, 
        IntPtr py, 
        IntPtr pstate);
    

    /// <summary>
    /// VALUE_CB (Matrix)
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate string CBValue(
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(IupHandleMarshaller))] IupHandle sender, 
        int line, 
        int column);

    /// <summary>
    /// CELL_CB (Colorbar)
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate string CBCell(
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(IupHandleMarshaller))] IupHandle sender,
        int cellindex); //TODO: try out string return callbacks

    
   

    /// <summary>
    /// Class to marshal a iup modifier key status string to our ModStatus class
    /// </summary>
    internal class IupStatusMarshaller : ICustomMarshaler
    {

        static IupStatusMarshaller marshaler = new IupStatusMarshaller();
        public static ICustomMarshaler GetInstance(String cookie)
        {
            return marshaler;
        }


        public void CleanUpManagedData(object ManagedObj)
        {
        }

        public void CleanUpNativeData(IntPtr pNativeData)
        {
        }

        static int ptrSize = 0;
        public int GetNativeDataSize()
        {
            //compute size of pointer just once. Can differ in 32/64 bit.
            if (ptrSize == 0)
                ptrSize = Marshal.SizeOf(typeof(IntPtr));
            return ptrSize;
        }

        public IntPtr MarshalManagedToNative(object ManagedObj)
        {
            return IntPtr.Zero; //not supported to return a ModStatus to C
        }

        public object MarshalNativeToManaged(IntPtr pNativeData)
        {
            string res=Marshal.PtrToStringAnsi(pNativeData);
            return new ModStatus(res);
        }
    }

    public class ModStatus
    {
        private string iupstatus;   //string as gotten from iup

        internal ModStatus(string evtstatus) {
            this.iupstatus=evtstatus;
        }

        /// <summary>
        /// True if shift key is pressed.
        /// </summary>
        public bool Shift { get { return iupstatus[0] == 'S'; } }

        /// <summary>
        /// True if control key is pressed.
        /// </summary>
        public bool Control { get { return iupstatus[1] == 'C'; } }

        /// <summary>
        /// True if left mouse button is pressed.
        /// </summary>
        public bool Button1 { get { return iupstatus[2] == '1'; } }

        /// <summary>
        /// True if middle mouse button is pressed.
        /// </summary>
        public bool Button2 { get { return iupstatus[3] == '2'; } }

        /// <summary>
        /// True if right mouse button is pressed.
        /// </summary>
        public bool Button3 { get { return iupstatus[4] == '3'; } }

        /// <summary>
        /// True if a doublke click triggered the event.
        /// </summary>
        public bool Double { get { return iupstatus[5] == 'D'; } }

        /// <summary>
        /// True if alt key is pressed.
        /// </summary>
        public bool Alt { get { return iupstatus[6] == 'A'; } }

        /// <summary>
        /// True if sys key is pressed (windows key in windows).
        /// </summary>
        public bool Sys { get { return iupstatus[7] == 'Y'; } }

        /// <summary>
        /// True if mouse button 4 is pressed.
        /// </summary>
        public bool Button4 { get { return iupstatus[8] == '4'; } }

        /// <summary>
        /// True if mouse button 5 is pressed.
        /// </summary>
        public bool Button5 { get { return iupstatus[9] == '5'; } }
    }

}

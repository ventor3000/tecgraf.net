using System;
using System.Text;
using System.Runtime.InteropServices;

internal static class iup_c {

  static DynamicLinker dynlink = new DynamicLinker("iup");

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate int IupOpenDelegate(IntPtr argv,IntPtr argc);
  internal static IupOpenDelegate IupOpen = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupOpen"),typeof(IupOpenDelegate)) as IupOpenDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate void IupCloseDelegate();
  internal static IupCloseDelegate IupClose = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupClose"),typeof(IupCloseDelegate)) as IupCloseDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate int IupMainLoopDelegate();
  internal static IupMainLoopDelegate IupMainLoop = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupMainLoop"),typeof(IupMainLoopDelegate)) as IupMainLoopDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate int IupLoopStepDelegate();
  internal static IupLoopStepDelegate IupLoopStep = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupLoopStep"),typeof(IupLoopStepDelegate)) as IupLoopStepDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate int IupLoopStepWaitDelegate();
  internal static IupLoopStepWaitDelegate IupLoopStepWait = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupLoopStepWait"),typeof(IupLoopStepWaitDelegate)) as IupLoopStepWaitDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate int IupMainLoopLevelDelegate();
  internal static IupMainLoopLevelDelegate IupMainLoopLevel = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupMainLoopLevel"),typeof(IupMainLoopLevelDelegate)) as IupMainLoopLevelDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate void IupFlushDelegate();
  internal static IupFlushDelegate IupFlush = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupFlush"),typeof(IupFlushDelegate)) as IupFlushDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate void IupExitLoopDelegate();
  internal static IupExitLoopDelegate IupExitLoop = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupExitLoop"),typeof(IupExitLoopDelegate)) as IupExitLoopDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate void IupUpdateDelegate(IntPtr ih);
  internal static IupUpdateDelegate IupUpdate = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupUpdate"),typeof(IupUpdateDelegate)) as IupUpdateDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate void IupUpdateChildrenDelegate(IntPtr ih);
  internal static IupUpdateChildrenDelegate IupUpdateChildren = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupUpdateChildren"),typeof(IupUpdateChildrenDelegate)) as IupUpdateChildrenDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate void IupRedrawDelegate(IntPtr ih,int children);
  internal static IupRedrawDelegate IupRedraw = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupRedraw"),typeof(IupRedrawDelegate)) as IupRedrawDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate void IupRefreshDelegate(IntPtr ih);
  internal static IupRefreshDelegate IupRefresh = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupRefresh"),typeof(IupRefreshDelegate)) as IupRefreshDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate void IupRefreshChildrenDelegate(IntPtr ih);
  internal static IupRefreshChildrenDelegate IupRefreshChildren = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupRefreshChildren"),typeof(IupRefreshChildrenDelegate)) as IupRefreshChildrenDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate IntPtr IupMapFontDelegate(string iupfont);
  internal static IupMapFontDelegate IupMapFont = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupMapFont"),typeof(IupMapFontDelegate)) as IupMapFontDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate IntPtr IupUnMapFontDelegate(string driverfont);
  internal static IupUnMapFontDelegate IupUnMapFont = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupUnMapFont"),typeof(IupUnMapFontDelegate)) as IupUnMapFontDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate int IupHelpDelegate(string url);
  internal static IupHelpDelegate IupHelp = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupHelp"),typeof(IupHelpDelegate)) as IupHelpDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate IntPtr IupLoadDelegate(string filename);
  internal static IupLoadDelegate IupLoad = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupLoad"),typeof(IupLoadDelegate)) as IupLoadDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate IntPtr IupLoadBufferDelegate(string buffer);
  internal static IupLoadBufferDelegate IupLoadBuffer = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupLoadBuffer"),typeof(IupLoadBufferDelegate)) as IupLoadBufferDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate IntPtr IupVersionDelegate();
  internal static IupVersionDelegate IupVersion = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupVersion"),typeof(IupVersionDelegate)) as IupVersionDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate IntPtr IupVersionDateDelegate();
  internal static IupVersionDateDelegate IupVersionDate = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupVersionDate"),typeof(IupVersionDateDelegate)) as IupVersionDateDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate int IupVersionNumberDelegate();
  internal static IupVersionNumberDelegate IupVersionNumber = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupVersionNumber"),typeof(IupVersionNumberDelegate)) as IupVersionNumberDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate void IupSetLanguageDelegate(string lng);
  internal static IupSetLanguageDelegate IupSetLanguage = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupSetLanguage"),typeof(IupSetLanguageDelegate)) as IupSetLanguageDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate IntPtr IupGetLanguageDelegate();
  internal static IupGetLanguageDelegate IupGetLanguage = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupGetLanguage"),typeof(IupGetLanguageDelegate)) as IupGetLanguageDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate void IupDestroyDelegate(IntPtr ih);
  internal static IupDestroyDelegate IupDestroy = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupDestroy"),typeof(IupDestroyDelegate)) as IupDestroyDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate void IupDetachDelegate(IntPtr child);
  internal static IupDetachDelegate IupDetach = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupDetach"),typeof(IupDetachDelegate)) as IupDetachDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate IntPtr IupAppendDelegate(IntPtr ih,IntPtr child);
  internal static IupAppendDelegate IupAppend = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupAppend"),typeof(IupAppendDelegate)) as IupAppendDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate IntPtr IupInsertDelegate(IntPtr ih,IntPtr ref_child,IntPtr child);
  internal static IupInsertDelegate IupInsert = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupInsert"),typeof(IupInsertDelegate)) as IupInsertDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate IntPtr IupGetChildDelegate(IntPtr ih,int pos);
  internal static IupGetChildDelegate IupGetChild = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupGetChild"),typeof(IupGetChildDelegate)) as IupGetChildDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate int IupGetChildPosDelegate(IntPtr ih,IntPtr child);
  internal static IupGetChildPosDelegate IupGetChildPos = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupGetChildPos"),typeof(IupGetChildPosDelegate)) as IupGetChildPosDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate int IupGetChildCountDelegate(IntPtr ih);
  internal static IupGetChildCountDelegate IupGetChildCount = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupGetChildCount"),typeof(IupGetChildCountDelegate)) as IupGetChildCountDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate IntPtr IupGetNextChildDelegate(IntPtr ih,IntPtr child);
  internal static IupGetNextChildDelegate IupGetNextChild = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupGetNextChild"),typeof(IupGetNextChildDelegate)) as IupGetNextChildDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate IntPtr IupGetBrotherDelegate(IntPtr ih);
  internal static IupGetBrotherDelegate IupGetBrother = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupGetBrother"),typeof(IupGetBrotherDelegate)) as IupGetBrotherDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate IntPtr IupGetParentDelegate(IntPtr ih);
  internal static IupGetParentDelegate IupGetParent = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupGetParent"),typeof(IupGetParentDelegate)) as IupGetParentDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate IntPtr IupGetDialogDelegate(IntPtr ih);
  internal static IupGetDialogDelegate IupGetDialog = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupGetDialog"),typeof(IupGetDialogDelegate)) as IupGetDialogDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate IntPtr IupGetDialogChildDelegate(IntPtr ih,string name);
  internal static IupGetDialogChildDelegate IupGetDialogChild = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupGetDialogChild"),typeof(IupGetDialogChildDelegate)) as IupGetDialogChildDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate int IupReparentDelegate(IntPtr ih,IntPtr new_pareent,IntPtr ref_child);
  internal static IupReparentDelegate IupReparent = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupReparent"),typeof(IupReparentDelegate)) as IupReparentDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate int IupPopupDelegate(IntPtr ih,int x,int y);
  internal static IupPopupDelegate IupPopup = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupPopup"),typeof(IupPopupDelegate)) as IupPopupDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate int IupShowDelegate(IntPtr ih);
  internal static IupShowDelegate IupShow = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupShow"),typeof(IupShowDelegate)) as IupShowDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate int IupShowXYDelegate(IntPtr ih,int x,int y);
  internal static IupShowXYDelegate IupShowXY = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupShowXY"),typeof(IupShowXYDelegate)) as IupShowXYDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate int IupHideDelegate(IntPtr ih);
  internal static IupHideDelegate IupHide = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupHide"),typeof(IupHideDelegate)) as IupHideDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate int IupMapDelegate(IntPtr ih);
  internal static IupMapDelegate IupMap = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupMap"),typeof(IupMapDelegate)) as IupMapDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate void IupUnmapDelegate(IntPtr ih);
  internal static IupUnmapDelegate IupUnmap = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupUnmap"),typeof(IupUnmapDelegate)) as IupUnmapDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate void IupSetAttributeDelegate(IntPtr ih,string name,IntPtr value);
  internal static IupSetAttributeDelegate IupSetAttribute = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupSetAttribute"),typeof(IupSetAttributeDelegate)) as IupSetAttributeDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate void IupStoreAttributeDelegate(IntPtr ih,string name,string value);
  internal static IupStoreAttributeDelegate IupStoreAttribute = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupStoreAttribute"),typeof(IupStoreAttributeDelegate)) as IupStoreAttributeDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate IntPtr IupSetAttributesDelegate(IntPtr ih,string str);
  internal static IupSetAttributesDelegate IupSetAttributes = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupSetAttributes"),typeof(IupSetAttributesDelegate)) as IupSetAttributesDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate IntPtr IupGetAttributeDelegate(IntPtr ih,string name);
  internal static IupGetAttributeDelegate IupGetAttribute = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupGetAttribute"),typeof(IupGetAttributeDelegate)) as IupGetAttributeDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate IntPtr IupGetAttributesDelegate(IntPtr ih);
  internal static IupGetAttributesDelegate IupGetAttributes = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupGetAttributes"),typeof(IupGetAttributesDelegate)) as IupGetAttributesDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate int IupGetIntDelegate(IntPtr ih,string name);
  internal static IupGetIntDelegate IupGetInt = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupGetInt"),typeof(IupGetIntDelegate)) as IupGetIntDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate int IupGetInt2Delegate(IntPtr ih,string name);
  internal static IupGetInt2Delegate IupGetInt2 = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupGetInt2"),typeof(IupGetInt2Delegate)) as IupGetInt2Delegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate int IupGetIntIntDelegate(IntPtr ih,string name,out int i1,out int i2);
  internal static IupGetIntIntDelegate IupGetIntInt = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupGetIntInt"),typeof(IupGetIntIntDelegate)) as IupGetIntIntDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate float IupGetFloatDelegate(IntPtr ih,string name);
  internal static IupGetFloatDelegate IupGetFloat = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupGetFloat"),typeof(IupGetFloatDelegate)) as IupGetFloatDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate void IupResetAttributeDelegate(IntPtr ih,string name);
  internal static IupResetAttributeDelegate IupResetAttribute = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupResetAttribute"),typeof(IupResetAttributeDelegate)) as IupResetAttributeDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate int IupGetAllAttributesDelegate(IntPtr ih,ref IntPtr names,int n);
  internal static IupGetAllAttributesDelegate IupGetAllAttributes = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupGetAllAttributes"),typeof(IupGetAllAttributesDelegate)) as IupGetAllAttributesDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate void IupSetAttributeIdDelegate(IntPtr ih,string name,int id,IntPtr value);
  internal static IupSetAttributeIdDelegate IupSetAttributeId = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupSetAttributeId"),typeof(IupSetAttributeIdDelegate)) as IupSetAttributeIdDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate void IupStoreAttributeIdDelegate(IntPtr ih,string name,int id,string value);
  internal static IupStoreAttributeIdDelegate IupStoreAttributeId = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupStoreAttributeId"),typeof(IupStoreAttributeIdDelegate)) as IupStoreAttributeIdDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate IntPtr IupGetAttributeIdDelegate(IntPtr ih,string name,int id);
  internal static IupGetAttributeIdDelegate IupGetAttributeId = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupGetAttributeId"),typeof(IupGetAttributeIdDelegate)) as IupGetAttributeIdDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate float IupGetFloatIdDelegate(IntPtr ih,string name,int id);
  internal static IupGetFloatIdDelegate IupGetFloatId = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupGetFloatId"),typeof(IupGetFloatIdDelegate)) as IupGetFloatIdDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate int IupGetIntIdDelegate(IntPtr ih,string name,int id);
  internal static IupGetIntIdDelegate IupGetIntId = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupGetIntId"),typeof(IupGetIntIdDelegate)) as IupGetIntIdDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate void IupSetAttributeId2Delegate(IntPtr ih,string name,int lin,int col,IntPtr value);
  internal static IupSetAttributeId2Delegate IupSetAttributeId2 = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupSetAttributeId2"),typeof(IupSetAttributeId2Delegate)) as IupSetAttributeId2Delegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate void IupStoreAttributeId2Delegate(IntPtr ih,string name,int lin,int col,string value);
  internal static IupStoreAttributeId2Delegate IupStoreAttributeId2 = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupStoreAttributeId2"),typeof(IupStoreAttributeId2Delegate)) as IupStoreAttributeId2Delegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate IntPtr IupGetAttributeId2Delegate(IntPtr ih,string name,int lin,int col);
  internal static IupGetAttributeId2Delegate IupGetAttributeId2 = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupGetAttributeId2"),typeof(IupGetAttributeId2Delegate)) as IupGetAttributeId2Delegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate int IupGetIntId2Delegate(IntPtr ih,string name,int lin,int col);
  internal static IupGetIntId2Delegate IupGetIntId2 = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupGetIntId2"),typeof(IupGetIntId2Delegate)) as IupGetIntId2Delegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate float IupGetFloatId2Delegate(IntPtr ih,string name,int lin,int col);
  internal static IupGetFloatId2Delegate IupGetFloatId2 = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupGetFloatId2"),typeof(IupGetFloatId2Delegate)) as IupGetFloatId2Delegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate void IupSetGlobalDelegate(string name,IntPtr value);
  internal static IupSetGlobalDelegate IupSetGlobal = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupSetGlobal"),typeof(IupSetGlobalDelegate)) as IupSetGlobalDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate void IupStoreGlobalDelegate(string name,string value);
  internal static IupStoreGlobalDelegate IupStoreGlobal = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupStoreGlobal"),typeof(IupStoreGlobalDelegate)) as IupStoreGlobalDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate IntPtr IupGetGlobalDelegate(string name);
  internal static IupGetGlobalDelegate IupGetGlobal = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupGetGlobal"),typeof(IupGetGlobalDelegate)) as IupGetGlobalDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate IntPtr IupSetFocusDelegate(IntPtr ih);
  internal static IupSetFocusDelegate IupSetFocus = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupSetFocus"),typeof(IupSetFocusDelegate)) as IupSetFocusDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate IntPtr IupGetFocusDelegate();
  internal static IupGetFocusDelegate IupGetFocus = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupGetFocus"),typeof(IupGetFocusDelegate)) as IupGetFocusDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate IntPtr IupPreviousFieldDelegate(IntPtr ih);
  internal static IupPreviousFieldDelegate IupPreviousField = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupPreviousField"),typeof(IupPreviousFieldDelegate)) as IupPreviousFieldDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate IntPtr IupNextFieldDelegate(IntPtr ih);
  internal static IupNextFieldDelegate IupNextField = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupNextField"),typeof(IupNextFieldDelegate)) as IupNextFieldDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate IntPtr IupGetCallbackDelegate(IntPtr ih,string name);
  internal static IupGetCallbackDelegate IupGetCallback = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupGetCallback"),typeof(IupGetCallbackDelegate)) as IupGetCallbackDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate IntPtr IupSetCallbackDelegate(IntPtr ih,string name,IntPtr func);
  internal static IupSetCallbackDelegate IupSetCallback = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupSetCallback"),typeof(IupSetCallbackDelegate)) as IupSetCallbackDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate IntPtr IupGetFunctionDelegate(string name);
  internal static IupGetFunctionDelegate IupGetFunction = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupGetFunction"),typeof(IupGetFunctionDelegate)) as IupGetFunctionDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate IntPtr IupSetFunctionDelegate(string name,IntPtr func);
  internal static IupSetFunctionDelegate IupSetFunction = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupSetFunction"),typeof(IupSetFunctionDelegate)) as IupSetFunctionDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate IntPtr IupGetActionNameDelegate();
  internal static IupGetActionNameDelegate IupGetActionName = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupGetActionName"),typeof(IupGetActionNameDelegate)) as IupGetActionNameDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate IntPtr IupGetHandleDelegate(string name);
  internal static IupGetHandleDelegate IupGetHandle = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupGetHandle"),typeof(IupGetHandleDelegate)) as IupGetHandleDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate IntPtr IupSetHandleDelegate(string name,IntPtr ih);
  internal static IupSetHandleDelegate IupSetHandle = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupSetHandle"),typeof(IupSetHandleDelegate)) as IupSetHandleDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate int IupGetAllNamesDelegate(ref IntPtr names,int n);
  internal static IupGetAllNamesDelegate IupGetAllNames = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupGetAllNames"),typeof(IupGetAllNamesDelegate)) as IupGetAllNamesDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate int IupGetAllDialogsDelegate(ref IntPtr names,int n);
  internal static IupGetAllDialogsDelegate IupGetAllDialogs = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupGetAllDialogs"),typeof(IupGetAllDialogsDelegate)) as IupGetAllDialogsDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate IntPtr IupGetNameDelegate(IntPtr ih);
  internal static IupGetNameDelegate IupGetName = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupGetName"),typeof(IupGetNameDelegate)) as IupGetNameDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate void IupSetAttributeHandleDelegate(IntPtr ih,string name,IntPtr ih_named);
  internal static IupSetAttributeHandleDelegate IupSetAttributeHandle = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupSetAttributeHandle"),typeof(IupSetAttributeHandleDelegate)) as IupSetAttributeHandleDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate IntPtr IupGetAttributeHandleDelegate(IntPtr ih,string name);
  internal static IupGetAttributeHandleDelegate IupGetAttributeHandle = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupGetAttributeHandle"),typeof(IupGetAttributeHandleDelegate)) as IupGetAttributeHandleDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate IntPtr IupGetClassNameDelegate(IntPtr ih);
  internal static IupGetClassNameDelegate IupGetClassName = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupGetClassName"),typeof(IupGetClassNameDelegate)) as IupGetClassNameDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate IntPtr IupGetClassTypeDelegate(IntPtr ih);
  internal static IupGetClassTypeDelegate IupGetClassType = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupGetClassType"),typeof(IupGetClassTypeDelegate)) as IupGetClassTypeDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate int IupGetAllClassesDelegate(ref IntPtr names, int n);
  internal static IupGetAllClassesDelegate IupGetAllClasses = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupGetAllClasses"),typeof(IupGetAllClassesDelegate)) as IupGetAllClassesDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate int IupGetClassAttributesDelegate(string classname,ref IntPtr names,int n);
  internal static IupGetClassAttributesDelegate IupGetClassAttributes = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupGetClassAttributes"),typeof(IupGetClassAttributesDelegate)) as IupGetClassAttributesDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate int IupGetClassCallbacksDelegate(string classname,ref IntPtr names, int n);
  internal static IupGetClassCallbacksDelegate IupGetClassCallbacks = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupGetClassCallbacks"),typeof(IupGetClassCallbacksDelegate)) as IupGetClassCallbacksDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate void IupSaveClassAttributesDelegate(IntPtr ih);
  internal static IupSaveClassAttributesDelegate IupSaveClassAttributes = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupSaveClassAttributes"),typeof(IupSaveClassAttributesDelegate)) as IupSaveClassAttributesDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate void IupCopyClassAttributesDelegate(IntPtr src_ih,IntPtr dst_ih);
  internal static IupCopyClassAttributesDelegate IupCopyClassAttributes = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupCopyClassAttributes"),typeof(IupCopyClassAttributesDelegate)) as IupCopyClassAttributesDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate void IupSetClassDefaultAttributeDelegate(string classname,string name,string value);
  internal static IupSetClassDefaultAttributeDelegate IupSetClassDefaultAttribute = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupSetClassDefaultAttribute"),typeof(IupSetClassDefaultAttributeDelegate)) as IupSetClassDefaultAttributeDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate IntPtr IupCreateDelegate(string classname);
  internal static IupCreateDelegate IupCreate = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupCreate"),typeof(IupCreateDelegate)) as IupCreateDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate IntPtr IupCreatevDelegate(string classname,ref IntPtr _params);
  internal static IupCreatevDelegate IupCreatev = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupCreatev"),typeof(IupCreatevDelegate)) as IupCreatevDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate int IupSaveImageAsTextDelegate(IntPtr ih,string filename,string format,string name);
  internal static IupSaveImageAsTextDelegate IupSaveImageAsText = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupSaveImageAsText"),typeof(IupSaveImageAsTextDelegate)) as IupSaveImageAsTextDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate void IupTextConvertLinColToPosDelegate(IntPtr ih,int lin,int col,ref int pos);
  internal static IupTextConvertLinColToPosDelegate IupTextConvertLinColToPos = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupTextConvertLinColToPos"),typeof(IupTextConvertLinColToPosDelegate)) as IupTextConvertLinColToPosDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate void IupTextConvertPosToLinColDelegate(IntPtr ih,int pos,ref int lin,ref int col);
  internal static IupTextConvertPosToLinColDelegate IupTextConvertPosToLinCol = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupTextConvertPosToLinCol"),typeof(IupTextConvertPosToLinColDelegate)) as IupTextConvertPosToLinColDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate int IupConvertXYToPosDelegate(IntPtr ih,int x,int y);
  internal static IupConvertXYToPosDelegate IupConvertXYToPos = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupConvertXYToPos"),typeof(IupConvertXYToPosDelegate)) as IupConvertXYToPosDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate int IupTreeSetUserIdDelegate(IntPtr ih,int id,IntPtr userid);
  internal static IupTreeSetUserIdDelegate IupTreeSetUserId = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupTreeSetUserId"),typeof(IupTreeSetUserIdDelegate)) as IupTreeSetUserIdDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate IntPtr IupTreeGetUserIdDelegate(IntPtr ih,int id);
  internal static IupTreeGetUserIdDelegate IupTreeGetUserId = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupTreeGetUserId"),typeof(IupTreeGetUserIdDelegate)) as IupTreeGetUserIdDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate int IupTreeGetIdDelegate(IntPtr ih,IntPtr userid);
  internal static IupTreeGetIdDelegate IupTreeGetId = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupTreeGetId"),typeof(IupTreeGetIdDelegate)) as IupTreeGetIdDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate void IupTreeSetAttributeDelegate(IntPtr ih,string name,int id,string value);
  internal static IupTreeSetAttributeDelegate IupTreeSetAttribute = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupTreeSetAttribute"),typeof(IupTreeSetAttributeDelegate)) as IupTreeSetAttributeDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate void IupTreeStoreAttributeDelegate(IntPtr ih,string name,int id,string value);
  internal static IupTreeStoreAttributeDelegate IupTreeStoreAttribute = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupTreeStoreAttribute"),typeof(IupTreeStoreAttributeDelegate)) as IupTreeStoreAttributeDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate IntPtr IupTreeGetAttributeDelegate(IntPtr ih,string name,int id);
  internal static IupTreeGetAttributeDelegate IupTreeGetAttribute = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupTreeGetAttribute"),typeof(IupTreeGetAttributeDelegate)) as IupTreeGetAttributeDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate int IupTreeGetIntDelegate(IntPtr ih,string name,int id);
  internal static IupTreeGetIntDelegate IupTreeGetInt = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupTreeGetInt"),typeof(IupTreeGetIntDelegate)) as IupTreeGetIntDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate float IupTreeGetFloatDelegate(IntPtr ih,string name,int id);
  internal static IupTreeGetFloatDelegate IupTreeGetFloat = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupTreeGetFloat"),typeof(IupTreeGetFloatDelegate)) as IupTreeGetFloatDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate void IupTreeSetAttributeHandleDelegate(IntPtr ih,string a,int id,IntPtr ih_named);
  internal static IupTreeSetAttributeHandleDelegate IupTreeSetAttributeHandle = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupTreeSetAttributeHandle"),typeof(IupTreeSetAttributeHandleDelegate)) as IupTreeSetAttributeHandleDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate IntPtr IupFileDlgDelegate();
  internal static IupFileDlgDelegate IupFileDlg = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupFileDlg"),typeof(IupFileDlgDelegate)) as IupFileDlgDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate IntPtr IupMessageDlgDelegate();
  internal static IupMessageDlgDelegate IupMessageDlg = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupMessageDlg"),typeof(IupMessageDlgDelegate)) as IupMessageDlgDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate IntPtr IupColorDlgDelegate();
  internal static IupColorDlgDelegate IupColorDlg = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupColorDlg"),typeof(IupColorDlgDelegate)) as IupColorDlgDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate IntPtr IupFontDlgDelegate();
  internal static IupFontDlgDelegate IupFontDlg = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupFontDlg"),typeof(IupFontDlgDelegate)) as IupFontDlgDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate int IupGetFileDelegate(StringBuilder sb);
  internal static IupGetFileDelegate IupGetFile = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupGetFile"),typeof(IupGetFileDelegate)) as IupGetFileDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate void IupMessageDelegate(string title,string msg);
  internal static IupMessageDelegate IupMessage = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupMessage"),typeof(IupMessageDelegate)) as IupMessageDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate int IupAlarmDelegate(string title,string msg,string b1,string b2,string b3);
  internal static IupAlarmDelegate IupAlarm = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupAlarm"),typeof(IupAlarmDelegate)) as IupAlarmDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate int IupListDialogDelegate(int type, string title, int size, string[] list, int op, int max_col, int max_lin, int[] mark);
  internal static IupListDialogDelegate IupListDialog = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupListDialog"),typeof(IupListDialogDelegate)) as IupListDialogDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate int IupGetTextDelegate(string title,StringBuilder text);
  internal static IupGetTextDelegate IupGetText = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupGetText"),typeof(IupGetTextDelegate)) as IupGetTextDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate int IupGetColorDelegate(int x,int y,ref byte r,ref byte g,ref byte b);
  internal static IupGetColorDelegate IupGetColor = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupGetColor"),typeof(IupGetColorDelegate)) as IupGetColorDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate IntPtr IupLayoutDialogDelegate(IntPtr dialog);
  internal static IupLayoutDialogDelegate IupLayoutDialog = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupLayoutDialog"),typeof(IupLayoutDialogDelegate)) as IupLayoutDialogDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate IntPtr IupFillDelegate();
  internal static IupFillDelegate IupFill = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupFill"),typeof(IupFillDelegate)) as IupFillDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate IntPtr IupRadioDelegate(IntPtr child);
  internal static IupRadioDelegate IupRadio = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupRadio"),typeof(IupRadioDelegate)) as IupRadioDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate IntPtr IupVboxvDelegate(IntPtr[] children);
  internal static IupVboxvDelegate IupVboxv = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupVboxv"),typeof(IupVboxvDelegate)) as IupVboxvDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate IntPtr IupZboxvDelegate(IntPtr[] children);
  internal static IupZboxvDelegate IupZboxv = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupZboxv"),typeof(IupZboxvDelegate)) as IupZboxvDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate IntPtr IupHboxvDelegate(IntPtr[] children);
  internal static IupHboxvDelegate IupHboxv = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupHboxv"),typeof(IupHboxvDelegate)) as IupHboxvDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate IntPtr IupNormalizervDelegate(IntPtr[] ih_list);
  internal static IupNormalizervDelegate IupNormalizerv = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupNormalizerv"),typeof(IupNormalizervDelegate)) as IupNormalizervDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate IntPtr IupCboxvDelegate(IntPtr[] children);
  internal static IupCboxvDelegate IupCboxv = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupCboxv"),typeof(IupCboxvDelegate)) as IupCboxvDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate IntPtr IupSboxDelegate(IntPtr child);
  internal static IupSboxDelegate IupSbox = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupSbox"),typeof(IupSboxDelegate)) as IupSboxDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate IntPtr IupSplitDelegate(IntPtr child1,IntPtr child2);
  internal static IupSplitDelegate IupSplit = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupSplit"),typeof(IupSplitDelegate)) as IupSplitDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate IntPtr IupFrameDelegate(IntPtr child);
  internal static IupFrameDelegate IupFrame = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupFrame"),typeof(IupFrameDelegate)) as IupFrameDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate IntPtr IupImageDelegate(int width, int height, byte[] pixmap);
  internal static IupImageDelegate IupImage = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupImage"),typeof(IupImageDelegate)) as IupImageDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate IntPtr IupImageRGBDelegate(int width,int height,byte[] pixmap);
  internal static IupImageRGBDelegate IupImageRGB = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupImageRGB"),typeof(IupImageRGBDelegate)) as IupImageRGBDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate IntPtr IupImageRGBADelegate(int width,int height,byte[] pixmap);
  internal static IupImageRGBADelegate IupImageRGBA = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupImageRGBA"),typeof(IupImageRGBADelegate)) as IupImageRGBADelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate IntPtr IupItemDelegate(string title,string action);
  internal static IupItemDelegate IupItem = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupItem"),typeof(IupItemDelegate)) as IupItemDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate IntPtr IupSubmenuDelegate(string title,IntPtr child);
  internal static IupSubmenuDelegate IupSubmenu = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupSubmenu"),typeof(IupSubmenuDelegate)) as IupSubmenuDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate IntPtr IupSeparatorDelegate();
  internal static IupSeparatorDelegate IupSeparator = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupSeparator"),typeof(IupSeparatorDelegate)) as IupSeparatorDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate IntPtr IupMenuvDelegate(IntPtr[] children);
  internal static IupMenuvDelegate IupMenuv = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupMenuv"),typeof(IupMenuvDelegate)) as IupMenuvDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate IntPtr IupButtonDelegate(string title,string action);
  internal static IupButtonDelegate IupButton = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupButton"),typeof(IupButtonDelegate)) as IupButtonDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate IntPtr IupCanvasDelegate(string action);
  internal static IupCanvasDelegate IupCanvas = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupCanvas"),typeof(IupCanvasDelegate)) as IupCanvasDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate IntPtr IupDialogDelegate(IntPtr child);
  internal static IupDialogDelegate IupDialog = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupDialog"),typeof(IupDialogDelegate)) as IupDialogDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate IntPtr IupUserDelegate();
  internal static IupUserDelegate IupUser = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupUser"),typeof(IupUserDelegate)) as IupUserDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate IntPtr IupLabelDelegate(string title);
  internal static IupLabelDelegate IupLabel = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupLabel"),typeof(IupLabelDelegate)) as IupLabelDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate IntPtr IupListDelegate(string action);
  internal static IupListDelegate IupList = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupList"),typeof(IupListDelegate)) as IupListDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate IntPtr IupTextDelegate(string action);
  internal static IupTextDelegate IupText = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupText"),typeof(IupTextDelegate)) as IupTextDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate IntPtr IupMultiLineDelegate(string action);
  internal static IupMultiLineDelegate IupMultiLine = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupMultiLine"),typeof(IupMultiLineDelegate)) as IupMultiLineDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate IntPtr IupToggleDelegate(string title,string action);
  internal static IupToggleDelegate IupToggle = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupToggle"),typeof(IupToggleDelegate)) as IupToggleDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate IntPtr IupTimerDelegate();
  internal static IupTimerDelegate IupTimer = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupTimer"),typeof(IupTimerDelegate)) as IupTimerDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate IntPtr IupClipboardDelegate();
  internal static IupClipboardDelegate IupClipboard = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupClipboard"),typeof(IupClipboardDelegate)) as IupClipboardDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate IntPtr IupProgressBarDelegate();
  internal static IupProgressBarDelegate IupProgressBar = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupProgressBar"),typeof(IupProgressBarDelegate)) as IupProgressBarDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate IntPtr IupValDelegate(string type);
  internal static IupValDelegate IupVal = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupVal"),typeof(IupValDelegate)) as IupValDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate IntPtr IupTabsvDelegate(IntPtr[] children);
  internal static IupTabsvDelegate IupTabsv = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupTabsv"),typeof(IupTabsvDelegate)) as IupTabsvDelegate;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate IntPtr IupTreeDelegate();
  internal static IupTreeDelegate IupTree = Marshal.GetDelegateForFunctionPointer(dynlink.GetFunction("IupTree"),typeof(IupTreeDelegate)) as IupTreeDelegate;

}

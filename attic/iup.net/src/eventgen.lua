require "string"


classtable={}

function ucase(s)
	return s:upper()
end


function add(target,obj)
	target[table.getn(target)+1]=obj
	--print(obj)
end

function getcls(name)
	if classtable[name]==nil then
		classtable[name]={}
	end

	return classtable[name]
end

function argtail(cargs)
	if cargs==nil or cargs=="" then
		return ""
	else
		return ","..cargs
	end
end

function argtailnames(cargs)

	if cargs==nil or cargs=="" then
		return ""
	end

	local res=""



	for arg in cargs:gmatch("(%w+)") do
		if alt then
			res=res..","..arg
		end

		alt = not alt
	end


	return res


end


function genevent(classname,eventname,cbtype_cs,cbtype_c,iup_cbname,evtdata_type,cargs)
	local lst=getcls(classname)
	add(lst,"#region "..iup_cbname)
	add(lst,"")
	add(lst,cbtype_cs.." CS"..eventname.." = null;")
	add(lst,"static "..cbtype_c.." C"..eventname.." = new "..cbtype_c.."("..eventname.."Wrap);")

	add(lst,"private static CBResult "..eventname.."Wrap(IntPtr ih"..argtail(cargs)..") {")
	add(lst,"	var sender = FindObject(ih) as "..classname..";")
	add(lst,"	var d=new "..evtdata_type.."(sender"..argtailnames(cargs)..");")
	add(lst,"	sender.CS"..eventname.."(d);")
	add(lst,"	return d.Result;")
	add(lst,"}")
	add(lst,"")

	--if eventname=="Action" then
	--	add(lst,"public "..cbtype_cs.." "..eventname.." {")
	--else
		add(lst,"public "..cbtype_cs.." CB"..eventname.." {")
	--end
	add(lst,"	set {")
	add(lst,"		CS"..eventname.." = value;")
	add(lst,"		NativeIUP.IupSetCallback(Handle,\""..iup_cbname.."\", value == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(C"..eventname.."));")
	add(lst,"	}")
	add(lst,"	get {")
	add(lst,"		return CS"..eventname..";")
	add(lst,"	}")
	add(lst,"}")
	add(lst,"")
	add(lst,"#endregion "..iup_cbname)
	add(lst,"")
	add(lst,"")
end



function dumpcode()

	print("using System;")
	print("using System.Runtime.InteropServices;")
	print("")


	print("namespace Tecgraf.IUPSharp {")

	for clname,code in pairs(classtable) do
		print("////////////////////////////////////////////////////////////////")
		print("\tpublic partial class "..clname.." {")

		for index,value in ipairs(code) do
			print("\t\t"..value)
		end
		print("\t} //end class")

	end

	print("} //end namespace")

end



genevent("Button","Action","Callback","Icallback","ACTION","ActionData")

genevent("IUPControl","Button","ButtonDelegate","Icallback_iiiis","BUTTON_CB","ButtonCBData","int button,int pressed,int x,int y,string status")
genevent("IUPControl","Key","KeyDelegate","Icallback_i","K_ANY","KeyCBData","int key")
genevent("IUPControl","Map","Callback","Icallback","MAP_CB","ActionData")
genevent("IUPControl","Unmap","Callback","Icallback","UNMAP_CB","ActionData")
genevent("IUPControl","GetFocus","Callback","Icallback","GETFOCUS_CB","ActionData")
genevent("IUPControl","KillFocus","Callback","Icallback","KILLFOCUS_CB","ActionData")
genevent("IUPControl","EnterWindow","Callback","Icallback","ENTERWINDOW_CB","ActionData")
genevent("IUPControl","LeaveWindow","Callback","Icallback","LEAVEWINDOW_CB","ActionData")
genevent("IUPControl","Help","Callback","Icallback","HELP_CB","ActionData")

--function genevent(classname,eventname,cbtype_cs,cbtype_c,iup_cbname,evtdata_type,cargs)

genevent("CanvasControl","Action","CanvasActionDelegate","Icallback_ff","ACTION","CanvasActionData","float x,float y")
genevent("CanvasControl","DropFiles","DropFilesDelegate","Icallback_siii","DROPFILES_CB","DropFilesData","string filename,int num,int x,int y")



dumpcode()




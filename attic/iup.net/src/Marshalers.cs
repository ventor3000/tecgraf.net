using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Tecgraf
{
    /// <summary>
    /// Class used to marshal IntPtr:s representing c Ihandles to/from IupHandle
    /// </summary>
    internal class IupHandleMarshaller : ICustomMarshaler
    {
        static IupHandleMarshaller marshaler = new IupHandleMarshaller();
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

        public IntPtr MarshalManagedToNative(object managedObj)
        {
            if (managedObj == null)
                return IntPtr.Zero;

            IupHandle ih = managedObj as IupHandle;
            if (ih == null)
                throw new ArgumentException("managedObj", "Can only marshal type of Tecgraf.IupHandle");

            return IupHandle.GetCHandle(ih);
        }

        public object MarshalNativeToManaged(IntPtr pNativeData)
        {
            IupHandle ih = IupHandle.Create(pNativeData);
            return ih;
        }
    }

    public class UTF8Marshaler : ICustomMarshaler
    {
        static UTF8Marshaler static_instance;

        public IntPtr MarshalManagedToNative(object managedObj)
        {
            if (managedObj == null)
                return IntPtr.Zero;
            if (!(managedObj is string))
                throw new MarshalDirectiveException(
                       "UTF8Marshaler must be used on a string.");

            // not null terminated
            byte[] strbuf = Encoding.UTF8.GetBytes((string)managedObj);
            IntPtr buffer = Marshal.AllocHGlobal(strbuf.Length + 1);
            Marshal.Copy(strbuf, 0, buffer, strbuf.Length);

            // write the terminating null
            Marshal.WriteByte(buffer + strbuf.Length, 0);
            return buffer;
        }

        public unsafe object MarshalNativeToManaged(IntPtr pNativeData)
        {
            byte* walk = (byte*)pNativeData;

            // find the end of the string
            while (*walk != 0)
            {
                walk++;
            }
            int length = (int)(walk - (byte*)pNativeData);

            // should not be null terminated
            byte[] strbuf = new byte[length];
            // skip the trailing null
            Marshal.Copy((IntPtr)pNativeData, strbuf, 0, length);
            string data = Encoding.UTF8.GetString(strbuf);
            return data;
        }

        public void CleanUpNativeData(IntPtr pNativeData)
        {

            Marshal.FreeHGlobal(pNativeData);
        }

        public void CleanUpManagedData(object managedObj)
        {
        }

        public int GetNativeDataSize()
        {
            return -1;
        }

        public static ICustomMarshaler GetInstance(string cookie)
        {
            if (static_instance == null)
            {
                return static_instance = new UTF8Marshaler();
            }
            return static_instance;
        }
    }

	
}

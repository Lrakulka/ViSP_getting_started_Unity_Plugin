using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace ImageLoadAndSaveCSTest
{
    class Program
    {
        private const string dllPath = "D:\\Projects\\visp-gsoc-2017-enter-tasks\\ImageLoadAndSave\\Debug\\ImageLoadAndSave.dll";
        [DllImport(dllPath, EntryPoint = "Load", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Load(string path, byte[] bytes, uint size);

        [DllImport(dllPath, EntryPoint = "Save", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool Save(byte[] bytes, uint size, string path);

        [DllImport(dllPath, EntryPoint = "GetSize", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint GetSize(string path);

        static void Main(string[] args)
        {
            string path = "D:\\Projects\\visp-gsoc-2017-enter-tasks\\example.png";
            string path2 = "D:\\Projects\\visp-gsoc-2017-enter-tasks\\exampleProcessed.png";
            uint size = GetSize(path);
            byte[] bytes = new byte[size];
            Load(path, bytes, size);
            Save(bytes, size, path2);
            Console.Write(size);
        }
    }
}

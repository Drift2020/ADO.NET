using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;

namespace Conductor
{
    class Win32
    {
        //необходимо импортировать структуру SHFILEINFO
        [StructLayout(LayoutKind.Sequential)]
        public struct SHFILEINFO
        {
            /*
             IntPtr – специальная структура, для представления указателей и дескрипторов.
              Внутри есть набор функций для преобразования к типам данных:
              public int ToInt32();
            */
            public IntPtr hIcon;
            public IntPtr iIcon;
            public uint dwAttributes;
            /*
             Типы ByValTStr .NET Framework ведут себя, как характерные для языка C 
             строки фиксированной длины внутри структуры (например, char s[5]).
            */
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szDisplayName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
            public string szTypeName;
        }
        public const int SHGFI_ICON = 0x000000100;
        public const int SHGFI_SMALLICON = 0x000000001;
        public const int SHGFI_LARGEICON = 0x000000000;
        public const int SHGFI_DISPLAYNAME = 0x000000200;
        public const int SHGFI_TYPENAME = 0x000000400;
        [DllImport("shell32.dll")]
        public static extern IntPtr
        SHGetFileInfo(string pszPath, uint dwFileAttributes, ref SHFILEINFO psfi, uint cbFileInfo, uint uFlags);
    }
}

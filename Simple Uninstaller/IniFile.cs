using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace SimpleUninstaller
{
    /// <summary>
    /// INI 파일을 제어하는 클래스
    /// </summary>
    class IniFile
    {
        string strFilePath;

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        static extern long WritePrivateProfileString(string lpAppName, string lpKeyName, string lpString, string lpFileName);

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        static extern int GetPrivateProfileString(string lpAppName, string lpKeyName, string nDefault, StringBuilder lpReturnedString, int nSize, string lpFileName);

        [DllImport("kernel32.dll")]
        static extern int GetPrivateProfileInt(string lpAppName, string lpKeyName, int nDefault, string lpFileName);


        public IniFile(string InistrFilePath)
        {
            strFilePath = new FileInfo(InistrFilePath).FullName.ToString();
        }

        // read string
        public string Read(string Key, string Section, string Default = null)
        {
            var RetVal = new StringBuilder(255);
            GetPrivateProfileString(Section, Key, Default, RetVal, 255, strFilePath);
            return RetVal.ToString();
        }

        // read integer
        public int Read(string Key, string Section, int Default = 0)
        {
            return GetPrivateProfileInt(Section, Key, Default, strFilePath);
        }

        // read bool
        public bool Read(string Key, string Section, bool Default = false)
        {
            return GetPrivateProfileInt(Section, Key, Default ? 1 : 0, strFilePath) == 1;
        }

        // write string
        public void Write(string Key, string Value, string Section)
        {
            WritePrivateProfileString(Section, Key, Value, strFilePath);
        }

        // write integer
        public void Write(string Key, int Value, string Section)
        {
            WritePrivateProfileString(Section, Key, Value.ToString(), strFilePath);
        }

        // write bool
        public void Write(string Key, bool Value, string Section)
        {
            WritePrivateProfileString(Section, Key, Value ? "1" : "0", strFilePath);
        }

        public void DeleteKey(string Key, string Section)
        {
            Write(Key, null, Section);
        }

        public void DeleteSection(string Section)
        {
            Write(null, null, Section);
        }

        public bool KeyExists(string Key, string Section)
        {
            return Read(Key, Section, null).Length > 0;
        }
    }
}
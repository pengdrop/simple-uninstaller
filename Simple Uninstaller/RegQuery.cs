using System;
using System.Text;
using System.Runtime.InteropServices;

namespace SimpleUninstaller
{
    /// <summary>
    /// 레지스트리를 제어하는 클래스
    /// </summary>
    public class RegQuery
    {
        public const int KEY_QUERY_VALUE = 0x1;
        static UIntPtr hKey = (UIntPtr)0x80000002;
        static UIntPtr hKeyVal;
        static StringBuilder classStr = new StringBuilder(255);
        static uint classSize = (uint)classStr.Capacity + 1;
        static uint lpcSubKeys;
        static uint lpcbMaxSubKeyLen;
        static uint lpcbMaxClassLen;
        static uint lpcValues;
        static uint lpcbMaxValueNameLen;
        static uint lpcbMaxValueLen;
        static uint lpcbSecurityDescriptor;
        static long lpftLastWriteTime;

        [DllImport("advapi32.dll", EntryPoint = "RegOpenKeyEx")]
        extern private static int RegOpenKeyEx(
            UIntPtr hKey,
            string lpSubKey,
            uint ulOptions,
            int samDesired,
            out UIntPtr phkResult);

        [DllImport("advapi32.dll")]
        extern private static int RegQueryInfoKey(
            UIntPtr hkey,
            StringBuilder lpClass,
            ref uint lpcbClass,
            IntPtr lpReserved,
            out uint lpcSubKeys,
            out uint lpcbMaxSubKeyLen,
            out uint lpcbMaxClassLen,
            out uint lpcValues,
            out uint lpcbMaxValueNameLen,
            out uint lpcbMaxValueLen,
            out uint lpcbSecurityDescriptor,
            out long lpftLastWriteTime
        );

        public static void doQuery(string fullKey)
        {
            string[] hive = fullKey.Split(new char[] { '\\' }, 2);
            if (String.Equals(hive[0], "HKEY_LOCAL_MACHINE", StringComparison.OrdinalIgnoreCase) || String.Equals(hive[0], "HKLM", StringComparison.OrdinalIgnoreCase))
                hKey = (UIntPtr)0x80000002;
            else if (String.Equals(hive[0], "HKEY_CURRENT_USER", StringComparison.OrdinalIgnoreCase) || String.Equals(hive[0], "HKCU", StringComparison.OrdinalIgnoreCase))
                hKey = (UIntPtr)0x80000001;
            else if (String.Equals(hive[0], "HKEY_CLASSES_ROOT", StringComparison.OrdinalIgnoreCase) || String.Equals(hive[0], "HKCR", StringComparison.OrdinalIgnoreCase))
                hKey = (UIntPtr)0x80000000;
            else if (String.Equals(hive[0], "HKEY_USERS", StringComparison.OrdinalIgnoreCase) || String.Equals(hive[0], "HKU", StringComparison.OrdinalIgnoreCase))
                hKey = (UIntPtr)0x80000003;
            else if (String.Equals(hive[0], "HKEY_CURRENT_CONFIG", StringComparison.OrdinalIgnoreCase) || String.Equals(hive[0], "HKCC", StringComparison.OrdinalIgnoreCase))
                hKey = (UIntPtr)0x80000005;

            RegOpenKeyEx(hKey, hive[1], 0, KEY_QUERY_VALUE, out hKeyVal);
            RegQueryInfoKey(hKeyVal, classStr, ref classSize, IntPtr.Zero, out lpcSubKeys, out lpcbMaxSubKeyLen, out lpcbMaxClassLen, out lpcValues, out lpcbMaxValueNameLen, out lpcbMaxValueLen, out lpcbSecurityDescriptor, out lpftLastWriteTime);
        }

        /// <summary>
        /// A pointer to a buffer that receives the user-defined class of the key.
        /// Example: int cString = DateTime dTime = RegQuery.classString("HKEY_Current_user\\software\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\Dropbox");
        /// </summary>
        public static string classString(string fullKey)
        {
            doQuery(fullKey);
            return classStr.ToString();
        }
        /// <summary>
        /// A pointer to a variable that receives the number of subkeys that are contained by the specified key.
        /// Example: uint sKeys = RegQuery.subKeys("HKEY_Current_user\\software\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\Dropbox");
        /// </summary>
        public static uint subKeys(string fullKey)
        {
            doQuery(fullKey);
            return lpcSubKeys;
        }
        /// <summary>
        /// A pointer to a variable that receives the size of the key's subkey with the longest name, in Unicode characters, not including the terminating null character. 
        /// Example: uint mSubKeyLen = RegQuery.maxSubKeyLen("HKEY_Current_user\\software\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\Dropbox");
        /// </summary>
        public static uint maxSubKeyLen(string fullKey)
        {
            doQuery(fullKey);
            return lpcbMaxSubKeyLen;
        }
        /// <summary>
        /// A pointer to a variable that receives the size of the longest string that specifies a subkey class, in Unicode characters. The count returned does not include the terminating null character. 
        /// Example: uint mClassLen = RegQuery.maxClassLen("HKEY_Current_user\\software\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\Dropbox");
        /// </summary>
        public static uint maxClassLen(string fullKey)
        {
            doQuery(fullKey);
            return lpcbMaxClassLen;
        }
        /// <summary>
        /// A pointer to a variable that receives the number of values that are associated with the key.
        /// Example: uint vals = RegQuery.values("HKEY_Current_user\\software\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\Dropbox");
        /// </summary>
        public static uint values(string fullKey)
        {
            doQuery(fullKey);
            return lpcValues;
        }
        /// <summary>
        /// A pointer to a variable that receives the size of the key's longest value name, in Unicode characters. The size does not include the terminating null character. 
        /// Example: uint mValueNameLen = RegQuery.maxValueNameLen("HKEY_Current_user\\software\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\Dropbox");
        /// </summary>
        public static uint maxValueNameLen(string fullKey)
        {
            doQuery(fullKey);
            return lpcbMaxValueNameLen;
        }
        /// <summary>
        /// A pointer to a variable that receives the size of the longest data component among the key's values, in bytes.
        /// Example: uint mValueLen = RegQuery.maxValueLen("HKEY_Current_user\\software\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\Dropbox");
        /// </summary>
        public static uint maxValueLen(string fullKey)
        {
            doQuery(fullKey);
            return lpcbMaxValueLen;
        }
        /// <summary>
        /// A pointer to a variable that receives the size of the key's security descriptor, in bytes.  
        /// Example: uint sDesc = RegQuery.securityDescriptor("HKEY_Current_user\\software\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\Dropbox");
        /// </summary>
        public static uint securityDescriptor(string fullKey)
        {
            doQuery(fullKey);
            return lpcbSecurityDescriptor;
        }
        /// <summary>
        /// A pointer to a FILETIME structure that receives the last write time. 
        /// Example: DateTime dTime = RegQuery.lastWriteTime("HKEY_Current_user\\software\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\Dropbox");
        /// </summary>
        public static DateTime lastWriteTime(string fullKey)
        {
            doQuery(fullKey);
            return DateTime.FromFileTime(lpftLastWriteTime);
        }

    }
}
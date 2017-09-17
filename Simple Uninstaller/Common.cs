using System;
using System.Drawing;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SimpleUninstaller
{
    /// <summary>
    /// 설치된 소프트웨어의 정보를 담기 위한 구조체
    /// </summary>
    public struct SoftwareInformation
    {
        public string strDisplayName;
        public string strDisplayIcon;
        public string strPublisher;
        public string strDisplayVersion;
        public DateTime dtLastWriteTime;
        public long lngFileLocationSize;
        public string strHelpLink;
        public string strSupportLink;
        public string strFileLocation;
        public string strRegistryLocation;

        public string strUninstallString;

        public bool isSystemComponent;

        public Image imgLargeIcon;
    }

    /// <summary>
    /// 클래스간 데이터를 공유하기 위한, 글로벌 변수역을 하는 클래스
    /// </summary>
    class Global
    {
        static List<SoftwareInformation> lstMain = new List<SoftwareInformation>();
        /// <summary>
        /// 현재 리스트에 올라온 소프트웨어들의 정보들
        /// </summary>
        public static List<SoftwareInformation> siMain
        {
            get
            {
                return lstMain;
            }
            set
            {
                lstMain = value;
            }
        }
    }

    /// <summary>
    /// 자주 쓰는 색상 정보를 담은 클래스
    /// </summary>
    class MyColor
    {
        public static Color Odd = Color.FromArgb(0xf9f9f9);
        public static Color Even = Color.FromArgb(0xffffff);

        public static Color NormalText = Color.FromArgb(0x000000);

        public static Color Primary = Color.FromArgb(0x428bca);
        public static Color Success = Color.FromArgb(0x5cb85c);
        public static Color Info = Color.FromArgb(0x5bc0de);
        public static Color Warning = Color.FromArgb(0xf0ad4e);
        public static Color Danger = Color.FromArgb(0xd9534f);
    }

    /// <summary>
    /// 문자열 관련 편의 기능을 담은 클래스
    /// </summary>
    class StringUtil
    {
        /// <summary>
        /// 문자열 속에 다른 문자열이 포함되어 있는지 여부를 반환하는 함수
        /// </summary>
        public static bool InStr(string a, string b, bool isIgnoreCase = true)
        {
            return Regex.IsMatch(a, Regex.Escape(b), isIgnoreCase ? RegexOptions.IgnoreCase : RegexOptions.None);
        }
    }
}

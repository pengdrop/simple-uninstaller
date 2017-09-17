using System;
using System.IO;

namespace SimpleUninstaller
{
    /// <summary>
    /// 파일 제어에 도움을 주는 클래스
    /// </summary>
    class FileUtil
    {
        /// <summary>
        /// 지정된 경로의 크기를 반환하는 함수
        /// </summary>
        public static long GetDirSize(string DirPath)
        {
            try
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(DirPath);
                if (!directoryInfo.Exists)
                    return -1;

                FileSystemInfo[] fileSystemInfoArray = directoryInfo.GetFileSystemInfos();
                long directorySize = 0L;

                for (int i = 0; i < fileSystemInfoArray.Length; i++)
                {
                    FileInfo fileInfo = fileSystemInfoArray[i] as FileInfo;
                    if (fileInfo != null && fileInfo.Exists)
                    {
                        directorySize += fileInfo.Length;
                    }
                }
                return directorySize;
            }
            catch
            {
                return -1;
            }
        }

        /// <summary>
        /// 파일 경로를 반환하는 함수
        /// </summary>
        public static string DirName(string FilePath)
        {
            try
            {
                return new FileInfo(FilePath).DirectoryName;
            }
            catch
            {
                return null;
            }

        }

        /// <summary>
        /// 파일 존재 여부를 반환하는 함수
        /// </summary>
        public static bool IsFile(string FilePath)
        {
            try
            {
                return new FileInfo(FilePath).Exists;
            }
            catch
            {
                return false;
            }

        }

        /// <summary>
        /// 경로 존재 여부를 반환하는 함수
        /// </summary>
        public static bool IsDir(string DirPath)
        {
            try
            {
                return new DirectoryInfo(DirPath).Exists;
            }
            catch
            {
                return false;
            }

        }

        /// <summary>
        /// 파일 크기를 사람이 읽기 편한 단위로 변환해주는 함수
        /// </summary>
        public static string ConvertHumanReadableFileSize(long byteCount)
        {
            string[] suf = { "B", "KB", "MB", "GB", "TB", "PB", "EB" };
            if (byteCount == 0) return "0" + suf[0];
            long bytes = Math.Abs(byteCount);
            int place = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024)));
            double num = Math.Round(bytes / Math.Pow(1024, place), 1);
            return (Math.Sign(byteCount) * num).ToString() + suf[place];
        }
    }
}

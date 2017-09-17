using System;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Collections.Generic;

namespace SimpleUninstaller
{
    /// <summary>
    /// 프로세스 제어에 도움을 주는 클래스
    /// </summary>
    static class ProcUtil
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct ParentProcessUtilities
        {
            internal IntPtr Reserved1;
            internal IntPtr PebBaseAddress;
            internal IntPtr Reserved2_0;
            internal IntPtr Reserved2_1;
            internal IntPtr UniqueProcessId;
            internal IntPtr InheritedFromUniqueProcessId;
        }

        [DllImport("ntdll.dll")]
        private static extern int ZwQueryInformationProcess(IntPtr processHandle, int processInformationClass, ref ParentProcessUtilities processInformation, int processInformationLength, out int returnLength);

        public static int GetParentProcessId(IntPtr handle)
        {
            ParentProcessUtilities pbi = new ParentProcessUtilities();
            int returnLength;
            int status = ZwQueryInformationProcess(handle, 0, ref pbi, Marshal.SizeOf(pbi), out returnLength);
            if (status != 0) return -1;

            try
            {
                return pbi.InheritedFromUniqueProcessId.ToInt32();
            }
            catch (ArgumentException)
            {
                return -1;
            }
        }

        public static List<Process> GetChildProcesses(int ProcessId)
        {
            List<Process> Results = new List<Process>();
            foreach (Process proc in Process.GetProcesses())
            {
                try
                {
                    if (GetParentProcessId(proc.Handle) == ProcessId)
                        Results.Add(proc);
                }
                catch
                {

                }
            }
            return Results;
        }




    }
}
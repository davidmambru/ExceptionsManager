using System;
using System.Diagnostics;
using System.IO;

namespace ExceptionsManager
{
    internal static class PathSetting
    {
        private static string _FolderName = Path.GetFileName(Process.GetCurrentProcess()?.MainModule?.FileName)?.Split('.')[0];
        public static string Root = Path.Combine(@"C:\Users\Public\LogExceptions", _FolderName);
        public static string Date = DateTime.Now.ToString("yyyy-MM-dd");
        public static string FileName = $"Exceptions_{Date}.xml";
        public static string GetFilePath() => Path.Combine(Root, FileName);
    }
}
 

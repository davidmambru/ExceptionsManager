using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionsManager
{
    public static class FileLogger
    {
        public static void LogException(Exception ex, string user = default)
        {
            var helper = new Helpers();
            helper.CreateFolder(PathSetting.Root);
            helper.CreateFileXML();
            helper.RecordFileXML(ex, user);
        }
    }
}
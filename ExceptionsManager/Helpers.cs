using ExceptionsManager;
using System;
using System.IO;
using System.Xml;

namespace ExceptionsManager
{
    internal class Helpers
    {
        internal void CreateFolder(string path)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
        }

        internal void CreateFileXML()
        {
            if (File.Exists(PathSetting.GetFilePath()))
                return;

            var doc = new XmlDocument();
            var dec = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            var root = doc.DocumentElement;
            doc.InsertBefore(dec, root);
            XmlElement logs = doc.CreateElement("Exceptions");

            doc.AppendChild(logs);
            doc.Save(PathSetting.GetFilePath());
        }

        internal void RecordFileXML(Exception ex, string user)
        {
            var solutionName = Path.GetFileName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
            if (!File.Exists(PathSetting.GetFilePath()))
                return;

            var doc = new XmlDocument();
            doc.Load(PathSetting.GetFilePath());
            XmlNode root = doc.SelectSingleNode("Exceptions");

            XmlElement exception = doc.CreateElement("Exception");

            XmlElement DateTime = doc.CreateElement("DateTime");
            DateTime.InnerText = System.DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt");
            exception.AppendChild(DateTime);

            XmlElement User = doc.CreateElement("User");
            User.InnerText = user;
            exception.AppendChild(User);

            XmlElement Message = doc.CreateElement("Message");
            Message.InnerText = ex.Message;
            exception.AppendChild(Message);

            XmlElement Source = doc.CreateElement("Source");
            Source.InnerText = ex.Source;
            exception.AppendChild(Source);

            XmlElement Data = doc.CreateElement("Data");
            Data.InnerText = ex.Data.Values.ToString();
            exception.AppendChild(Data);

            XmlElement StackTrace = doc.CreateElement("StackTrace");
            StackTrace.InnerText = ex.StackTrace;
            exception.AppendChild(StackTrace);

            XmlElement HResult = doc.CreateElement("HResult");
            HResult.InnerText = ex.HResult.ToString();
            exception.AppendChild(HResult);

            root.AppendChild(exception);
            doc.Save(PathSetting.GetFilePath());
        }
    }
}
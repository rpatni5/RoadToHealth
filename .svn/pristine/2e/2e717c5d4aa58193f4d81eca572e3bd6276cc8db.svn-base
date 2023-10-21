using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace RTH.Windows.Views.Helpers
{
    public static class ErrorLog
    {
        public static void WriteErrorLog(Exception ex)
        {
            try
            {
                var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                Directory.CreateDirectory(Path.Combine(appDataPath, "RTH"));
                string filePath = Path.Combine(appDataPath, "RTH", "RTHErrorLog.xml");
                if (File.Exists(filePath) == false)
                {
                    using (XmlWriter xmlWriter = XmlWriter.Create(filePath, new XmlWriterSettings() { Indent = true, NewLineOnAttributes = true }))
                    {
                        xmlWriter.WriteStartDocument();
                        xmlWriter.WriteStartElement("Exceptions");

                        xmlWriter.WriteStartElement("Exception");
                        xmlWriter.WriteElementString("UTCDateTime", DateTime.UtcNow.ToString());
                        xmlWriter.WriteElementString("Message", ex.Message);
                        xmlWriter.WriteElementString("Source", ex.Source);
                        xmlWriter.WriteElementString("StackTrace", ex.StackTrace);
                        xmlWriter.WriteEndElement();

                        xmlWriter.WriteEndElement();
                        xmlWriter.WriteEndDocument();
                        xmlWriter.Flush();
                        xmlWriter.Close();
                    }
                }
                else
                {
                    XDocument xDocument = XDocument.Load(filePath);
                    XElement root = xDocument.Element("Exceptions");
                    IEnumerable<XElement> rows = root.Descendants("Exception");
                    XElement firstRow = rows.First();
                    firstRow.AddBeforeSelf(
                       new XElement("Exception",
                       new XElement("UTCDateTime", DateTime.UtcNow.ToString()),
                       new XElement("Message", ex.Message),
                       new XElement("Source", ex.Source),
                    new XElement("StackTrace", ex.StackTrace)));
                    xDocument.Save(filePath);
                }
            }
            catch (Exception) { }
        }
    }
}

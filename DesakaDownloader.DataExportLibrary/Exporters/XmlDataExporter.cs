using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using DesakaDownloader.DataExportLibrary.Interfaces;

namespace DesakaDownloader.DataExportLibrary.Exporters
{
    public class XmlDataExporter<T> : IDataExporter<T>
    {
        public void Export(List<T> data, string filePath)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    serializer.Serialize(writer, data);
                }
                Console.WriteLine($"Successfully exported data to XML file at {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error exporting data to XML: {ex.Message}");
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using DesakaDownloader.DataExportLibrary.Interfaces;
using Newtonsoft.Json;

namespace DesakaDownloader.DataExportLibrary.Exporters
{
    public class JsonDataExporter<T> : IDataExporter<T>
    {
        public void Export(List<T> data, string filePath)
        {
            try
            {
                string json = JsonConvert.SerializeObject(data, Formatting.Indented);
                File.WriteAllText(filePath, json);
                Console.WriteLine($"Successfully exported data to JSON file at {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error exporting data to JSON: {ex.Message}");
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;
using DesakaDownloader.DataExportLibrary.Interfaces;

namespace DesakaDownloader.DataExportLibrary.Exporters
{
    public class CsvDataExporter<T> : IDataExporter<T>
    {
        public void Export(List<T> data, string filePath)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                using (CsvWriter csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv.WriteRecords(data);
                }
                Console.WriteLine($"Successfully exported data to CSV file at {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error exporting data to CSV: {ex.Message}");
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
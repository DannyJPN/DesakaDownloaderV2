using System;
using System.Collections.Generic;
using System.IO;
using DesakaDownloader.DataImportLibrary.Interfaces;
using Newtonsoft.Json;

namespace DesakaDownloader.DataImportLibrary.Importers
{
    public class JsonDataImporter<T> : IDataImporter<T> where T : class
    {
        public List<T> Import(string filePath)
        {
            try
            {
                Console.WriteLine($"Starting import from JSON file at {filePath}");
                string jsonData = File.ReadAllText(filePath);
                List<T> items = JsonConvert.DeserializeObject<List<T>>(jsonData);
                Console.WriteLine($"Successfully imported data from JSON file at {filePath}");
                return items;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error importing data from JSON: {ex.Message}");
                Console.WriteLine(ex.ToString());
                throw;
            }
        }
    }
}
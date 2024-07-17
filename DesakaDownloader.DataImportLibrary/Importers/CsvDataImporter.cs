using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;
using DesakaDownloader.DataImportLibrary.Interfaces;

namespace DesakaDownloader.DataImportLibrary.Importers
{
    public class CsvDataImporter<T> : IDataImporter<T> where T : class, new()
    {
        public List<T> Import(string filePath)
        {
            try
            {
                Console.WriteLine($"Starting import from CSV file at {filePath}");
                using (StreamReader reader = new StreamReader(filePath))
                using (CsvReader csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
                {
                    List<T> items = new List<T>();
                    csv.Read();
                    csv.ReadHeader();
                    while (csv.Read())
                    {
                        T item = new T();
                        foreach (var property in typeof(T).GetProperties())
                        {
                            var value = csv.GetField(property.PropertyType, property.Name);
                            property.SetValue(item, value);
                        }
                        items.Add(item);
                    }
                    Console.WriteLine($"Successfully imported data from CSV file at {filePath}");
                    return items;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error importing data from CSV: {ex.Message}");
                Console.WriteLine(ex.ToString());
                throw;
            }
        }
    }
}
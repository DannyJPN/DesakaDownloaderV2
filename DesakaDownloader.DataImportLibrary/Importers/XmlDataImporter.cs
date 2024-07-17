using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using DesakaDownloader.DataImportLibrary.Interfaces;

namespace DesakaDownloader.DataImportLibrary.Importers
{
    public class XmlDataImporter<T> : IDataImporter<T> where T : class
    {
        public List<T> Import(string filePath)
        {
            try
            {
                Console.WriteLine($"Starting import from XML file at {filePath}");
                XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
                using (StreamReader reader = new StreamReader(filePath))
                {
                    List<T> items = (List<T>)serializer.Deserialize(reader);
                    Console.WriteLine($"Successfully imported data from XML file at {filePath}");
                    return items;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error importing data from XML: {ex.Message}");
                Console.WriteLine(ex.ToString());
                throw;
            }
        }
    }
}
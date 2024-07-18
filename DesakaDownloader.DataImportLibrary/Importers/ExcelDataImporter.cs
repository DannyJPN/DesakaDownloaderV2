using System;
using System.Collections.Generic;
using System.IO;
using ClosedXML.Excel;
using DesakaDownloader.DataImportLibrary.Interfaces;

namespace DesakaDownloader.DataImportLibrary.Importers
{
    public class ExcelDataImporter<T> : IDataImporter<T> where T : class, new()
    {
        public List<T> Import(string filePath)
        {
            try
            {
                Console.WriteLine($"Starting import from Excel file at {filePath}");
                List<T> items = new List<T>();

                using (XLWorkbook workbook = new XLWorkbook(filePath))
                {
                    IXLWorksheet worksheet = workbook.Worksheet(1);
                    bool isFirstRow = true;
                    var properties = typeof(T).GetProperties();
                    Dictionary<string, int> headerMap = new Dictionary<string, int>();

                    foreach (IXLRow row in worksheet.RowsUsed())
                    {
                        if (isFirstRow)
                        {
                            // Map headers to property indices
                            for (int i = 0; i < row.Cells().Count(); i++)
                            {
                                string header = row.Cell(i + 1).Value.ToString();
                                headerMap[header] = i + 1;
                            }
                            isFirstRow = false;
                        }
                        else
                        {
                            T item = new T();
                            foreach (var property in properties)
                            {
                                if (headerMap.ContainsKey(property.Name))
                                {
                                    var cellValue = row.Cell(headerMap[property.Name]).GetValue<string>();
                                    property.SetValue(item, cellValue);
                                }
                            }
                            items.Add(item);
                        }
                    }
                }

                Console.WriteLine($"Successfully imported data from Excel file at {filePath}");
                return items;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error importing data from Excel: {ex.Message}");
                Console.WriteLine(ex.ToString());
                throw;
            }
        }
    }
}
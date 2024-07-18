using System;
using System.Collections.Generic;
using System.IO;
using ClosedXML.Excel;
using DesakaDownloader.DataExportLibrary.Interfaces;

namespace DesakaDownloader.DataExportLibrary.Exporters
{
    public class ExcelDataExporter<T> : IDataExporter<T>
    {
        public void Export(List<T> data, string filePath)
        {
            try
            {
                using (XLWorkbook workbook = new XLWorkbook())
                {
                    IXLWorksheet worksheet = workbook.Worksheets.Add("Data");
                    int currentRow = 1;

                    // Add headers
                    var properties = typeof(T).GetProperties();
                    for (int i = 0; i < properties.Length; i++)
                    {
                        worksheet.Cell(currentRow, i + 1).Value = properties[i].Name;
                    }

                    // Add data rows
                    foreach (var item in data)
                    {
                        currentRow++;
                        for (int i = 0; i < properties.Length; i++)
                        {
                            worksheet.Cell(currentRow, i + 1).Value = properties[i].GetValue(item);
                        }
                    }

                    workbook.SaveAs(filePath);
                    Console.WriteLine($"Successfully exported data to Excel file at {filePath}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error exporting data to Excel: {ex.Message}");
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
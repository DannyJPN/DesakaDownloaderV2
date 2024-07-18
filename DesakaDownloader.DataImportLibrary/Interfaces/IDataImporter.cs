using System.Collections.Generic;

namespace DesakaDownloader.DataImportLibrary.Interfaces
{
    public interface IDataImporter<T>
    {
        List<T> Import(string filePath);
    }
}
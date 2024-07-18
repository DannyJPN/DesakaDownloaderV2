using System.Collections.Generic;

namespace DesakaDownloader.DataExportLibrary.Interfaces
{
    public interface IDataExporter<T>
    {
        void Export(List<T> data, string filePath);
    }
}
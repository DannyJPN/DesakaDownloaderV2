using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesakaDownloader.EntitiesLibrary.Entities.Eshops;
using DesakaDownloader.EntitiesLibrary.Entities.Products;
using DesakaDownloader.ParsersLibrary.Parsers;
using DesakaDownloader.AILibrary.Services;
using DesakaDownloader.DataExportLibrary.Interfaces;
using DesakaDownloader.DataExportLibrary.Exporters;
using DesakaDownloader.DataImportLibrary.Interfaces;
using DesakaDownloader.DataImportLibrary.Importers;

namespace DesakaDownloader.Downloader.Services
{
    public class DownloaderService
    {
        private readonly Dictionary<string, Eshop> _eshops;
        private readonly HTMLParser htmlparser;
        
  }
}
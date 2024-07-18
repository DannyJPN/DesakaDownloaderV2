using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Win32;
using DesakaDownloader.Downloader.Services;
using DesakaDownloader.EntitiesLibrary.Entities.Eshops;
using DesakaDownloader.EntitiesLibrary.Entities.Products;
using DesakaDownloader.ParsersLibrary.Parsers;
using DesakaDownloader.DataExportLibrary.Interfaces;
using DesakaDownloader.DataExportLibrary.Exporters;
using DesakaDownloader.DataImportLibrary.Interfaces;
using DesakaDownloader.DataImportLibrary.Importers;
using System.Windows.Controls;

namespace DesakaDownloader.UI
{
    public partial class MainWindow : Window
    {
        private readonly DownloaderService _downloaderService;
        private readonly Dictionary<string, Eshop> _eshops;
        private readonly Dictionary<string, Parser> _parsers;

        public MainWindow()
        {
            InitializeComponent();
            _eshops = new Dictionary<string, Eshop>
            {
                { "Contra.de", new ContraDeEshop() },
                { "Nittaku.com", new NittakuEshop() },
                { "Pincesobchod.cz", new PincesobchodCzEshop() },
                { "Pincesobchod.sk", new PincesobchodSkEshop() },
                { "Sportspin.cz", new SportspinCzEshop() },
                { "Stoten.cz", new StotenCzEshop() },
                { "Vsenastolnitenis.cz", new VsenastolnitenisCzEshop() }
            };

            _parsers = new Dictionary<string, Parser>
            {
                { "Contra.de", new ContraDeParser() },
                { "Nittaku.com", new NittakuParser() },
                { "Pincesobchod.cz", new PincesobchodCzParser() },
                { "Pincesobchod.sk", new PincesobchodSkParser() },
                { "Sportspin.cz", new SportspinCzParser() },
                { "Stoten.cz", new StotenCzParser() },
                { "Vsenastolnitenis.cz", new VsenastolnitenisCzParser() }
            };

 
        }

  }
}
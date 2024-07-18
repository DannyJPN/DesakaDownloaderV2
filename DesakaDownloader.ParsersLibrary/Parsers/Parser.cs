using HtmlAgilityPack;
using DesakaDownloader.EntitiesLibrary.Entities.Products;
using System.Drawing;
using System.Net;
using System.Collections.Generic;
using System;

namespace DesakaDownloader.ParsersLibrary.Parsers
{
    public abstract class Parser
    {
        public abstract Product ExtractProduct(HtmlDocument htmlDocument);
  }
}
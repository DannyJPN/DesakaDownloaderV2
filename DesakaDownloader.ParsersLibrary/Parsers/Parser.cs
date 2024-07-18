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
        protected Uri? BaseUrl { get; set; }


        public abstract List<Uri> ExtractCategoryLinks(HtmlDocument doc);
        public abstract List<Uri> ExtractProductLinks(HtmlDocument categoryPage);
        public abstract List<Uri> ExtractCataloguePages(HtmlDocument categoryPage);
        public abstract string ExtractProductBriefDescription(HtmlDocument doc);
        public abstract string ExtractProductDescription(HtmlDocument doc);
        public abstract double ExtractProductDiscount(HtmlDocument doc);
        public abstract List<Uri> ExtractProductImageLinks(HtmlDocument doc);

        public abstract Uri ExtractProductMainImageLink(HtmlDocument doc);
        public abstract string ExtractProductName(HtmlDocument doc);
        public abstract double ExtractProductPrice(HtmlDocument doc);
        public abstract List<Variant> ExtractProductVariants(HtmlDocument doc);
        public abstract List<VariantCombination> ExtractProductVariantCombinations(HtmlDocument htmlDocument);

    }
}
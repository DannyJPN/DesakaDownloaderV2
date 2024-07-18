using HtmlAgilityPack;
using System.Collections.Generic;
using System.Web;

namespace DesakaDownloader.EntitiesLibrary.Entities.Products
{
    public abstract class Product
    {
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; }
        public double? Discount { get; set; }
        public List<string> ImageLinks { get; set; } = new List<string>();
        public string MainImageLink { get; set; } = string.Empty;
        public List<VariantCombination> VariantCombinations { get; set; } = new List<VariantCombination>();
        public string Description { get; set; } = string.Empty;
        public string BriefDescription { get; set; } = string.Empty;

        protected Product()
        {
            ImageLinks = new List<string>();
            VariantCombinations = new List<VariantCombination>();
        }

        private readonly Uri BaseUrl = new Uri("https://www.pincesobchod.cz/");

   
        public override List<Uri> ExtractCategoryLinks(HtmlDocument doc);
        public override List<Uri> ExtractProductLinks(HtmlDocument categoryPage);
        public override string ExtractProductBriefDescription(HtmlDocument doc);
        public override string ExtractProductDescription(HtmlDocument doc);
        public override double ExtractProductDiscount(HtmlDocument doc);
        public override List<Uri> ExtractProductImageLinks(HtmlDocument doc);

        public override Uri ExtractProductMainImageLink(HtmlDocument doc);
        public override string ExtractProductName(HtmlDocument doc);
        public override double ExtractProductPrice(HtmlDocument doc);
        public override List<Variant> ExtractProductVariants(HtmlDocument doc);


 










    }
}
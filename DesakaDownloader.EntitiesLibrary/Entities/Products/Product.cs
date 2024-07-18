using HtmlAgilityPack;
using System.Collections.Generic;
using System.Web;
using System.Drawing;

namespace DesakaDownloader.EntitiesLibrary.Entities.Products
{
    public abstract class Product
    {
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; }
        public double? Discount { get; set; }
        public List<Uri> ImageLinks { get; set; } = new List<Uri>();
        public Uri MainImageLink { get; set; } = null;
        public List<VariantCombination> VariantCombinations { get; set; } = new List<VariantCombination>();
        public string Description { get; set; } = string.Empty;
        public string BriefDescription { get; set; } = string.Empty;
        public Image DefaultImage { get; set; } = null;
        public List<Image?> AdditionalImages { get; set; } = new List<Image>();

        protected Product()
        {

        }



    }
}
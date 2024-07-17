using System.Collections.Generic;

namespace DesakaDownloader.EntitiesLibrary.Entities.Products
{
    public abstract class Product
    {
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; }
        public double? Discount { get; set; }
        public List<string> PhotoLinks { get; set; } = new List<string>();
        public string DefaultPhotoLink { get; set; } = string.Empty;
        public List<VariantCombination> VariantCombinations { get; set; } = new List<VariantCombination>();
        public string Description { get; set; } = string.Empty;
        public string BriefDescription { get; set; } = string.Empty;

        protected Product()
        {
            PhotoLinks = new List<string>();
            VariantCombinations = new List<VariantCombination>();
        }
    }
}
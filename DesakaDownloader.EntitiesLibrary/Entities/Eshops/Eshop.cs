using System.Collections.Generic;
using System.Threading.Tasks;
using DesakaDownloader.EntitiesLibrary.Entities.Products;
using HtmlAgilityPack;

namespace DesakaDownloader.EntitiesLibrary.Entities.Eshops
{
    public abstract class Eshop
    {
        public string BaseUrl { get; protected set; }
        public HtmlDocument MainPage { get; set; }
        public List<string> Categories { get; set; }
        public List<HtmlDocument> CategoryPages { get; set; }
        public List<HtmlDocument> ProductPages { get; set; }
        public List<Product> ExtractedProducts { get; set; }

        protected Eshop()
        {
            MainPage = new HtmlDocument();
            Categories = new List<string>();
            CategoryPages = new List<HtmlDocument>();
            ProductPages = new List<HtmlDocument>();
            ExtractedProducts = new List<Product>();
        }

        public abstract Task LoadCategoryPagesAsync();
        public abstract Task LoadProductPagesAsync();
    }
}
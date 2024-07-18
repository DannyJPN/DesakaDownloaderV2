using HtmlAgilityPack;
using DesakaDownloader.EntitiesLibrary.Entities.Products;
using System.Collections.Generic;

namespace DesakaDownloader.ParsersLibrary.Parsers
{
    public class NittakuParser : Parser
    {
        public override List<Uri> ExtractCataloguePages(HtmlDocument categoryPage)
        {
            throw new NotImplementedException();
        }

        public override List<Uri> ExtractCategoryLinks(HtmlDocument doc)
        {
            throw new NotImplementedException();
        }

        public override Product ExtractProduct(HtmlDocument htmlDocument)
        {
            NittakuProduct product = new NittakuProduct
            {
                Name = ExtractProductName(htmlDocument),
                Price = ExtractProductPrice(htmlDocument),
                Discount = ExtractProductDiscount(htmlDocument),
                ImageLinks = ExtractProductImageLinks(htmlDocument),
                MainImageLink = ExtractProductMainImageLink(htmlDocument),
                VariantCombinations = ExtractProductVariantCombinations(htmlDocument),
                Description = ExtractProductDescription(htmlDocument),
                BriefDescription = ExtractProductBriefDescription(htmlDocument)
            };

            
            

            return product;
        }

        public override string ExtractProductBriefDescription(HtmlDocument doc)
        {
            throw new NotImplementedException();
        }

        public override string ExtractProductDescription(HtmlDocument doc)
        {
            throw new NotImplementedException();
        }

        public override double ExtractProductDiscount(HtmlDocument doc)
        {
            throw new NotImplementedException();
        }

        public override List<Uri> ExtractProductImageLinks(HtmlDocument doc)
        {
            throw new NotImplementedException();
        }

        public override List<Uri> ExtractProductLinks(HtmlDocument categoryPage)
        {
            throw new NotImplementedException();
        }

        public override Uri ExtractProductMainImageLink(HtmlDocument doc)
        {
            throw new NotImplementedException();
        }

        public override string ExtractProductName(HtmlDocument doc)
        {
            throw new NotImplementedException();
        }

        public override double ExtractProductPrice(HtmlDocument doc)
        {
            throw new NotImplementedException();
        }

        public override List<VariantCombination> ExtractProductVariantCombinations(HtmlDocument htmlDocument)
        {
            throw new NotImplementedException();
        }

        public override List<Variant> ExtractProductVariants(HtmlDocument doc)
        {
            throw new NotImplementedException();
        }
    }
}
using HtmlAgilityPack;
using DesakaDownloader.EntitiesLibrary.Entities.Products;
using System.Collections.Generic;

namespace DesakaDownloader.ParsersLibrary.Parsers
{
    public class NittakuParser : Parser
    {
        public override Product ParseHtml(HtmlDocument htmlDocument)
        {
            NittakuProduct product = new NittakuProduct
            {
                Name = ExtractProductName(htmlDocument),
                Price = ExtractProductPrice(htmlDocument),
                Discount = ExtractProductDiscount(htmlDocument),
                PhotoLinks = ExtractProductPhotoLinks(htmlDocument),
                DefaultPhotoLink = ExtractProductDefaultPhotoLink(htmlDocument),
                VariantCombinations = ExtractProductVariantCombinations(htmlDocument),
                Description = ExtractProductDescription(htmlDocument),
                BriefDescription = ExtractProductBriefDescription(htmlDocument)
            };

            
            

            return product;
        }

        private string ExtractProductName(HtmlDocument htmlDocument)
        {
            return htmlDocument.DocumentNode.SelectSingleNode("//h1").InnerText.Trim();
        }

        private double ExtractProductPrice(HtmlDocument htmlDocument)
        {
            HtmlNode priceNode = htmlDocument.DocumentNode.SelectSingleNode("//span[@class='price']");
            return double.Parse(priceNode.InnerText.Trim().Replace("€", ""));
        }

        private double? ExtractProductDiscount(HtmlDocument htmlDocument)
        {
            HtmlNode discountNode = htmlDocument.DocumentNode.SelectSingleNode("//span[@class='discount']");
            if (discountNode != null)
            {
                return double.Parse(discountNode.InnerText.Trim().Replace("€", ""));
            }
            return null;
        }

        private List<string> ExtractProductPhotoLinks(HtmlDocument htmlDocument)
        {
            HtmlNodeCollection photoNodes = htmlDocument.DocumentNode.SelectNodes("//div[@class='product-images']//img");
            List<string> photoLinks = new List<string>();
            foreach (HtmlNode node in photoNodes)
            {
                photoLinks.Add(node.GetAttributeValue("src", ""));
            }
            return photoLinks;
        }

        private string ExtractProductDefaultPhotoLink(HtmlDocument htmlDocument)
        {
            HtmlNode defaultPhotoNode = htmlDocument.DocumentNode.SelectSingleNode("//div[@class='product-main-image']//img");
            return defaultPhotoNode.GetAttributeValue("src", "");
        }

        private List<VariantCombination> ExtractProductVariantCombinations(HtmlDocument htmlDocument)
        {
            List<VariantCombination> variantCombinations = new List<VariantCombination>();
            HtmlNodeCollection variantNodes = htmlDocument.DocumentNode.SelectNodes("//div[@class='product-variants']//select");
            foreach (HtmlNode node in variantNodes)
            {
                VariantCombination variantCombination = new VariantCombination();
                HtmlNodeCollection options = node.SelectNodes(".//option");
                foreach (HtmlNode option in options)
                {
                    variantCombination.Variants.Add(new Variant
                    {
                        Name = node.GetAttributeValue("name", ""),
                        Value = option.InnerText.Trim()
                    });
                }
                variantCombinations.Add(variantCombination);
            }
            return variantCombinations;
        }

        private string ExtractProductDescription(HtmlDocument htmlDocument)
        {
            HtmlNode descriptionNode = htmlDocument.DocumentNode.SelectSingleNode("//div[@class='product-description']");
            return descriptionNode.InnerHtml.Trim();
        }

        private string ExtractProductBriefDescription(HtmlDocument htmlDocument)
        {
            HtmlNode shortDescriptionNode = htmlDocument.DocumentNode.SelectSingleNode("//div[@class='product-short-description']");
            return shortDescriptionNode.InnerHtml.Trim();
        }
    }
}
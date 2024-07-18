using HtmlAgilityPack;
using DesakaDownloader.EntitiesLibrary.Entities.Products;
using System.Collections.Generic;
using DesakaDownloader.ParsersLibrary.Helpers;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using DesakaDownloader.Downloader;
using DesakaDownloader.Downloader.Services;

namespace DesakaDownloader.ParsersLibrary.Parsers
{
    public class PincesobchodSkParser : Parser
    {
        public override Product ExtractProduct(HtmlDocument htmlDocument)
        {
            PincesobchodSkProduct product = new PincesobchodSkProduct
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


        private readonly string percentPattern = "[0-9]{1,3}%";
        private readonly string usualPriceName = "Doporučená cena (s DPH):";
        private readonly string mainPriceName = "Naša cena s DPH:";

        public override List<Uri> ExtractCataloguePages(HtmlDocument categoryPage)
        {
            List<Uri> cataloguePages = new List<Uri>();
            HtmlNodeCollection pageNodeLinks = categoryPage.DocumentNode.SelectNodes("//div[@class='stranky']//a");
            if (pageNodeLinks != null)
            {
                cataloguePages = pageNodeLinks
                    .Select(anchor => new Uri(BaseUrl, HttpUtility.HtmlDecode(anchor.GetAttributeValue("href", string.Empty))))
                    .Distinct().ToList();
            }
            return cataloguePages;

        }

        public override List<Uri> ExtractCategoryLinks(HtmlDocument doc)
        {
            // Implement code to extract category links from the HTML document using HtmlAgilityPack
            List<Uri> categoryLinks = new List<Uri>();

            // Use XPath to find all anchor tags with category links
            HtmlNode categoryContainer = doc.DocumentNode.SelectSingleNode("//div[@id='kategorie']");
            if (categoryContainer != null)
            {
                HtmlNodeCollection anchors = categoryContainer.SelectNodes(".//a");

                categoryLinks = anchors
                    .Select(anchor => new Uri(BaseUrl, HttpUtility.HtmlDecode(anchor.GetAttributeValue("href", string.Empty))))
                    .Distinct().ToList();


            }

            return categoryLinks;
        }

        public override List<Uri> ExtractProductLinks(HtmlDocument categoryPage)
        {
            // Implement code to extract product links from the category page HTML document using HtmlAgilityPack
            List<Uri> productLinks = new List<Uri>();

            // Use XPath to find all anchor tags with product links

            HtmlNodeCollection productAnchorNodes = categoryPage.DocumentNode.SelectNodes("//table[@id='vypis']//a");


            if (productAnchorNodes != null)
            {
                productLinks = productAnchorNodes
                    .Select(anchor => new Uri(BaseUrl, HttpUtility.HtmlDecode(anchor.GetAttributeValue("href", string.Empty))))
                    .Distinct().ToList();
            }

            return productLinks;
        }
        public override string ExtractProductBriefDescription(HtmlDocument doc)
        {
            // Implement code to extract product brief description from the HTML document using HtmlAgilityPack
            HtmlNode briefDescriptionNode = doc.DocumentNode.SelectSingleNode("//div[@id='popis_detail']");
            return briefDescriptionNode == null ? "" : briefDescriptionNode?.InnerText.Trim();
        }

        public override string ExtractProductDescription(HtmlDocument doc)
        {
            // Implement code to extract product description from the HTML document using HtmlAgilityPack
            HtmlNode descriptionNode = doc.DocumentNode.SelectSingleNode("//div[@id='popis_detail']");
            return descriptionNode == null ? "" : descriptionNode?.InnerHtml.Trim();
        }

        public override double ExtractProductDiscount(HtmlDocument doc)
        {
            double discount = 0.0;
            // Implement code to extract product discount from the HTML document using HtmlAgilityPack
            HtmlNodeCollection discountNodes = doc.DocumentNode.SelectNodes("//td[@class='detail_parametr_hodnota1']");
            if (discountNodes == null)
            {
                return discount;
            }
            List<string> discounts = discountNodes.Where(node => Regex.IsMatch(node.InnerText, percentPattern))
            .Select(node => GeneralHelper.ExtractIntegerString(node.InnerText.Trim()))
            .ToList();

            if (discounts == null || discounts.Count <= 0)
            {
                return discount;
            }
            string discountText = discounts[0];
            if (discountText != null && double.TryParse(discountText, out discount))
            {
                return discount;
            }

            return discount;
        }

        public override List<Uri> ExtractProductImageLinks(HtmlDocument doc)
        {
            DownloaderService pageDownloader = new DownloaderService();
            // Implement code to extract product image links from the HTML document using HtmlAgilityPack
            List<Uri> imageLinks = new List<Uri>();

            // Use XPath to find all img tags with product images
            HtmlNode galleryLink = doc.DocumentNode.SelectSingleNode("//div[@id='detail_foto']//a");
            if (galleryLink == null)
            {
                return imageLinks;
            }
            string galleryUrl = new Uri(BaseUrl, galleryLink.GetAttributeValue("href", string.Empty)).ToString();
            Task<HtmlDocument> galleryPage = pageDownloader.DownloadWebPageAsHtmlAsync(galleryUrl);
            //galleryPage.Start();
            galleryPage.Wait();
            if (!galleryPage.IsCompleted || galleryPage.Result == null)
            {
                return imageLinks;

            }
            HtmlDocument gallery = galleryPage.Result;
            HtmlNodeCollection galleryLinks = gallery.DocumentNode.SelectNodes("//img");
            if (galleryLinks != null)
            {
                imageLinks = galleryLinks
                    .Select(anchor => new Uri(BaseUrl, anchor.GetAttributeValue("src", string.Empty)))
                    .Distinct().ToList();
            }

            return imageLinks;
        }


        public override Uri ExtractProductMainImageLink(HtmlDocument doc)
        {
            // Implement code to extract the main product image link from the HTML document using HtmlAgilityPack
            HtmlNode mainImageNode = doc.DocumentNode.SelectSingleNode("//div[contains(@id, 'detail_foto')]//img");
            return mainImageNode != null ? new Uri(BaseUrl, mainImageNode.GetAttributeValue("src", string.Empty)) : null;
        }

        public override string ExtractProductName(HtmlDocument doc)
        {
            // Implement code to extract product name from the HTML document using HtmlAgilityPack
            HtmlNode productNameNode = doc.DocumentNode.SelectSingleNode("//div[@id='work']//h1");
            return productNameNode == null ? "" : productNameNode?.InnerText.Trim();
        }

        public override double ExtractProductPrice(HtmlDocument doc)
        {
            // Implement code to extract product price from the HTML document using HtmlAgilityPack
            HtmlNode priceNode = doc.DocumentNode.SelectSingleNode("//table[@id='detail_parametry']");
            double price = 0.0;
            if (priceNode == null)
            {
                return price;
            }
            HtmlNodeCollection rows = priceNode.SelectNodes("//tr");
            HtmlNode usualPriceNode = rows.Where(row => row.SelectSingleNode("//td[@class='detail_parametr_nazev1']").InnerText == usualPriceName).FirstOrDefault();
            HtmlNode mainPriceNode = rows.Where(row => row.SelectSingleNode("//td[@class='detail_parametr_nazev1']").InnerText == mainPriceName).FirstOrDefault();
            if (mainPriceNode == null)
            {
                return price;
            }
            string textPrice = GeneralHelper.ExtractIntegerString(mainPriceNode.InnerText.Trim());
            if (usualPriceNode != null)
            {
                textPrice = GeneralHelper.ExtractIntegerString(usualPriceNode.InnerText.Trim());
            }
            if (mainPriceNode != null && double.TryParse(textPrice, out price))
            {

                return price;
            }

            return price;
        }

        public override List<Variant> ExtractProductVariants(HtmlDocument doc)
        {
            // Implement code to extract product variants from the HTML document using HtmlAgilityPack
            List<Variant> variants = new List<Variant>();

            // Use XPath to find all option elements with variants
            HtmlNodeCollection variantOptionNodes = doc.DocumentNode.SelectNodes("//td[@id='detail_varianty']//select");
            if (variantOptionNodes != null)
            {
                foreach (HtmlNode variant in variantOptionNodes)
                {


                    string variantName = variant.GetAttributeValue("name", "varianta");
                    HtmlNodeCollection options = variant.SelectNodes("option");
                    foreach (HtmlNode option in options)
                    {
                        string variantValue = option.InnerText.Trim();
                        variants.Add(new Variant(variantName, variantValue));
                    }

                }
            }

            return variants;
        }

   
        public override List<VariantCombination> ExtractProductVariantCombinations(HtmlDocument htmlDocument)
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


    }
}
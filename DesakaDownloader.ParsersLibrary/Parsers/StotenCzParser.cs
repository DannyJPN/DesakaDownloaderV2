using HtmlAgilityPack;
using DesakaDownloader.EntitiesLibrary.Entities.Products;
using System.Collections.Generic;
using System.Drawing;
using DesakaDownloader.ParsersLibrary.Helpers;
using System.Text.RegularExpressions;
using System.Web;

namespace DesakaDownloader.ParsersLibrary.Parsers
{
    public class StotenCzParser : Parser
    {
        public override Product ExtractProduct(HtmlDocument htmlDocument)
        {
            StotenCzProduct product = new StotenCzProduct
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


        private readonly string cataloguePattern = "strana-[0-9]*";
        private readonly string numberPattern = "^[0-9]*$";
        private readonly string UNWANTED = "znacka|mini-|bazar|vyprodej|poukaz|stoten-cz|karticky|/palky/|komplet|hobby";
        public override List<Uri> ExtractCataloguePages(HtmlDocument categoryPage)
        {
            HtmlNode cataloguePageNode = categoryPage.DocumentNode.SelectSingleNode("//div[contains(@class,'pagination')]");
            if (cataloguePageNode == null)
            {
                return new List<Uri>();
            }
            List<Uri> cataloguePages =
                cataloguePageNode.SelectNodes("//span//a[contains(@href,'strana')]")
                .Select(anchor => new Uri(BaseUrl, HttpUtility.HtmlDecode(anchor.GetAttributeValue("href", string.Empty))))
                .Where(link => link.ToString().IndexOf("strana-") >= 0)
                .Distinct().ToList();
            HtmlNode nextButton = cataloguePageNode.SelectSingleNode("//a[@class='s-page pagination-page']");
            int lastPage = 0;
            if (nextButton != null)
            {
                Uri lastLink = cataloguePages.Last();
                string link = lastLink.ToString();
                if (link.Length > 0)
                {
                    lastPage = Convert.ToInt32(
                        link.Split('/')
                        .Where(part => Regex.Match(part, cataloguePattern).Success).Last()
                        .Split('-')
                        .Where(subpart => Regex.Match(subpart, numberPattern).Success).Last()
                        );
                }
            }
            else
            {
                Uri lastLink = cataloguePages.Last();
                string link = lastLink.ToString();
                if (link.Length > 0)
                {
                    lastPage = Convert.ToInt32(
                        link.Split('/')
                        .Where(part => Regex.Match(part, cataloguePattern).Success).Last()
                        .Split('-')
                        .Where(subpart => Regex.Match(subpart, numberPattern).Success).Last()
                        ) + 1;
                }
            }
            for (int i = 1; i <= lastPage; i++)
            {
                Uri nextPageUri = new Uri(String.Format("{0}-{1}/", cataloguePages[0].ToString().Substring(0, cataloguePages[0].ToString().LastIndexOf('-')), i.ToString()));
                int urlIndex = cataloguePages.IndexOf(nextPageUri);
                if (urlIndex < 0)
                {
                    cataloguePages.Insert(i - 1, nextPageUri);
                }

            }
            return cataloguePages;

        }

        public override List<Uri> ExtractCategoryLinks(HtmlDocument doc)
        {
            // Implement code to extract category links from the HTML document using HtmlAgilityPack
            List<Uri> categoryLinks = new List<Uri>();

            HtmlNodeCollection categoryAnchorNodes = doc.DocumentNode.SelectNodes("//div[@id='categories']//a");

            if (categoryAnchorNodes != null)
            {
                categoryLinks = categoryAnchorNodes
                    .Where(anchor => !Regex.Match(HttpUtility.HtmlDecode(anchor.GetAttributeValue("href", string.Empty)), UNWANTED).Success)
                    .Select(anchor => new Uri(BaseUrl, HttpUtility.HtmlDecode(anchor.GetAttributeValue("href", string.Empty))))
                    .Distinct().ToList();
            }

            return categoryLinks;
        }

        public override string ExtractProductBriefDescription(HtmlDocument doc)
        {
            // Implement code to extract product brief description from the HTML document using HtmlAgilityPack
            HtmlNode briefDescriptionNode = doc.DocumentNode.SelectSingleNode("//div[@id='description']");
            return briefDescriptionNode == null ? "" : briefDescriptionNode?.InnerText.Trim();
        }

        public override string ExtractProductDescription(HtmlDocument doc)
        {
            // Implement code to extract product description from the HTML document using HtmlAgilityPack
            HtmlNode descriptionNode = doc.DocumentNode.SelectSingleNode("//div[@id='description']");
            return descriptionNode == null ? "" : descriptionNode?.InnerHtml.Trim();
        }

        public override double ExtractProductDiscount(HtmlDocument doc)
        {
            // Implement code to extract product discount from the HTML document using HtmlAgilityPack
            HtmlNode discountNode = doc.DocumentNode.SelectSingleNode("//td[@class='td-save-price']");
            double discount = 0.0;
            if (discountNode != null)
            {


                string innerText = discountNode.InnerText.Trim();
                if (innerText.IndexOf("(") < innerText.IndexOf(")"))
                {
                    if (double.TryParse(GeneralHelper.ExtractIntegerString(discountNode.InnerText.Trim().Substring(innerText.IndexOf("("), innerText.IndexOf(")") - innerText.IndexOf("("))), out discount))
                    {
                        HtmlNodeCollection truePriceNodes = doc.DocumentNode.SelectNodes("//tr[@data-testid='productVariant']//strike");
                        HtmlNodeCollection variantNodes = doc.DocumentNode.SelectNodes("//tr[@data-testid='productVariant']");
                        if (variantNodes == null || truePriceNodes == null || variantNodes.Count <= 0 || truePriceNodes.Count <= 0)
                        { return discount; }

                        if (variantNodes.Count != truePriceNodes.Count)
                        {
                            return 0;
                        }
                        return discount;
                    }
                }
            }


            return discount;
        }

        public override List<Uri> ExtractProductImageLinks(HtmlDocument doc)
        {
            // Implement code to extract product image links from the HTML document using HtmlAgilityPack
            List<Uri> imageLinks = new List<Uri>();

            // Use XPath to find all img tags with product images
            HtmlNodeCollection imageNodes = doc.DocumentNode.SelectNodes("//div[@class='listing-product-more-images']//a[@data-gallery='lightbox[gallery]']");
            if (imageNodes != null)
            {

                imageLinks = imageNodes
                    .Select(image => new Uri(image.GetAttributeValue("href", string.Empty)))
                    .Distinct().ToList();
            }

            return imageLinks;
        }

        public override List<Uri> ExtractProductLinks(HtmlDocument categoryPage)
        {
            // Implement code to extract product links from the category page HTML document using HtmlAgilityPack
            List<Uri> productLinks = new List<Uri>();

            // Use XPath to find all anchor tags with product links
            HtmlNodeCollection productAnchorNodes = categoryPage.DocumentNode.SelectNodes("//span[@class='button-product-wrap button-wrap']//a");
            if (productAnchorNodes != null)
            {
                productLinks = productAnchorNodes
                    .Select(anchor => new Uri(BaseUrl, HttpUtility.HtmlDecode(anchor.GetAttributeValue("href", string.Empty))))
                    .Distinct().ToList();
            }

            return productLinks;
        }

        public override Uri ExtractProductMainImageLink(HtmlDocument doc)
        {
            // Implement code to extract the main product image link from the HTML document using HtmlAgilityPack
            HtmlNode mainImageNode = doc.DocumentNode.SelectSingleNode("//a[@id='gallery-image']");
            if (mainImageNode != null)
            {
                string urlText = mainImageNode.GetAttributeValue("href", string.Empty);
                if (urlText.Length > 0 && !Regex.IsMatch(urlText, BaseUrl.ToString()))
                {
                    return new Uri(BaseUrl, urlText);
                }
                else
                {
                    return new Uri(urlText);
                }
            }

            return null;


        }

        public override string ExtractProductName(HtmlDocument doc)
        {
            // Implement code to extract product name from the HTML document using HtmlAgilityPack
            HtmlNode productNameNode = doc.DocumentNode.SelectSingleNode("//h1[@itemprop='name']");
            return productNameNode == null ? "" : productNameNode.InnerText.Trim();
        }

        public override double ExtractProductPrice(HtmlDocument doc)
        {
            // Implement code to extract product price from the HTML document using HtmlAgilityPack
            var priceNode = doc.DocumentNode.SelectSingleNode("//span[@class='product-price']");
            double price = 0.0;

            if (priceNode != null && double.TryParse(priceNode.InnerText.Trim(), out price))
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
            HtmlNodeCollection variantOptionNodes = doc.DocumentNode.SelectNodes("//td[@class='variant']");
            if (variantOptionNodes != null)
            {
                foreach (HtmlNode option in variantOptionNodes)
                {
                    string[] variantsTexts = option.InnerHtml.Trim().Replace("<br>", ";").Split(';');
                    foreach (string variantText in variantsTexts)
                    {
                        if (variantText.Split(':').Length > 1)
                        {


                            string variantName = variantText.Split(':')[0].Trim();
                            string variantValue = variantText.Split(':')[1].Trim();
                            Variant newvar = new Variant(variantName, variantValue);
                            if (!variants.Contains(newvar))
                            {
                                variants.Add(newvar);
                            }
                        }
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
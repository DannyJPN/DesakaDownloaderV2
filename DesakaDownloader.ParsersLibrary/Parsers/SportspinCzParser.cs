using HtmlAgilityPack;
using DesakaDownloader.EntitiesLibrary.Entities.Products;
using System.Collections.Generic;
using DesakaDownloader.ParsersLibrary.Helpers;
using System.Text.RegularExpressions;
using System.Web;

namespace DesakaDownloader.ParsersLibrary.Parsers
{
    public class SportspinCzParser : Parser
    {
        public override Product ExtractProduct(HtmlDocument htmlDocument)
        {
            SportspinCzProduct product = new SportspinCzProduct
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
        private readonly string UNWANTED = "kamenna-prodejna-v-prazskych-modranech|platebni-moznosti|doprava|obchodni-podminky|palk|akce|vyprodej";
        public override List<Uri> ExtractCataloguePages(HtmlDocument categoryPage)
        {
            List<Uri> cataloguePages = new List<Uri>();
            HtmlNode cataloguePageNode = categoryPage.DocumentNode.SelectSingleNode("//div[@class='pagination']");
            HtmlNodeCollection productNodes = categoryPage.DocumentNode.SelectNodes("//div[@class='product']");
            if (cataloguePageNode == null && productNodes == null)
            {
                return new List<Uri>();
            }
            if (productNodes == null)
            {
                return new List<Uri>();
            }
            int lastPage = 1;
            if (cataloguePageNode != null)
            {
                cataloguePages = cataloguePageNode.SelectNodes("//a[contains(@class,'pagination-link')]")
                    .Select(anchor => new Uri(BaseUrl, HttpUtility.HtmlDecode(anchor.GetAttributeValue("href", string.Empty))))
                    .Where(link => link.ToString().IndexOf("strana-") >= 0)
                    .Distinct().ToList();
                HtmlNode nextButton = cataloguePageNode.SelectSingleNode("//a[@class='next pagination-link']");

                if (nextButton != null)
                {
                    Uri lastLink = cataloguePageNode.SelectNodes("//a")
                         .Select(anchor => new Uri(BaseUrl, HttpUtility.HtmlDecode(anchor.GetAttributeValue("href", string.Empty))))
                        .Where(pageLink => pageLink.ToString().IndexOf("strana-") >= 0)
                        .Distinct().ToList().Last();
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
                    HtmlNode lastLink = cataloguePageNode.SelectSingleNode("//strong[@class='current']");
                    Int32.TryParse(lastLink.InnerText.Trim(), out lastPage);
                }
            }
            if (cataloguePages == null || cataloguePages.Count <= 0)
            {
                HtmlNode selfLinkNode = categoryPage.DocumentNode.SelectSingleNode("//fieldset//input[@name='referer']");
                string selfLink = selfLinkNode.GetAttributeValue("value", string.Empty);
                if (selfLink != "")
                {
                    cataloguePages.Add(new Uri(BaseUrl, selfLink));
                }
                return cataloguePages;
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

            // Use XPath to find all anchor tags with category links
            HtmlNode categoryAnchorNode = doc.DocumentNode.SelectSingleNode("//nav[@id='navigation']");
            HtmlNodeCollection categoryLinkNodes = doc.DocumentNode.SelectNodes("//nav[@id='navigation']//a[@data-testid='headerMenuItem']");
            if (categoryLinkNodes != null)
            {
                categoryLinks = categoryLinkNodes
                    .Select(anchor => new Uri(BaseUrl, HttpUtility.HtmlDecode(anchor.GetAttributeValue("href", string.Empty))))
                    .Where(item => !Regex.Match(item.ToString().Trim().Trim('/').Split('/').Last(), UNWANTED).Success)
                    .Distinct().ToList();
            }

            return categoryLinks.Distinct().ToList();
        }

        public override string ExtractProductBriefDescription(HtmlDocument doc)
        {
            // Implement code to extract product brief description from the HTML document using HtmlAgilityPack
            HtmlNode briefDescriptionNode = doc.DocumentNode.SelectSingleNode("//div[@class='p-short-description']");
            return briefDescriptionNode == null ? "" : briefDescriptionNode?.InnerText.Trim();
        }

        public override string ExtractProductDescription(HtmlDocument doc)
        {
            // Implement code to extract product description from the HTML document using HtmlAgilityPack
            HtmlNode descriptionNode = doc.DocumentNode.SelectSingleNode("//div[@class='basic-description']");
            return descriptionNode == null ? "" : descriptionNode?.InnerHtml.Trim();
        }

        public override double ExtractProductDiscount(HtmlDocument doc)
        {
            // Implement code to extract product discount from the HTML document using HtmlAgilityPack
            double discount = 0.0;

            HtmlNode discountNode = doc.DocumentNode.SelectSingleNode("//div[@class='p-final-price-wrapper']//span[@class='price-save']");


            if (discountNode != null && double.TryParse(GeneralHelper.ExtractIntegerString(discountNode.InnerText.Trim()), out discount))
            {
                return discount;
            }

            return discount;
        }

        public override List<Uri> ExtractProductImageLinks(HtmlDocument doc)
        {
            // Implement code to extract product image links from the HTML document using HtmlAgilityPack
            List<Uri> imageLinks = new List<Uri>();

            // Use XPath to find all img tags with product images
            HtmlNodeCollection imageNodes = doc.DocumentNode.SelectNodes("//a[contains(@class,'p-thumbnail')]");
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
            if (categoryPage == null)
            {
                return productLinks;
            }
            // Use XPath to find all anchor tags with product links
            HtmlNodeCollection productAnchorNodes = categoryPage.DocumentNode.SelectNodes("//a[@class='name']");
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
            HtmlNode mainImageNode = doc.DocumentNode.SelectSingleNode("//a[contains(@class, 'p-main-image')]");
            string mainImageUri = mainImageNode.GetAttributeValue("href", string.Empty);
            if (!Regex.IsMatch(mainImageUri, BaseUrl.Host))
            {
                return new Uri(BaseUrl, mainImageUri);
            }

            return mainImageNode != null ? new Uri(mainImageUri) : null;
        }

        public override string ExtractProductName(HtmlDocument doc)
        {
            // Implement code to extract product name from the HTML document using HtmlAgilityPack
            HtmlNode productNameNode = doc.DocumentNode.SelectSingleNode("//div[contains(@class,'p-detail-inner-header')]//h1");
            return productNameNode?.InnerText.Trim();
        }

        public override double ExtractProductPrice(HtmlDocument doc)
        {
            double price = 0.0;

            // Implement code to extract product price from the HTML document using HtmlAgilityPack
            HtmlNode discountNode = doc.DocumentNode.SelectSingleNode("//div[@class='p-final-price-wrapper']//span[@class='price-save']");
            HtmlNode priceNodeFinal = doc.DocumentNode.SelectSingleNode("//div[@class='p-final-price-wrapper']//span[@class='price-final-holder']");
            HtmlNode priceNodeStandard = doc.DocumentNode.SelectSingleNode("//div[@class='p-final-price-wrapper']//span[@class='price-standard']");
            HtmlNodeCollection variantPriceNodes = doc.DocumentNode.SelectNodes("//div[@class='price-final']");

            if (discountNode != null)
            {
                if (priceNodeStandard != null && double.TryParse(GeneralHelper.ExtractIntegerString(priceNodeStandard.InnerText.Trim()), out price))
                {
                    return price;
                }
                price = variantPriceNodes
                        .Select(varPriceNode => Convert.ToDouble(GeneralHelper.ExtractIntegerString(varPriceNode.InnerText.Trim())))
                        .Distinct().ToList().Max();
            }
            else
            {
                if (priceNodeFinal != null && double.TryParse(GeneralHelper.ExtractIntegerString(priceNodeFinal.InnerText.Trim()), out price))
                {
                    return price;
                }
            }



            return price;
        }

        public override List<Variant> ExtractProductVariants(HtmlDocument doc)
        {
            // Implement code to extract product variants from the HTML document using HtmlAgilityPack
            List<Variant> variants = new List<Variant>();

            // Use XPath to find all option elements with variants
            HtmlNodeCollection variantOptionNodes = doc.DocumentNode.SelectNodes("//div[@class='variant-name']");
            if (variantOptionNodes != null)
            {
                foreach (HtmlNode option in variantOptionNodes)
                {
                    string[] variantsTexts = option.InnerText.Trim().Replace(", ", ";").Split(';');
                    foreach (string variantText in variantsTexts)
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
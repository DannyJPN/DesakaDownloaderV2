using HtmlAgilityPack;
using DesakaDownloader.EntitiesLibrary.Entities.Products;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DesakaDownloader.EntitiesLibrary.Entities.Eshops;


namespace DesakaDownloader.ParsersLibrary.Parsers
{
    public class PincesobchodCzParser : Parser
    {
        
        public override Product ExtractProduct(HtmlDocument htmlDocument)
        {
            PincesobchodCzProduct product = new PincesobchodCzProduct
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


        public PincesobchodCzParser()
        {
            BaseUrl = new PincesobchodCzEshop().BaseUrl;
        }

        private string[] UNWANTED = new string[] { "Kat. č.", "Cena včetně DPH", "Dostupnost" };

        public override List<Uri> ExtractCategoryLinks(HtmlDocument doc)
        {
            // Implement code to extract category links from the HTML document using HtmlAgilityPack
            List<Uri> categoryLinks = new List<Uri>();

            // Use XPath to find all anchor tags with category links
            HtmlNode categoryContainer = doc.DocumentNode.SelectSingleNode("//div[@class='box category first']");
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
            HtmlNodeCollection productAnchorNodes = categoryPage.DocumentNode.SelectNodes("//div[@class='item']//a[@class='title']");
            if (productAnchorNodes != null)
            {
                productLinks = productAnchorNodes
                    .Select(anchor => new Uri(BaseUrl, HttpUtility.HtmlDecode(anchor.GetAttributeValue("href", string.Empty))))
                    .Distinct().ToList();
            }

            return productLinks;
        }
        public override List<Uri> ExtractCataloguePages(HtmlDocument categoryPage)
        {
            // Implement code to extract product links from the category page HTML document using HtmlAgilityPack
            List<Uri> cataloguePages = new List<Uri>();
            //HashSet<string> catalogueLinks = new HashSet<string>();
            // Use XPath to find all anchor tags with product links
            List<HtmlNode> nextButtons = new List<HtmlNode>();
            HtmlNodeCollection cataloguePageNodes = categoryPage.DocumentNode.SelectNodes("//a[@class='ajax']");
            if (cataloguePageNodes != null)
            {
                cataloguePages = cataloguePageNodes
                    .Where(anchor => (HttpUtility.HtmlDecode(anchor.GetAttributeValue("href", string.Empty)).Contains("page=") && !anchor.Attributes.Contains("rel")))
                    .Select(anchor => new Uri(BaseUrl, HttpUtility.HtmlDecode(anchor.GetAttributeValue("href", string.Empty))))
                    .Distinct().ToList();
                nextButtons = cataloguePageNodes
                                    .Where(anchor => (anchor.GetAttributeValue("rel", string.Empty) == "next"))
                                    .Distinct().ToList();
            }

            if (cataloguePageNodes == null && cataloguePageNodes.Count <= 0)
            {
                return cataloguePages;
            }

            int lastPage = 1;

            if (cataloguePages.Count <= 0)
            {
                HtmlNode selfLinkNode = categoryPage.DocumentNode.SelectSingleNode("//link[@rel='canonical']");
                string selfLink = selfLinkNode.GetAttributeValue("href", string.Empty);
                if (selfLink != "")
                {
                    cataloguePages.Add(new Uri(BaseUrl, selfLink));
                }
                return cataloguePages;

            }
            lastPage = Convert.ToInt32(cataloguePages.Last().ToString().Split('=').Last());
            if (nextButtons.Count <= 0)
            {
                lastPage++;
            }

            for (int i = 1; i <= lastPage; i++)
            {
                Uri nextPageUri = new Uri(String.Format("{0}={1}", cataloguePages[0].ToString().Split('=')[0], i.ToString()));
                int urlIndex = cataloguePages.IndexOf(nextPageUri);
                if (urlIndex < 0)
                {
                    cataloguePages.Insert(i - 1, nextPageUri);
                }

            }
            return cataloguePages;
        }

        public override string ExtractProductBriefDescription(HtmlDocument doc)
        {
            // Implement code to extract product brief description from the HTML document using HtmlAgilityPack
            HtmlNode briefDescriptionNode = doc.DocumentNode.SelectSingleNode("//div[@class='anotation']");
            return briefDescriptionNode == null ? "" : briefDescriptionNode?.InnerText.Trim();
        }

        public override string ExtractProductDescription(HtmlDocument doc)
        {
            // Implement code to extract product description from the HTML document using HtmlAgilityPack
            HtmlNode descriptionNode = doc.DocumentNode.SelectSingleNode("//div[@itemprop='description']");
            return descriptionNode == null ? "" : descriptionNode?.InnerHtml.Trim();
        }

        public override double ExtractProductDiscount(HtmlDocument doc)
        {
            // Implement code to extract product discount from the HTML document using HtmlAgilityPack
            double commonPrice = ExtractProductPrice(doc);
            double discountedPrice = 0.0;
            double discount = 0.0;
            // Implement code to extract product price from the HTML document using HtmlAgilityPack
            HtmlNode priceNode = doc.DocumentNode.SelectSingleNode("//div[@class='prices']");
            if (priceNode == null)
            {
                return discount;
            }

            HtmlNode mainPriceNode = priceNode.SelectSingleNode("//div[@class='main-price']");
            string textPrice = Helpers.GeneralHelper.ExtractIntegerString(mainPriceNode.InnerText.Trim());

            if (mainPriceNode != null && double.TryParse(textPrice, out discountedPrice))
            {

                discount = 100 - Math.Round(discountedPrice * 100 / commonPrice);
            }

            return discount;
        }

        public override List<Uri> ExtractProductImageLinks(HtmlDocument doc)
        {
            // Implement code to extract product image links from the HTML document using HtmlAgilityPack
            List<Uri> imageLinks = new List<Uri>();

            // Use XPath to find all img tags with product images
            HtmlNode imageNode = doc.DocumentNode.SelectSingleNode("//ul[@id='product-images']");
            if (imageNode == null)
            {
                return imageLinks;
            }
            HtmlNodeCollection listItems = imageNode.SelectNodes("//a[contains(@data-rel,'product')]");
            if (listItems != null)
            {
                imageLinks = listItems
                    .Select(anchor => new Uri(BaseUrl, HttpUtility.HtmlDecode(anchor.GetAttributeValue("href", string.Empty))))
                    .Distinct().ToList();
            }

            return imageLinks;
        }


        public override Uri ExtractProductMainImageLink(HtmlDocument doc)
        {
            // Implement code to extract the main product image link from the HTML document using HtmlAgilityPack
            string imageLink = "";
            // Use XPath to find all img tags with product images
            HtmlNode imageNode = doc.DocumentNode.SelectSingleNode("//div[contains(@class,'main-image')]");

            if (imageNode != null)
            {
                HtmlNode imageLinkNode = imageNode.SelectSingleNode(".//a");
                imageLink = imageLinkNode.GetAttributeValue("href", string.Empty);
                return new Uri(BaseUrl, imageLink);
            }

            return null;
        }

        public override string ExtractProductName(HtmlDocument doc)
        {
            // Implement code to extract product name from the HTML document using HtmlAgilityPack
            HtmlNode productNameNode = doc.DocumentNode.SelectSingleNode("//h1[@itemprop='name']");
            return productNameNode == null ? "" : productNameNode?.InnerText.Trim();
        }

        public override double ExtractProductPrice(HtmlDocument doc)
        {
            // Implement code to extract product price from the HTML document using HtmlAgilityPack
            HtmlNode priceNode = doc.DocumentNode.SelectSingleNode("//div[@class='prices']");
            double price = 0.0;
            if (priceNode == null)
            {
                return price;
            }
            
            HtmlNode usualPriceNode = priceNode.SelectSingleNode("//dl[@class='nprice']");
            HtmlNode mainPriceNode = priceNode.SelectSingleNode("//div[@class='main-price']");
            string textPrice = Helpers.GeneralHelper.ExtractIntegerString(mainPriceNode.InnerText.Trim());
            if (usualPriceNode != null)
            {
                textPrice = Helpers.GeneralHelper.ExtractIntegerString(usualPriceNode.InnerText.Trim());
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
            HtmlNode variantNode = doc.DocumentNode.SelectSingleNode("//table[@id='variants-table']");

            if (variantNode == null)
            {
                return variants;
            }
            HtmlNodeCollection headRow = variantNode.SelectNodes("//thead//tr//th");
            HtmlNodeCollection variantRows = variantNode.SelectNodes("//tbody//tr");



            for (int j = 0; j < variantRows.Count; j++)
            {
                HtmlNodeCollection variantCells = variantRows[j].SelectNodes("//td");
                for (int i = 0; i < headRow.Count; i++)
                {

                    string variantValue = variantCells[i].InnerText.Trim();
                    string variantName = headRow[i].InnerText.Trim();
                    if (IsVariant(variantName))
                    {
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
        private bool IsVariant(string text)
        {
            if (text.Length > 0 && !UNWANTED.Contains(text))
            {
                return true;
            }
            return false;
        }

    }
}
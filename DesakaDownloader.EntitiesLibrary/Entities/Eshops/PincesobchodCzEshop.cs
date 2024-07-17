using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace DesakaDownloader.EntitiesLibrary.Entities.Eshops
{
    public class PincesobchodCzEshop : Eshop
    {
        public PincesobchodCzEshop()
        {
            BaseUrl = "https://www.pincesobchod.cz";
        }

        public override async Task LoadCategoryPagesAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                foreach (string category in Categories)
                {
                    try
                    {
                        string response = await client.GetStringAsync($"{BaseUrl}/{category}");
                        HtmlDocument document = new HtmlDocument();
                        document.LoadHtml(response);
                        CategoryPages.Add(document);
                        Console.WriteLine($"Successfully loaded category page: {category}");
                    }
                    catch (HttpRequestException e)
                    {
                        Console.WriteLine($"Request error while loading category page: {category}");
                        Console.WriteLine(e.Message);
                    }
                    catch (System.Exception e)
                    {
                        Console.WriteLine($"Unexpected error while loading category page: {category}");
                        Console.WriteLine(e.ToString());
                    }
                }
            }
        }

        public override async Task LoadProductPagesAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                foreach (HtmlDocument categoryPage in CategoryPages)
                {
                    try
                    {
                        HtmlNodeCollection productLinks = categoryPage.DocumentNode.SelectNodes("//a[@class='product-link']");
                        if (productLinks == null)
                        {
                            Console.WriteLine("No product links found on the category page.");
                            continue;
                        }

                        foreach (HtmlNode link in productLinks)
                        {
                            try
                            {
                                string productUrl = link.GetAttributeValue("href", string.Empty);
                                string response = await client.GetStringAsync($"{BaseUrl}/{productUrl}");
                                HtmlDocument document = new HtmlDocument();
                                document.LoadHtml(response);
                                ProductPages.Add(document);
                                Console.WriteLine($"Successfully loaded product page: {productUrl}");
                            }
                            catch (HttpRequestException e)
                            {
                                Console.WriteLine($"Request error while loading product page: {link.GetAttributeValue("href", string.Empty)}");
                                Console.WriteLine(e.Message);
                            }
                            catch (System.Exception e)
                            {
                                Console.WriteLine($"Unexpected error while loading product page: {link.GetAttributeValue("href", string.Empty)}");
                                Console.WriteLine(e.ToString());
                            }
                        }
                    }
                    catch (System.Exception e)
                    {
                        Console.WriteLine("Unexpected error while processing category page.");
                        Console.WriteLine(e.ToString());
                    }
                }
            }
        }
    }
}
using DesakaDownloader.EntitiesLibrary.Entities.Products;
using System;

namespace DesakaDownloader.ConvertersLibrary.Converters
{
    public abstract class ProductConverter
    {
        public  StandardizedInputProduct Convert(Product product)
        {
            try
            {
                StandardizedInputProduct standardizedProduct = new StandardizedInputProduct
                {
                    Name = product.Name,
                    Price = product.Price,
                    Discount = product.Discount ?? 0,
                    Description = product.Description,
                    BriefDescription = product.BriefDescription,
                    Archive = 0, // Default value, adjust as needed
                    RegularPrice = product.Price, // Assuming Price is the regular price
                    SupplierPrice = 0, // Default value, adjust as needed
                    PurchasePrice = 0, // Default value, adjust as needed
                    OrderGift = 0, // Default value, adjust as needed
                    Length = 0, // Default value, adjust as needed
                    DeliveryTimeAuto = string.Empty, // Default value, adjust as needed
                    DeliveryTime = string.Empty, // Default value, adjust as needed
                    SupplierId = 0, // Default value, adjust as needed
                    SupplierCode = string.Empty, // Default value, adjust as needed
                    FreeShipping = 0, // Default value, adjust as needed
                    Availability = string.Empty, // Default value, adjust as needed
                    VAT = 0, // Default value, adjust as needed
                    EAN = string.Empty, // Default value, adjust as needed
                    AdultContent = 0, // Default value, adjust as needed
                    GlamiCPC = 0, // Default value, adjust as needed
                    GlamiCategory = string.Empty, // Default value, adjust as needed
                    GlamiMaterial = string.Empty, // Default value, adjust as needed
                    GlamiHide = 0, // Default value, adjust as needed
                    GlamiVoucher = 0, // Default value, adjust as needed
                    GoogleCategory = string.Empty, // Default value, adjust as needed
                    HideOnGoogle = 0, // Default value, adjust as needed
                    GoogleLabel0 = string.Empty, // Default value, adjust as needed
                    GoogleLabel1 = string.Empty, // Default value, adjust as needed
                    GoogleLabel2 = string.Empty, // Default value, adjust as needed
                    GoogleLabel3 = string.Empty, // Default value, adjust as needed
                    GoogleLabel4 = string.Empty, // Default value, adjust as needed
                    HeurekaCPC = 0, // Default value, adjust as needed
                    HeurekaCategory = string.Empty, // Default value, adjust as needed
                    HeurekaProduct = string.Empty, // Default value, adjust as needed
                    HeurekaProductName = string.Empty, // Default value, adjust as needed
                    HeurekaHide = 0, // Default value, adjust as needed
                    Weight = 0, // Default value, adjust as needed
                    HomePage = 0, // Default value, adjust as needed
                    Id = 0, // Default value, adjust as needed
                    ISBN = string.Empty, // Default value, adjust as needed
                    Unit = string.Empty, // Default value, adjust as needed
                    CategoryIds = new List<int>(), // Default value, adjust as needed
                    ProductCode = string.Empty, // Default value, adjust as needed
                    Code = string.Empty, // Default value, adjust as needed
                    Basket = 0, // Default value, adjust as needed
                    SupplierMargin = 0, // Default value, adjust as needed
                    InStock = 0, // Default value, adjust as needed
                    PiecesMax = 0, // Default value, adjust as needed
                    PiecesMin = 0, // Default value, adjust as needed
                    PiecesBy = 0, // Default value, adjust as needed
                    QuantityPerPackage = 0, // Default value, adjust as needed
                    SimilarProducts = new List<int>(), // Default value, adjust as needed
                    Note = string.Empty, // Default value, adjust as needed
                    Priority = 0, // Default value, adjust as needed
                    Accessories = new List<int>(), // Default value, adjust as needed
                    Attribute = string.Empty, // Default value, adjust as needed
                    ForAdults = 0, // Default value, adjust as needed
                    RecyclingFee = 0, // Default value, adjust as needed
                    ExpandingContent = new List<int>(), // Default value, adjust as needed
                    SeoDescription = string.Empty, // Default value, adjust as needed
                    SeoTitle = string.Empty, // Default value, adjust as needed
                    StockMaximum = 0, // Default value, adjust as needed
                    StockMinimum = 0, // Default value, adjust as needed
                    StockOptimal = 0, // Default value, adjust as needed
                    StockLocation = string.Empty, // Default value, adjust as needed
                    Stock = 0, // Default value, adjust as needed
                    DiscountTo = DateTime.Now, // Default value, adjust as needed
                    DiscountFrom = DateTime.Now, // Default value, adjust as needed
                    DiscountCoupon = 0, // Default value, adjust as needed
                    Services = new List<int>(), // Default value, adjust as needed
                    Labels = new List<string>(), // Default value, adjust as needed
                    VariantID = 0, // Default value, adjust as needed
                    VariantProduct = string.Empty, // Default value, adjust as needed
                    VariantSame = 0, // Default value, adjust as needed
                    Variant1Value = string.Empty, // Default value, adjust as needed
                    Variant1Name = string.Empty, // Default value, adjust as needed
                    Variant2Value = string.Empty, // Default value, adjust as needed
                    Variant2Name = string.Empty, // Default value, adjust as needed
                    Variant3Value = string.Empty, // Default value, adjust as needed
                    Variant3Name = string.Empty, // Default value, adjust as needed
                    Variants = new List<int>(), // Default value, adjust as needed
                    Manufacturer = string.Empty, // Default value, adjust as needed
                    Warranty = "neuvedena", // Default value, adjust as needed
                    ZboziCzCPCSearch = 0, // Default value, adjust as needed
                    ZboziCzCPC = 0, // Default value, adjust as needed
                    ZboziCzExtra = string.Empty, // Default value, adjust as needed
                    ZboziCzCategory = string.Empty, // Default value, adjust as needed
                    ZboziCzProduct = string.Empty, // Default value, adjust as needed
                    ZboziCzProductName = string.Empty, // Default value, adjust as needed
                    ZboziCzHideProduct = 0, // Default value, adjust as needed
                    ZboziCzLabel0 = string.Empty, // Default value, adjust as needed
                    ZboziCzLabel1 = string.Empty, // Default value, adjust as needed
                    Free = new List<int>(), // Default value, adjust as needed
                    Display = 1 // Default value, adjust as needed
                };

                // Additional mapping logic if needed

                return standardizedProduct;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error converting product: {ex.Message}");
                Console.WriteLine(ex.ToString());
                throw;
            }

        }


    }
}
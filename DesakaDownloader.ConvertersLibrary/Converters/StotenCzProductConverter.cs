using DesakaDownloader.EntitiesLibrary.Entities.Products;
using System;

namespace DesakaDownloader.ConvertersLibrary.Converters
{
    public class StotenCzProductConverter : ProductConverter
    {
        public override StandardizedProduct Convert(Product product)
        {
            try
            {
                StandardizedProduct standardizedProduct = new StandardizedProduct
                {
                    Name = product.Name,
                    Price = product.Price,
                    Discount = product.Discount ?? 0,
                    Description = product.Description,
                    BriefDescription = product.BriefDescription,
                    Archive = false, // Default value, adjust as needed
                    RegularPrice = product.Price, // Assuming Price is the regular price
                    SupplierPrice = 0, // Default value, adjust as needed
                    PurchasePrice = 0, // Default value, adjust as needed
                    OrderGift = string.Empty, // Default value, adjust as needed
                    Length = 0, // Default value, adjust as needed
                    AutoDeliveryTime = string.Empty, // Default value, adjust as needed
                    DeliveryTime = string.Empty, // Default value, adjust as needed
                    SupplierId = 0, // Default value, adjust as needed
                    SupplierCode = string.Empty, // Default value, adjust as needed
                    FreeShipping = false, // Default value, adjust as needed
                    Availability = string.Empty, // Default value, adjust as needed
                    VAT = 0, // Default value, adjust as needed
                    EAN = string.Empty, // Default value, adjust as needed
                    Erotic = false, // Default value, adjust as needed
                    GlamiCPC = 0, // Default value, adjust as needed
                    GlamiCategory = string.Empty, // Default value, adjust as needed
                    GlamiMaterial = string.Empty, // Default value, adjust as needed
                    GlamiHide = false, // Default value, adjust as needed
                    GlamiVoucher = string.Empty, // Default value, adjust as needed
                    GoogleCategory = string.Empty, // Default value, adjust as needed
                    GoogleHide = false, // Default value, adjust as needed
                    GoogleTag0 = string.Empty, // Default value, adjust as needed
                    GoogleTag1 = string.Empty, // Default value, adjust as needed
                    GoogleTag2 = string.Empty, // Default value, adjust as needed
                    GoogleTag3 = string.Empty, // Default value, adjust as needed
                    GoogleTag4 = string.Empty, // Default value, adjust as needed
                    HeurekaCzCPC = 0, // Default value, adjust as needed
                    HeurekaCzCategory = string.Empty, // Default value, adjust as needed
                    HeurekaCzProduct = string.Empty, // Default value, adjust as needed
                    HeurekaCzProductName = string.Empty, // Default value, adjust as needed
                    HeurekaCzHide = false, // Default value, adjust as needed
                    Weight = 0, // Default value, adjust as needed
                    Home = string.Empty, // Default value, adjust as needed
                    Id = 0, // Default value, adjust as needed
                    ISBN = string.Empty, // Default value, adjust as needed
                    Unit = string.Empty, // Default value, adjust as needed
                    CategoryId = 0, // Default value, adjust as needed
                    ProductCode = string.Empty, // Default value, adjust as needed
                    Code = string.Empty, // Default value, adjust as needed
                    Basket = string.Empty, // Default value, adjust as needed
                    SupplierMargin = 0, // Default value, adjust as needed
                    InStock = 0, // Default value, adjust as needed
                    MaxOrder = 0, // Default value, adjust as needed
                    MinOrder = 0, // Default value, adjust as needed
                    OrderAfter = 0, // Default value, adjust as needed
                    Count = 0, // Default value, adjust as needed
                    Similar = string.Empty, // Default value, adjust as needed
                    Note = string.Empty, // Default value, adjust as needed
                    Priority = 0, // Default value, adjust as needed
                    Accessories = string.Empty, // Default value, adjust as needed
                    Attribute = string.Empty, // Default value, adjust as needed
                    ForAdults = false, // Default value, adjust as needed
                    RecyclingFee = 0, // Default value, adjust as needed
                    ExtendedContent = string.Empty, // Default value, adjust as needed
                    SeoDescription = string.Empty, // Default value, adjust as needed
                    SeoTitle = string.Empty, // Default value, adjust as needed
                    MaxStock = 0, // Default value, adjust as needed
                    MinStock = 0, // Default value, adjust as needed
                    OptimalStock = 0, // Default value, adjust as needed
                    StockLocation = string.Empty, // Default value, adjust as needed
                    Stock = 0, // Default value, adjust as needed
                    DiscountUntil = string.Empty, // Default value, adjust as needed
                    DiscountFrom = string.Empty, // Default value, adjust as needed
                    DiscountCoupon = string.Empty, // Default value, adjust as needed
                    Services = string.Empty, // Default value, adjust as needed
                    Tags = string.Empty, // Default value, adjust as needed
                    VariantId = 0, // Default value, adjust as needed
                    VariantProduct = string.Empty, // Default value, adjust as needed
                    SameVariant = string.Empty, // Default value, adjust as needed
                    Variant1Value = string.Empty, // Default value, adjust as needed
                    Variant1Name = string.Empty, // Default value, adjust as needed
                    Variant2Value = string.Empty, // Default value, adjust as needed
                    Variant2Name = string.Empty, // Default value, adjust as needed
                    Variant3Value = string.Empty, // Default value, adjust as needed
                    Variant3Name = string.Empty, // Default value, adjust as needed
                    Variant = false, // Default value, adjust as needed
                    Manufacturer = string.Empty, // Default value, adjust as needed
                    Warranty = 0, // Default value, adjust as needed
                    ZboziCzCPCSearch = 0, // Default value, adjust as needed
                    ZboziCzCPC = 0, // Default value, adjust as needed
                    ZboziCzExtra = string.Empty, // Default value, adjust as needed
                    ZboziCzCategory = string.Empty, // Default value, adjust as needed
                    ZboziCzProduct = string.Empty, // Default value, adjust as needed
                    ZboziCzProductName = string.Empty, // Default value, adjust as needed
                    ZboziCzHide = false, // Default value, adjust as needed
                    ZboziCzTag0 = string.Empty, // Default value, adjust as needed
                    ZboziCzTag1 = string.Empty, // Default value, adjust as needed
                    Free = false, // Default value, adjust as needed
                    Display = false // Default value, adjust as needed
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
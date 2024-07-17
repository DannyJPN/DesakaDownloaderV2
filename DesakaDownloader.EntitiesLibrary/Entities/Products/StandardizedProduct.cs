namespace DesakaDownloader.EntitiesLibrary.Entities.Products
{
    public class StandardizedProduct
    {
        public bool Archive { get; set; }
        public double RegularPrice { get; set; }
        public double SupplierPrice { get; set; }
        public double PurchasePrice { get; set; }
        public double Price { get; set; }
        public string OrderGift { get; set; } = string.Empty;
        public double Length { get; set; }
        public string AutoDeliveryTime { get; set; } = string.Empty;
        public string DeliveryTime { get; set; } = string.Empty;
        public int SupplierId { get; set; }
        public string SupplierCode { get; set; } = string.Empty;
        public bool FreeShipping { get; set; }
        public string Availability { get; set; } = string.Empty;
        public double VAT { get; set; }
        public string EAN { get; set; } = string.Empty;
        public bool Erotic { get; set; }
        public double GlamiCPC { get; set; }
        public string GlamiCategory { get; set; } = string.Empty;
        public string GlamiMaterial { get; set; } = string.Empty;
        public bool GlamiHide { get; set; }
        public string GlamiVoucher { get; set; } = string.Empty;
        public string GoogleCategory { get; set; } = string.Empty;
        public bool GoogleHide { get; set; }
        public string GoogleTag0 { get; set; } = string.Empty;
        public string GoogleTag1 { get; set; } = string.Empty;
        public string GoogleTag2 { get; set; } = string.Empty;
        public string GoogleTag3 { get; set; } = string.Empty;
        public string GoogleTag4 { get; set; } = string.Empty;
        public double HeurekaCzCPC { get; set; }
        public string HeurekaCzCategory { get; set; } = string.Empty;
        public string HeurekaCzProduct { get; set; } = string.Empty;
        public string HeurekaCzProductName { get; set; } = string.Empty;
        public bool HeurekaCzHide { get; set; }
        public double Weight { get; set; }
        public string Home { get; set; } = string.Empty;
        public int Id { get; set; }
        public string ISBN { get; set; } = string.Empty;
        public string Unit { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public string ProductCode { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string Basket { get; set; } = string.Empty;
        public double SupplierMargin { get; set; }
        public int InStock { get; set; }
        public string Name { get; set; } = string.Empty;
        public int MaxOrder { get; set; }
        public int MinOrder { get; set; }
        public int OrderAfter { get; set; }
        public int Count { get; set; }
        public string Similar { get; set; } = string.Empty;
        public string BriefDescription { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Note { get; set; } = string.Empty;
        public int Priority { get; set; }
        public string Accessories { get; set; } = string.Empty;
        public string Attribute { get; set; } = string.Empty;
        public bool ForAdults { get; set; }
        public double RecyclingFee { get; set; }
        public string ExtendedContent { get; set; } = string.Empty;
        public string SeoDescription { get; set; } = string.Empty;
        public string SeoTitle { get; set; } = string.Empty;
        public int MaxStock { get; set; }
        public int MinStock { get; set; }
        public int OptimalStock { get; set; }
        public string StockLocation { get; set; } = string.Empty;
        public int Stock { get; set; }
        public string DiscountUntil { get; set; } = string.Empty;
        public string DiscountFrom { get; set; } = string.Empty;
        public double Discount { get; set; }
        public string DiscountCoupon { get; set; } = string.Empty;
        public string Services { get; set; } = string.Empty;
        public string Tags { get; set; } = string.Empty;
        public int VariantId { get; set; }
        public string VariantProduct { get; set; } = string.Empty;
        public string SameVariant { get; set; } = string.Empty;
        public string Variant1Value { get; set; } = string.Empty;
        public string Variant1Name { get; set; } = string.Empty;
        public string Variant2Value { get; set; } = string.Empty;
        public string Variant2Name { get; set; } = string.Empty;
        public string Variant3Value { get; set; } = string.Empty;
        public string Variant3Name { get; set; } = string.Empty;
        public bool Variant { get; set; }
        public string Manufacturer { get; set; } = string.Empty;
        public int Warranty { get; set; }
        public double ZboziCzCPCSearch { get; set; }
        public double ZboziCzCPC { get; set; }
        public string ZboziCzExtra { get; set; } = string.Empty;
        public string ZboziCzCategory { get; set; } = string.Empty;
        public string ZboziCzProduct { get; set; } = string.Empty;
        public string ZboziCzProductName { get; set; } = string.Empty;
        public bool ZboziCzHide { get; set; }
        public string ZboziCzTag0 { get; set; } = string.Empty;
        public string ZboziCzTag1 { get; set; } = string.Empty;
        public bool Free { get; set; }
        public bool Display { get; set; }
    }
}
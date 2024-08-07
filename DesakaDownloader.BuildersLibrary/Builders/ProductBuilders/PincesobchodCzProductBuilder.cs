using DesakaDownloader.EntitiesLibrary.Entities.Products;
using DesakaDownloader.ParsersLibrary.Parsers;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;


namespace DesakaDownloader.BuildersLibrary.Builders.ProductBuilders
{
    public class PincesobchodCzProductBuilder
    {

       private    PincesobchodCzParser parser;
           public PincesobchodCzProductBuilder()
{ parser = new PincesobchodCzParser();
}  


      public  PincesobchodCzProduct BuildProduct(HtmlDocument productPage)
        {
                          PincesobchodCzProduct product = new PincesobchodCzProduct     
       { 
               Name = parser.ExtractProductName(productPage),    
            Price = parser.ExtractProductPrice(productPage), 
               Discount = parser.ExtractProductDiscount(productPage),  
              ImageLinks = parser.ExtractProductImageLinks(productPage),    
            MainImageLink = parser.ExtractProductMainImageLink(productPage),  
              VariantCombinations = parser.ExtractProductVariantCombinations(productPage),     
           Description = parser.ExtractProductDescription(productPage),   
             BriefDescription = parser.ExtractProductBriefDescription(productPage)   
         };   
                                 return product;
        }

    }
}

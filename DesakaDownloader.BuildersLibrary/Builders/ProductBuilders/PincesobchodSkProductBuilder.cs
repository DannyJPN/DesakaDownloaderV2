using DesakaDownloader.EntitiesLibrary.Entities.Products;
using DesakaDownloader.ParsersLibrary.Parsers;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;


namespace DesakaDownloader.BuildersLibrary.Builders.ProductBuilders
{
    public class PincesobchodSkProductBuilder
    {

       private    PincesobchodSkParser parser;
           public PincesobchodSkProductBuilder()
{ parser = new PincesobchodSkParser();
}  


      public  PincesobchodSkProduct BuildProduct(HtmlDocument productPage)
        {
                          PincesobchodSkProduct product = new PincesobchodSkProduct     
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

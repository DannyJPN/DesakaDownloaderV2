using DesakaDownloader.EntitiesLibrary.Entities.Products;
using DesakaDownloader.ParsersLibrary.Parsers;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;


namespace DesakaDownloader.BuildersLibrary.Builders.ProductBuilders
{
    public class ContraDeProductBuilder
    {

       private    ContraDeParser parser;
           public ContraDeProductBuilder()
{ parser = new ContraDeParser();
}  


      public  ContraDeProduct BuildProduct(HtmlDocument productPage)
        {
                          ContraDeProduct product = new ContraDeProduct     
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

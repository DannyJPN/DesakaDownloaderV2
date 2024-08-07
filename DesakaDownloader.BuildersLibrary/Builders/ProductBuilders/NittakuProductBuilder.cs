using DesakaDownloader.EntitiesLibrary.Entities.Products;
using DesakaDownloader.ParsersLibrary.Parsers;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;


namespace DesakaDownloader.BuildersLibrary.Builders.ProductBuilders
{
    public class NittakuProductBuilder
    {

       private    NittakuParser parser;
           public NittakuProductBuilder()
{ parser = new NittakuParser();
}  


      public  NittakuProduct BuildProduct(HtmlDocument productPage)
        {
                          NittakuProduct product = new NittakuProduct     
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

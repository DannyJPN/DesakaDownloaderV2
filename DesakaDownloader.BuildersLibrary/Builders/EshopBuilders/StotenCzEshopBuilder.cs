using DesakaDownloader.EntitiesLibrary.Entities.Eshops;
using DesakaDownloader.ParsersLibrary.Parsers;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;


namespace DesakaDownloader.BuildersLibrary.Builders.EshopBuilders
{
    public class StotenCzEshopBuilder
    {

       private    StotenCzParser parser;
           public StotenCzEshopBuilder()
{ parser = new StotenCzParser();
}  


      public  StotenCzEshop Build()
        {
          throw new NotImplementedException();
        }

    }
}

using System.Collections.Generic;
using System.Drawing;

namespace DesakaDownloader.EntitiesLibrary.Entities.Products
{
    public class ContraDeProduct : Product
    {
        public Image DefaultImage { get; set; }
        public List<Image> AdditionalImages { get; set; }

        public ContraDeProduct()
        {
            DefaultImage = null;
            AdditionalImages = new List<Image>();
        }
    }
}
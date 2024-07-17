using System.Collections.Generic;
using System.Drawing;

namespace DesakaDownloader.EntitiesLibrary.Entities.Products
{
    public class SportspinCzProduct : Product
    {
        public Image DefaultImage { get; set; }
        public List<Image> AdditionalImages { get; set; }

        public SportspinCzProduct()
        {
            DefaultImage = null;
            AdditionalImages = new List<Image>();
        }
    }
}
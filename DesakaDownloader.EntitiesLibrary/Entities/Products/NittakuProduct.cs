using System.Collections.Generic;
using System.Drawing;

namespace DesakaDownloader.EntitiesLibrary.Entities.Products
{
    public class NittakuProduct : Product
    {
        public Image DefaultImage { get; set; }
        public List<Image> AdditionalImages { get; set; }

        public NittakuProduct()
        {
            DefaultImage = null;
            AdditionalImages = new List<Image>();
        }
    }
}
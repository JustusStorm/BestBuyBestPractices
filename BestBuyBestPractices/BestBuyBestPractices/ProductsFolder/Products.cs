using System;
using System.Collections.Generic;
using System.Text;
using Org.BouncyCastle.Bcpg.OpenPgp;

namespace BestBuyBestPractices.ProductsFolder
{
    class Products
    {

        // Properties
        public int ProductID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int CategoryID { get; set; }
        public int OnSale { get; set; }
        public int StockLevel { get; set; }


        // Constructors
        public Products()
        {
            OnSale = 0;
            StockLevel = 0;
        }

    }
}

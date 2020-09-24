using System;
using System.Collections.Generic;
using System.Text;

namespace BestBuyBestPractices.ProductsFolder
{
    interface IProductRepository
    {


        // Methods
        public IEnumerable<Products> RetrieveAllProducts(); // stubbed out method
        public void ListAllProducts(); // stubbed out method
        public void CreateProduct(string name, double price, int cateogryID); // stubbed out method
        

    }
}

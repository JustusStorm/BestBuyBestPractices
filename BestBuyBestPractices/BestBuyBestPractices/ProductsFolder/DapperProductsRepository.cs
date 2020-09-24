using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Dapper;

namespace BestBuyBestPractices.ProductsFolder
{
    class DapperProductsRepository : IProductRepository
    {

        // Properties
        private readonly IDbConnection _connection;



        // Constructors
        public DapperProductsRepository(IDbConnection connection)
        {
            _connection = connection;
        }
        


        // Methods
        public IEnumerable<Products> RetrieveAllProducts()
        {
            return _connection.Query<Products>("SELECT * FROM Products;");
        }

        public void ListAllProducts()
        {
            Console.WriteLine();
            Console.WriteLine("List of Departments:");
            // reads departments and return a list of the departments
            var departmentList = this.RetrieveAllProducts();

            // create foreach loop to enumerate over the list and write all department names to the console
            foreach (var dept in departmentList)
            {
                Console.WriteLine(dept.Name);
            }
        }


        /// <summary>
        /// Requires a product name, price and category ID
        /// </summary>
        /// <param name="name"></param>
        /// <param name="price"></param>
        /// <param name="cateogryID"></param>
        public void CreateProduct(string name, double price, int cateogryID)
        {
            _connection.Execute(
                "INSERT INTO PRODUCTS (Name, Price, CategoryID) VALUES (@prodName, @prodPrice, @prodCatID)",
                new { prodName = name, prodPrice = price, prodCatID = cateogryID});
        }

        ///// <summary>
        ///// 
        ///// </summary>
        //public void UpdateProduct(string column)
        //{
        //    _connection.Execute(
        //        "UPDATE products SET @categoryColumn  ",
        //        new { categoryColumn = column});
        //}



    }
}

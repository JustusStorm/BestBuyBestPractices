using System;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.IO;
using BestBuyBestPractices.DepartmentFolder;
using BestBuyBestPractices.ProductsFolder;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;


namespace BestBuyBestPractices
{
    class Program
    {
        static void Main(string[] args)
        { 

            var config = new ConfigurationBuilder()
                // sets this projects directory to the bas directory
                .SetBasePath(Directory.GetCurrentDirectory())
                // adds .json as a reference to this projects path
                .AddJsonFile("appsettings.json")
                // builds configuration with the file above
                .Build();

            // sets connection string to "Default connection" that we stated in the .json file
            string connString = config.GetConnectionString("DefaultConnection");
            // places the Sql connection that is using the "Default Connection" key value pair from .json file
            // into a IDbConnection object
            IDbConnection conn = new MySqlConnection(connString);

            // Use the IDbConnection object in this constructor to set the connection to _connection in DapperDeparmentRepository
            // as well as create an instance of this class to call the methods for querying
            var deptRepo = new DapperDepartmentRepository(conn);
            var prodRepo = new DapperProductsRepository(conn);







            Console.WriteLine("What kind of data would you like to access?");
            Console.WriteLine(
                "(D)epartments\n" +
                "(P)roducts\n");
            Console.Write("> ");

            var userInput = Console.ReadLine().ToLower().Trim();

            
            if (userInput.StartsWith('d'))
            {
                Console.WriteLine("\nDo you want to add a department? yes/no");
                 Console.Write("> ");
                var addDepartmentInput = Console.ReadLine().ToLower().Trim();
                
                if (addDepartmentInput.StartsWith('y'))
                {
                    // Takes input from the user for new department name
                    Console.WriteLine("\nEnter a new department name to add to the database..\n");
                    var userInputNewDepartment = Console.ReadLine();
                    deptRepo.InsertDepartment(userInputNewDepartment);

                    Console.WriteLine("List of Departments:");
                    var departmentList = deptRepo.GetDepartments();
                    // create foreach loop to enumerate over the list and write all department names to the console
                    foreach (var dept in departmentList)
                    {
                        Console.WriteLine(dept.Name);
                    }
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("List of Departments:");
                    // reads departments and return a list of the departments
                    var departmentList = deptRepo.GetDepartments();

                    // create foreach loop to enumerate over the list and write all department names to the console
                    foreach (var dept in departmentList)
                    {
                        Console.WriteLine(dept.Name);
                    }
                }
            }
            else if (userInput.StartsWith('p'))
            {
                Console.WriteLine("Do you want to add a product? yes/no");
                Console.Write("> ");
                var addProductInput = Console.ReadLine().ToLower().Trim();
                
                if (addProductInput.StartsWith('y'))
                {
                    var newProduct = new Products();
                    Console.Write("\nProduct Name: ");
                    newProduct.Name = Console.ReadLine();
                    
                    Console.Write("\nProduct Price: ");
                    newProduct. Price = double.Parse(Console.ReadLine());
                    
                    Console.Write("\nProduct Category ID: ");
                    newProduct.CategoryID = int.Parse(Console.ReadLine());
                    
                    prodRepo.CreateProduct(newProduct.Name, newProduct.Price, newProduct.CategoryID);
                    prodRepo.ListAllProducts();
                }
                else 
                {
                    prodRepo.ListAllProducts();
                }




            }
            else
            {
                Console.WriteLine("Incorrect Input");
            }





            Console.ReadLine();
        }
    }
}

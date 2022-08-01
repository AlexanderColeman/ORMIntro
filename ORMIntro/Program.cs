using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using ORMIntro;
using System.Data;

var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
string connString = config.GetConnectionString("DefaultConnection");
IDbConnection conn = new MySqlConnection(connString);


//Departments
var repo = new DepartmentRepository(conn);

//repo.InsertDepartment("My new Department");

var departments = repo.GetAllDepartments();

foreach (var department in departments)
{
    Console.WriteLine(department.DepartmentID);
    Console.WriteLine(department.Name +"\n\n");  
}

// Products 
var productRepo = new ProductRepository(conn);

var products = productRepo.GetAllProducts();

productRepo.UpdateProduct(4, "Changed Product", 100                                                                                                                                                );

foreach (var product in products)
{
    Console.WriteLine($"Product Id:{ product.ProductID}");
    Console.WriteLine($"product name:{product.Name}");
    Console.WriteLine($"product Price:{product.Price}");
    Console.WriteLine($"product CategoryID: {product.CategoryID}\n\n");
}

// productRepo.CreateProduct("laptop", 999, 8);


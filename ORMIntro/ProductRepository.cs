using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORMIntro
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDbConnection _connection;

        public ProductRepository(IDbConnection connection)
        {
            _connection = connection;
        }
        public void CreateProduct(string name, double price, int categoryID)
        {
            _connection.Execute("INSERT INTO Products (Name, Price, CategoryID) VALUES (@Name, @Price, @CategoryID);",
                new { Name = name, Price = price, CategoryID = categoryID });
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _connection.Query<Product>("SELECT * FROM Products;");
        }

        public void UpdateProduct(int productId, string name, double price)
        {
            _connection.Execute("UPDATE Products SET Name = @Name, Price = @Price WHERE ProductID= @ProductID;",
                new { Name = name, Price = price, ProductID = productId });
        }
    }
}

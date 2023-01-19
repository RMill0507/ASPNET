using Dapper;
using System.Collections.Generic;
using System.Data;
using Testing.Models;

namespace Testing
{
    public class ProductRepository : IProductRepository// this is our class that is conforming to IPRODUCTREPOSITORY
        //we are implementing the methods and giving them functionality
    {
        private readonly IDbConnection _conn;//allowing us to connect MYSQL. 

       
       public ProductRepository(IDbConnection conn)//this is our constructor that takes input for our IDB Connector
        {
            _conn = conn;
        }
 
        public IEnumerable<Product> GetAllProducts()
        {
            return _conn.Query<Product>("SELECT * FROM PRODUCTS;"); //This is our SQLcode for our method that connects to MYSQL
            //.Query is using dapper to connect to our Product model/class. Also is returing as a collection of products
            //returning a table from all the products and storing it
        }
            public Product GetProduct(int id)//getting a single product from MYSQL based on the product id
            {
                return _conn.QuerySingle<Product>("SELECT * FROM PRODUCTS WHERE PRODUCTID = @id;", new { id = id });
            //querysingle is returning one model item
            }
        public void UpdateProduct(Product product)
        {
            _conn.Execute("UPDATE products SET Name = @name, Price = @price WHERE ProductID = @id",
             new { name = product.Name, price = product.Price, id = product.ProductID });
        }
        public void InsertProduct(Product productToInsert)
        {
            _conn.Execute("INSERT INTO products (NAME, PRICE, CATEGORYID) VALUES (@name, @price, @categoryID);",
                new { name = productToInsert.Name, price = productToInsert.Price, categoryID = productToInsert.CategoryID });
        }
        public IEnumerable<Category> GetCategories()
        {
            return _conn.Query<Category>("SELECT * FROM categories;");
        }
        public Product AssignCategory()
        {
            var categoryList = GetCategories();
            var product = new Product();
            product.Categories = categoryList;
            return product;
        }
        public void DeleteProduct(Product product)
        {
            _conn.Execute("DELETE FROM REVIEWS WHERE ProductID = @id;", new { id = product.ProductID });
            _conn.Execute("DELETE FROM Sales WHERE ProductID = @id;", new { id = product.ProductID });
            _conn.Execute("DELETE FROM Products WHERE ProductID = @id;", new { id = product.ProductID });
        }

    }
}

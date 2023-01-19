using System.Collections.Generic;
using System.ComponentModel;

namespace Testing.Models
{
    public class Product//This is where we are storing the DATA from our DATEBASE
    {
        public Product()//Each object will be apart of type Product
        {

        }
        public int ProductID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int CategoryID { get; set; }
        public int OnSale { get; set; } 
        public int StockLevel { get; set; }
        public IEnumerable<Category> Categories { get; set; }


    }
}

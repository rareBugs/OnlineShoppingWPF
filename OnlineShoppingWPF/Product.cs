using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace OnlineShoppingWPF
{
    public class Product
    {
       /* Product product = new Product("Alpha Industries", 101, 4500, 350, "Jacket");
        Product product2 = new Product("Dickies", 101, 4500, 350, "Sweater");
        Product product3 = new Product("Disel", 101, 4500, 350, "Pants");*/

        public Product(string productName, int productId, int productPrice, int productQuantity, string productCategory)
        {
            Name = productName;
            Id = productId;
            Price = productPrice;
            Quantity = productQuantity;
            Category = productCategory;
        }
        
        public string Name {  get; set; }
        public int Id { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public string Category { get; set; }
    }
}

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

        public override string ToString()
        {
            return $"{Name}- Quantity: {Quantity}";
        }
    }

}

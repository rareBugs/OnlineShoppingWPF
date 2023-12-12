using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingWPF
{
    class Order
    {
        private static int orderCounter = 0001;

        public Order()
        {
            OrderNumber = GenerateOrderNumber();
            Products = new List<Product>();
        }

        public int OrderNumber { get; private set; }
        public List<Product> Products { get; private set; }

        private int GenerateOrderNumber()
        {
            orderCounter++;
            SaveOrderCounter();
            return orderCounter;
        }

        private void SaveOrderCounter()
        {
            File.WriteAllText("orderCounter.txt", orderCounter.ToString());
        }

        private static int LoadOrderCounter()
        {
            if (File.Exists("orderCounter.txt"))
            {
                string counterString = File.ReadAllText("orderCounter.txt");
                if (int.TryParse(counterString, out int loadedCounter))
                {
                    return loadedCounter;
                }
            }
            // Default value if loading fails
            return 1;
        }
        public static void InitializeOrderCounter()
        {
            orderCounter = LoadOrderCounter();
        }

        public void AddProduct(Product product)
        {
            Products.Add(product);
        }
        public void DisplayOrderDetails()
        {
            Console.WriteLine("Order Number: " + OrderNumber);
            Console.WriteLine("Products in the order:");

            foreach (var product in Products)
            {
                Console.WriteLine("- " + product.ProductName + "," + "Quantity: " + product.Quantity + "Price: " + product.Price + "Category: " + product.Category + "ID: " + product.Id);
            }
        }
        public void SaveToCSV(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine("Product Name,Quantity,Price,Category, Id");

                foreach (var product in Products)
                {
                    writer.WriteLine($"{product.ProductName},{product.Quantity},{product.Price},{product.Category},{product.Id}");
                }
            }
        }
    }
}

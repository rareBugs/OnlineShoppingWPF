using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OnlineShoppingWPF
{
    public class Order
    {
        public enum OrderStatus
        {
            Processing,
            Cancelled,
            ReadyToSend,
            Delivering,
            Lost,
            Delivered,
            Returning,
            Returned
        }

        private static int orderCounter = 0001;

        public Order()
        {
            OrderNumber = GenerateOrderNumber();
            Products = new List<Product>();
        }

        public int OrderNumber { get; private set; }
        public List<Product> Products { get; private set; }
        public OrderStatus Status { get; private set; } = OrderStatus.Processing;
        

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
            if (Status == OrderStatus.Processing)
            {
                Products.Add(product);
            }
            else
            {
                MessageBox.Show("Can't add products to order");
            }
        }

        public bool Packaged()
        {
            if (Status == OrderStatus.Processing)
            {
                Status = OrderStatus.ReadyToSend;
                return true;
            }
            else
            {
                return false;
            }
        }
        public void DisplayOrderDetails()
        {
            Console.WriteLine("Order Number: " + OrderNumber);
            Console.WriteLine("Products in the order:");

            foreach (var product in Products)
            {
                Console.WriteLine("- " + product.Name + "," + "Quantity: " + product.Quantity + "Price: " + product.Price + "Category: " + product.Category + "ID: " + product.Id);
            }
        }
        public void SaveToCSV(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine("Product Name,Quantity,Price,Category, Id");

                foreach (var product in Products)
                {
                    writer.WriteLine($"{product.Name},{product.Quantity},{product.Price},{product.Category},{product.Id}");
                }
            }
        }
    }
}

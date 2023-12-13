using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingWPF
{
    public sealed class Store
    {
        public List<Product> products { get; private set; } = new List<Product>();
        public List<Customer> customers { get; private set; } = new List<Customer>();
        public List<Employee> employees { get; private set; } = new List<Employee>();
        public List<Order> orders { get; private set; } = new List<Order>();

        // Singleton setup
        private static readonly Store instance = new Store();

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static Store()
        {
        }

        private Store()
        {
            // Adding some test data
            products.Add(new Product("k", 1, 1, 5, "ktype"));
            products.Add(new Product("l", 2, 1, 15, "ltype"));
            products.Add(new Product("m", 3, 2, 10, "mtype"));
            Order test = new Order();
            test.AddProduct(new Product("k", 1, 0, 1, ""));
            orders.Add(test);
            Order test2 = new Order();
            test2.AddProduct(new Product("m", 3, 0, 1, ""));
            orders.Add(test2);
        }

        public static Store Instance
        {
            get
            {
                return instance;
            }
        }
    }
}

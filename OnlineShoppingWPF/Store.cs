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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingWPF
{
    public class Employee : Person
    {
        public Employee(string name, string password) : base(name, password) { }

        public override string ToString()
        {
            return Name;
        }

        public string GetCSV()
        {
            return $"{Name},{Password}";
        }
    }
}
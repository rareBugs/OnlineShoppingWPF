using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingWPF
{
    public class Person
    {
        public string Name { get; set; }
        public string Password { get; set; }


        public Person(string name, string password)
        {
            Name = name;
            Password = password;
        }
    }
}

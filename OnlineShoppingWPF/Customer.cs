using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingWPF
{
    public class Customer : Person
    {
        public string Address { get; set; }
        public int PostalCode { get; set; }
        public string Email { get; set; }
        public int Money { get; set; }


        public Customer(string name, string password, string email, string address, int postalCode, int money)
            : base(name, password)
        {
            Email = email;
            Address = address;
            PostalCode = postalCode;
            Money = money;
        }


        public override string ToString()
        {
            return Name;
        }


        public string GetCSV()
        {
            return $"{Name},{Password},{Email},{Address},{PostalCode},{Money}";
        }


        public void UpdateDetails(string newName, string newPassword, string newEmail, string newAddress, int newPostalCode, int newMoney)
        {
            Name = newName;
            Password = newPassword;
            Email = newEmail;
            Address = newAddress;
            PostalCode = newPostalCode;
            Money = newMoney;
        }
    }
}
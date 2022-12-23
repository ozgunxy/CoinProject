using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace YazilimTestProje
{
    public class Coin
    {
        public string Name { get; set; }
        public decimal Value { get; set; }
        public string Owner { get; set; }
        public DateTime CreatedOn { get; set; }

        public Coin(string name, decimal value, string owner)
        {
            Name = name;
            Value = value;
            Owner = owner;
            CreatedOn = DateTime.Now;
        }
    }
}

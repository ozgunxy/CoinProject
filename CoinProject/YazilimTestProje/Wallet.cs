using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
namespace YazilimTestProje
{
    public class Wallet
    {
        public string Owner { get; set; }
        public byte[] Address { get; set; }
        public List<Coin> Coins { get; set; }


        public Wallet(User user)
        {
            Owner = user.UserName + user.UserID;
            Coins = new List<Coin>();
            using (SHA256 sha256 = SHA256.Create())
            {
                Address = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(Owner));
            }
        }

        public void AddCoin(Coin coin)
        {
            Coins.Add(coin);
        }
        public void RemoveCoin(Coin coin)
        {
            Coins.Remove(coin);
        }
        public decimal GetTotalValue()
        {
            decimal total = 0;
            foreach (Coin coin in Coins)
            {
                total += coin.Value;
            }
            return total;
        }
        public void Transfer(User sender, User Recipient, Coin coin)
        {
            if (sender.wallet.GetTotalValue() < coin.Value)
            {
                Console.WriteLine("erorr");
            }
            else
            {
                sender.wallet.RemoveCoin(coin);
                Recipient.wallet.AddCoin(coin);
                Console.WriteLine("sucseed");
            }
        }
    }
}
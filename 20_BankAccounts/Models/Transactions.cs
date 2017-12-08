using System;
namespace BankAccounts.Models
{
    public class Transaction 
    {
        public int Transactionid { get; set; }
        public int amount { get; set; }
        public string type { get; set; }
        public DateTime created_at { get; set; }
        public int Userid { get; set; }
        public User User { get; set; }

    }
}
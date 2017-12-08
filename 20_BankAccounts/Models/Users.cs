using System;
using System.Collections.Generic;

namespace BankAccounts.Models
{
    public abstract class BaseEntity 
    {
    }

    public class User : BaseEntity
    {
        public int Userid { get; set; }
        public string first { get; set; }
        public string last { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public int balance { get; set; }

       public List<Transaction> Transactions { get; set; }
       public User(){ //this is a constructor function. When a new user is created, this automatically runs
           Transactions = new List<Transaction>(); //each user has an empty list of transactions
           balance = 200; //gets set at creation bc its inside this constructor function
       }
    }
}
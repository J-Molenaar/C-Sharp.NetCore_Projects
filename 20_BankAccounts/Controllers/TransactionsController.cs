using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using BankAccounts.Models;
using System.Linq;

namespace BankAccounts.Controllers
{
    public class TransactionsController : Controller
    {
        private BankAccountsContext _context;
 
        public TransactionsController(BankAccountsContext context)
        {
            _context = context;
        }
    
        // GET: /Home/
        [HttpGet]
        [Route("account")]
        public IActionResult Dashboard()
        {
            if (TempData["error"]!= null){
                ViewBag.error = TempData["error"];
            }
            
            else{
                ViewBag.error = "";
            }
            ViewBag.CurrUser  = _context.Users.SingleOrDefault(user => user.Userid == HttpContext.Session.GetInt32("CurrUserID"));
            ViewBag.AllTransactions = _context.Transactions.Where(trans => trans.Userid == HttpContext.Session.GetInt32("CurrUserID"));

            return View("Transactions");
        }

        [HttpPost]
        [Route("add")]
        public IActionResult AddTrans(int amount)
        {
            User CurrUser = _context.Users.SingleOrDefault(u => u.Userid == HttpContext.Session.GetInt32("CurrUserID") );

            BankAccounts.Models.Transaction NewTrans = new BankAccounts.Models.Transaction{
                amount = amount,
                created_at = DateTime.Now,
                Userid = (int) HttpContext.Session.GetInt32("CurrUserID")
                };

            if(amount < 0){
                if( (-1* amount) > CurrUser.balance){
                    TempData["error"]= "Not enough funds for this transaction.";
                    return RedirectToAction("Dashboard");
                }
            }
            if(amount > 0){
                NewTrans.type = "Deposit";
            } else{
                NewTrans.type = "Withdrawl";
            }
            _context.Add(NewTrans);
            CurrUser.balance += amount;
            _context.SaveChanges();  
            return RedirectToAction("Dashboard");
        }

    }
}
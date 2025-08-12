using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SpndSMRT.Models;

namespace SpndSMRT.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly SpndSMRTDbContext _context;

        public HomeController(ILogger<HomeController> logger, SpndSMRTDbContext context)
        {
            _logger = logger;
            _context = context; //context gets injected into the instance of this controller 
        }
         
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult CreateEditExpense(int? id) //could be null so we add int? meaning that our id could be null 
        {
            if(id != null)
            {
                //editing -> load an expense by its id
                var expenseInDb = _context.Expenses.SingleOrDefault(expense => expense.Id == id);
                return View(expenseInDb);
            }
           
            return View();
        }

        public IActionResult DeleteExpense(int id )
        {
            var expenseInDb = _context.Expenses.SingleOrDefault(expense => expense.Id == id);
            _context.Expenses.Remove(expenseInDb);
            _context.SaveChanges();
            return RedirectToAction("Expenses");
        }

        public IActionResult Expenses()
        {
            //we aim to display entire expenses database 
            var allExpenses = _context.Expenses.ToList();

            var totalExpenses = allExpenses.Sum(x => x.Value);

            ViewBag.Expenses = totalExpenses;

            return View(allExpenses);
        }

        public IActionResult CreateEditExpenseForm(Expense model) 
        {
            if(model.Id == 0)
            {
                //create
                _context.Expenses.Add(model); //access and add to database 
            }
            else
            {     
                //editing
                _context.Expenses.Update(model); 
            }

                _context.SaveChanges(); // save changes in database 
            
            return RedirectToAction("Expenses");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

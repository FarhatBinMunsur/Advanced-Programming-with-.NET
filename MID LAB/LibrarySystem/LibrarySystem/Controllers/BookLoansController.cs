using LibrarySystem.EF;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.Controllers
{
    public class BookLoansController : Controller
    {
        public LibraryDbContext context;

        public BookLoansController(LibraryDbContext _context)
        {
            context = _context;
        }

        public IActionResult Index()
        {

            var loans=context.BookLoans.OrderByDescending(l=>l.BorrowedAt).ToList();

            if (loans == null) ViewBag.noData = "No Records Found";
            return View(loans);


        }

        public  IActionResult LongLoans()
        {

            var loans = context.BookLoans.Where(l => l.LoanDays > 14).OrderByDescending(ls=>ls.LoanDays).ToList;
            return View(loans);
        }

        public IActionResult GenreAverage()
        {
            var loans = context.BookLoans.GroupBy(g => g.Genre).Select(s => new { gen = s.Key, avg = s.Average(g => g.LateFee) }).OrderByDescending(k=>k.avg).ToList();
            return View(loans);
        }

        public IActionResult LongestPerGenre()
        {
            var loans = context.BookLoans.GroupBy(l => l.Genre).Select(g=>g.OrderByDescending(l=>l.LoanDays).First()).ToList();
            
            ViewBag.maxLateFee = loans.Max(b=>b.LateFee);
            return View(loans);
        }



       
    }
}

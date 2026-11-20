using EFcoreDFpmb.EF;
using Microsoft.AspNetCore.Mvc;
using EFcoreDFpmb.Models;
using System.Transactions;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
namespace EFcoreDFpmb.Controllers
{
    public class DepertmentController : Controller
    {
        public DotNetContext _context;

        public DepertmentController(DotNetContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var depts= _context.Depertments.ToList();
                
            return View(depts);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(Depertment d)
        {
            if (!ModelState.IsValid)
            {
                return View(d);
            }
            _context.Depertments.Add(d);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var dept = _context.Depertments.Find(id);

            if (dept != null)
            {
                return View(dept);
            }

            return RedirectToAction("index");
        }

        [HttpPost]
        public IActionResult Update(Depertment d)
        {
            if (ModelState.IsValid)
            {
                _context.Depertments.Update(d);
                _context.SaveChanges();
                TempData["success"] = "success";
                return RedirectToAction("index");
            }

            return View(d);

        }

        public IActionResult Delete(int id)
        {
            var d = _context.Depertments.Find(id);
            if (d != null)
            {
                _context.Depertments.Remove(d);
                _context.SaveChanges();
            }
            return RedirectToAction("index");

        }
    }
}

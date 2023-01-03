using EternaProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace EternaProject.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class CountsController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public CountsController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IActionResult Index()
        {
            List<Counts> counts = _appDbContext.Counts.ToList();
            return View(counts);
        }

        //Create---------------------------------
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Counts counts)
        {
            if (!ModelState.IsValid) return View();

            _appDbContext.Counts.Add(counts);
            _appDbContext.SaveChanges();

            return RedirectToAction("index");
        }

        //Edit-------------------------------------

        public IActionResult Edit(int id)
        {
            Counts counts = _appDbContext.Counts.Find(id);

            if (counts is null) return NotFound();

            return View(counts);
        }

        [HttpPost]
        public IActionResult Edit(Counts newcount)
        {
            Counts existCount = _appDbContext.Counts.Find(newcount.Id);

            if (existCount is null) return NotFound();

            existCount.Icon = newcount.Icon;
            existCount.Number = newcount.Number;
            existCount.Title = newcount.Title;
            existCount.Description = newcount.Description;
            existCount.RedirectUrl = newcount.RedirectUrl;

            _appDbContext.SaveChanges();

            return RedirectToAction("Index");
        }
        //Delete-------------------------------------

        public IActionResult Delete(int id)
        {
            Counts counts = _appDbContext.Counts.Find(id);
            if (counts is null) return NotFound();
            return View(counts);
        }

        [HttpPost]
        public IActionResult Delete(Counts counts)
        {
            if (!ModelState.IsValid) return View();

            _appDbContext.Counts.Remove(counts);
            _appDbContext.SaveChanges();

            return RedirectToAction("index");
        }
    }
}

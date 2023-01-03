using EternaProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace EternaProject.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class HeroController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public HeroController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IActionResult Index()
        {
            List<Hero> heroes = _appDbContext.Heroes.ToList();
            return View(heroes);
        }

        //Create---------------------------------
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Hero hero)
        {
            if (!ModelState.IsValid) return View();

            _appDbContext.Heroes.Add(hero);
            _appDbContext.SaveChanges();

            return RedirectToAction("index");
        }

        //Edit-------------------------------------

        public IActionResult Edit(int id)
        {
            Hero hero = _appDbContext.Heroes.Find(id);

            if (hero is null) return NotFound();

            return View(hero);
        }

        [HttpPost]
        public IActionResult Edit(Hero newHero)
        {
            Hero existHero = _appDbContext.Heroes.Find(newHero.Id);

            if (existHero is null) return NotFound();

            existHero.ImageUrl = newHero.ImageUrl;
            existHero.TitleBlack = newHero.TitleBlack;
            existHero.TitleRed = newHero.TitleRed;
            existHero.Description = newHero.Description;
            existHero.RedirectUrl = newHero.RedirectUrl;

            _appDbContext.SaveChanges();

            return RedirectToAction("Index");
        }
        //Delete-------------------------------------

        public IActionResult Delete(int id)
        {
            Hero hero = _appDbContext.Heroes.Find(id);
            if (hero is null) return NotFound();
            return View(hero);
        }

        [HttpPost]
        public IActionResult Delete(Hero hero)
        {
            if (!ModelState.IsValid) return View();

            _appDbContext.Heroes.Remove(hero);
            _appDbContext.SaveChanges();

            return RedirectToAction("index");
        }

    }
}

using EternaProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace EternaProject.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class ServicesController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public ServicesController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IActionResult Index()
        {
            List<Services> services = _appDbContext.Services.ToList();
            return View(services);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Services service)
        {
            if (!ModelState.IsValid) return View();

            _appDbContext.Services.Add(service);
            _appDbContext.SaveChanges();

            return RedirectToAction("index");
        }

        public IActionResult Edit(int id)
        {
            Services service = _appDbContext.Services.Find(id);

            if (service is null) return NotFound();

            return View(service);
        }

        [HttpPost]
        public IActionResult Edit(Services newService)
        {
            Services existService = _appDbContext.Services.Find(newService.Id);

            if (existService is null) return NotFound();

            existService.Title = newService.Title;
            existService.IconClass = newService.IconClass;
            existService.Description = newService.Description;

            _appDbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Services service = _appDbContext.Services.Find(id);
            if (service is null) return NotFound();
            return View(service);
        }

        [HttpPost]
        public IActionResult Delete(Services service)
        {
            if (!ModelState.IsValid) return View();

            _appDbContext.Services.Remove(service);
            _appDbContext.SaveChanges();

            return RedirectToAction("index");
        }
    }
}

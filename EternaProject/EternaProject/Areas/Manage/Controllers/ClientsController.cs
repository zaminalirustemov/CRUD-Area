using EternaProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace EternaProject.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class ClientsController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public ClientsController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IActionResult Index()
        {
            List<Clients> clients = _appDbContext.Clients.ToList();

            return View(clients);
        }

        //Create---------------------------------
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Clients clients)
        {
            if (!ModelState.IsValid) return View();

            _appDbContext.Clients.Add(clients);
            _appDbContext.SaveChanges();

            return RedirectToAction("index");
        }

        //Edit-------------------------------------

        public IActionResult Edit(int id)
        {
            Clients clients = _appDbContext.Clients.Find(id);

            if (clients is null) return NotFound();

            return View(clients);
        }

        [HttpPost]
        public IActionResult Edit(Clients newclient)
        {
            Clients existclient = _appDbContext.Clients.Find(newclient.Id);

            if (existclient is null) return NotFound();

            existclient.ImageUrl = newclient.ImageUrl;

            _appDbContext.SaveChanges();

            return RedirectToAction("Index");
        }
        //Delete-------------------------------------

        public IActionResult Delete(int id)
        {
            Clients client = _appDbContext.Clients.Find(id);
            if (client is null) return NotFound();
            return View(client);
        }

        [HttpPost]
        public IActionResult Delete(Clients client)
        {
            if (!ModelState.IsValid) return View();

            _appDbContext.Clients.Remove(client);
            _appDbContext.SaveChanges();

            return RedirectToAction("index");
        }
    }
}

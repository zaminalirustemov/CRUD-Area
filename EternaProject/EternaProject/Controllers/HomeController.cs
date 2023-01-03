using EternaProject.Models;
using EternaProject.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace EternaProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        public HomeController(AppDbContext appDbContext)
        {
            _context=appDbContext;
        }
        public IActionResult Index()
        {
            HomeViewModel homeViewModel = new HomeViewModel
            {
                Heroes = _context.Heroes.ToList(),
                Services = _context.Services.ToList(),
                Clients = _context.Clients.ToList(),
            };
            return View(homeViewModel);
        }

    }
}
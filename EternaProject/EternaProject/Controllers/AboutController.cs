using EternaProject.Models;
using EternaProject.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace EternaProject.Controllers
{
    public class AboutController : Controller
    {
        private readonly AppDbContext _dataContext;

        public AboutController(AppDbContext dataContext)
        {
            _dataContext = dataContext;
        }
        public IActionResult Index()
        {
            AboutViewModel aboutViewModel = new AboutViewModel
            {
                Counts = _dataContext.Counts.ToList(),
                Clients = _dataContext.Clients.ToList(),
                Testimonials = _dataContext.Testimonials.ToList(),
            };
            return View(aboutViewModel);
        }
    }
}

using EternaProject.Models;
using EternaProject.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EternaProject.Controllers
{
    public class PortfolioController : Controller
    {
        private readonly AppDbContext _dataContext;

        public PortfolioController(AppDbContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IActionResult Index()
        {
            PortfolioViewModel portfolioVM = new PortfolioViewModel
            {
                Portfolios = _dataContext.Portfolios.Include(x => x.Category).Include(x=>x.PortfolioImages).ToList(),
                Categories = _dataContext.Categories.ToList()
            };

            return View(portfolioVM);
        }
        public IActionResult Detail(int id)
        {
            Portfolio portfolio = _dataContext.Portfolios.Include(x => x.Category).Include(x => x.PortfolioImages).FirstOrDefault(x => x.Id == id);

            return View(portfolio);
        }
    }
}

using EternaProject.Models;
using EternaProject.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace EternaProject.Controllers
{
    public class TeamController : Controller
    {
        private readonly AppDbContext _dataContext;

        public TeamController(AppDbContext appDbContext)
        {
            _dataContext = appDbContext;
        }
        public IActionResult Index()
        {
            TeamViewModel teamViewModel = new TeamViewModel
            {
                Teams=_dataContext.Teams.ToList(),
            };
            return View(teamViewModel);
        }
    }
}

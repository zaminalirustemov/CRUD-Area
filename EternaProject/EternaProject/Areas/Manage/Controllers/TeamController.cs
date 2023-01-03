using EternaProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace EternaProject.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class TeamController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public TeamController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IActionResult Index()
        {
            List<Team> teams = _appDbContext.Teams.ToList();
            return View(teams);
        }


        //Create---------------------------------
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Team team)
        {
            if (!ModelState.IsValid) return View();

            _appDbContext.Teams.Add(team);
            _appDbContext.SaveChanges();

            return RedirectToAction("index");
        }

        //Edit-------------------------------------

        public IActionResult Edit(int id)
        {
            Team team = _appDbContext.Teams.Find(id);

            if (team is null) return NotFound();

            return View(team);
        }

        [HttpPost]
        public IActionResult Edit(Team newteam)
        { 
            Team existTeam = _appDbContext.Teams.Find(newteam.Id);

            if (existTeam is null) return NotFound();

            existTeam.ImageUrl = newteam.ImageUrl;
            existTeam.Fullname = newteam.Fullname;
            existTeam.Position = newteam.Position;
            existTeam.Description = newteam.Description;
            existTeam.TwitterUrl = newteam.TwitterUrl;
            existTeam.FacebookUrl = newteam.FacebookUrl;
            existTeam.InstagramUrl = newteam.InstagramUrl;
            existTeam.LinkedinUrl = newteam.LinkedinUrl;

            _appDbContext.SaveChanges();

            return RedirectToAction("Index");
        }
        //Delete-------------------------------------

        public IActionResult Delete(int id)
        {
            Team team = _appDbContext.Teams.Find(id);
            if (team is null) return NotFound();
            return View(team);
        }

        [HttpPost]
        public IActionResult Delete(Team team)
        {
            if (!ModelState.IsValid) return View();

            _appDbContext.Teams.Remove(team);
            _appDbContext.SaveChanges();

            return RedirectToAction("index");
        }
    }
}

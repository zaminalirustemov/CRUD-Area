using EternaProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace EternaProject.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class TestimonialsController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public TestimonialsController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IActionResult Index()
        {
            List<Testimonials> testimonials = _appDbContext.Testimonials.ToList();
            return View(testimonials);
        }


        //Create---------------------------------
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Testimonials testimonials)
        {
            if (!ModelState.IsValid) return View();

            _appDbContext.Testimonials.Add(testimonials);
            _appDbContext.SaveChanges();

            return RedirectToAction("index");
        }

        //Edit-------------------------------------

        public IActionResult Edit(int id)
        {
            Testimonials testimonial = _appDbContext.Testimonials.Find(id);

            if (testimonial is null) return NotFound();

            return View(testimonial);
        }

        [HttpPost]
        public IActionResult Edit(Testimonials newtestimonial)
        {
            Testimonials existTestimonial = _appDbContext.Testimonials.Find(newtestimonial.Id);

            if (existTestimonial is null) return NotFound();

            existTestimonial.ImageUrl = newtestimonial.ImageUrl;
            existTestimonial.Fullname = newtestimonial.Fullname;
            existTestimonial.Position = newtestimonial.Position;
            existTestimonial.Description = newtestimonial.Description;

            _appDbContext.SaveChanges();

            return RedirectToAction("Index");
        }
        //Delete-------------------------------------

        public IActionResult Delete(int id)
        {
            Testimonials testimonials = _appDbContext.Testimonials.Find(id);
            if (testimonials is null) return NotFound();
            return View(testimonials);
        }

        [HttpPost]
        public IActionResult Delete(Testimonials testimonial)
        {
            if (!ModelState.IsValid) return View();

            _appDbContext.Testimonials.Remove(testimonial);
            _appDbContext.SaveChanges();

            return RedirectToAction("index");
        }
    }
}

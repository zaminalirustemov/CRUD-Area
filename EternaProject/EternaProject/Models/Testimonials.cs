using System.ComponentModel.DataAnnotations;

namespace EternaProject.Models
{
    public class Testimonials
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        [StringLength(maximumLength: 30)]
        public string Fullname { get; set; }
        [StringLength(maximumLength: 50)]
        public string Position { get; set; }
        public string Description { get; set; }
    }
}

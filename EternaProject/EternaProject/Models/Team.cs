using System.ComponentModel.DataAnnotations;

namespace EternaProject.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        [StringLength(maximumLength: 30)]
        public string Fullname { get; set; }
        [StringLength(maximumLength: 50)]
        public string Position { get; set; }
        public string Description { get; set; }
        public string TwitterUrl { get; set; }
        public string FacebookUrl { get; set; }
        public string InstagramUrl { get; set; }
        public string LinkedinUrl { get; set; }
    }
}

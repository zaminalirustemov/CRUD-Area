﻿using System.ComponentModel.DataAnnotations;

namespace EternaProject.Models
{
    public class Portfolio
    {

        public int Id { get; set; }
        public int CategoryId { get; set; }
        [StringLength(maximumLength: 20)]
        public string Title { get; set; }
        [StringLength(maximumLength: 500)]
        public string Desc { get; set; }
        public string Client { get; set; }
        public string ProjectUrl { get; set; }
        public DateTime Date { get; set; }
        public Category Category { get; set; }
        public List<PortfolioImage> PortfolioImages { get; set; }
    }
}

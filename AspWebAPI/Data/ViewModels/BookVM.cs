using System;
using System.ComponentModel.DataAnnotations;

namespace AspWebAPI.Data.ViewModels
{
    public class BookVM
    {
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [MinLength(0), MaxLength(5)]
        public float? Rate { get; set; }
        public string CoverUrl { get; set; }
        public string Genre { get; set; }
        [Required]
        public int Author_ID { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspWebAPI.Data.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }

        [MinLength(0), MaxLength(5)]
        public float? Rate { get; set; }
        public string CoverUrl { get; set; }
        public string Genre { get; set; }

        [Required]
        [Column("Author")]
        public int Author_ID { get; set; }

        [ForeignKey(nameof(Author_ID))]
        public virtual Author Author { get; set; }

        public virtual ICollection<BookReader> BookReaders { get; set; }

        [Required]
        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        public DateTimeOffset Created_at { get; set; } = DateTimeOffset.Now;
    }
}

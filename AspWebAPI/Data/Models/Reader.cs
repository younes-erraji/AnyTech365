using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Microsoft.EntityFrameworkCore;

namespace AspWebAPI.Data.Models
{
    [Index(nameof(Mail), IsUnique = true)]
    public class Reader
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(25, MinimumLength = 5)]
        public string FirstName { get; set; }
        [Required, StringLength(25, MinimumLength = 5)]
        public string LastName { get; set; }
        [Required, EmailAddress]
        public string Mail { get; set; }

        [Required, StringLength(25, MinimumLength = 5)]
        public string Gender { get; set; }

        public virtual ICollection<BookReader> ReaderBooks { get; set; }

        public DateTimeOffset Created_at { get; set; } = DateTimeOffset.Now;
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

namespace AspWebAPI.Data.Models
{
    [Index(nameof(Username), IsUnique = true)]
    public partial class Author
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(25)]
        public string FirstName { get; set; }
        [Required, StringLength(25)]
        public string LastName { get; set; }

        [StringLength(25)]
        public string NickName { get; set; }

        [Required, StringLength(25)]
        public string Username { get; set; }
        [Required, StringLength(25)]
        public string Password { get; set; }

        public virtual ICollection<Book> Books { get; set; }

        public DateTimeOffset Creater_at { get; set; } = DateTimeOffset.Now;
    }

    public partial class Author
    {
        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";
    }
}

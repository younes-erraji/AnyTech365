using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspWebAPI.Data.Models
{
    public class BookReader
    {
        public int Id { get; set; }

        public int ReaderId { get; set; }
        [ForeignKey(nameof(ReaderId))]
        public virtual Reader Reader { get; set; }

        public int BookId { get; set; }
        [ForeignKey(nameof(BookId))]
        public virtual Book Book { get; set; }

        /*
        public bool IsRead { get; set; }
        public bool IsDone { get; set; }
        */

        public int? Rate { get; set; }

        public DateTimeOffset? Read_at { get; set; }

        public DateTimeOffset? ExperationDate { get; set; }
    }
}

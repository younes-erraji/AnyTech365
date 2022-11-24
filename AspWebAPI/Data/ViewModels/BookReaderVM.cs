using System;

namespace AspWebAPI.Data.ViewModels
{
    public class BookReaderVM
    {
        public int ReaderId { get; set; }

        public int BookId { get; set; }

        public int? Rate { get; set; }

        public DateTimeOffset? Read_at { get; set; }

        public DateTimeOffset? ExperationDate { get; set; }
    }
}

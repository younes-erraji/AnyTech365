using System.ComponentModel.DataAnnotations;

namespace AspWebAPI.Data.ViewModels
{
    public class ReaderVM
    {
        [Required, StringLength(25, MinimumLength = 5)]
        public string FirstName { get; set; }
        [Required, StringLength(25, MinimumLength = 5)]
        public string LastName { get; set; }
        [Required, EmailAddress]
        public string Mail { get; set; }

        [Required, StringLength(25, MinimumLength = 5)]
        public string Gender { get; set; }
    }
}

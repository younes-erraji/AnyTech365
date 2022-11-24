using System;
using System.ComponentModel.DataAnnotations;

namespace AspWebAPI.Data.ViewModels
{
    public class AuthorVM
    {
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
    }
}

using Microsoft.Build.Framework;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace MVC_Producr.Models.ViewModels
{
    public class UserViewModel
    {
        [Required]
        [StringLength(16), MinLength(3)]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Must be between 5 and 255 characters")]
        [PasswordPropertyText(true)]
        public string? Password { get; set; }
    }
}

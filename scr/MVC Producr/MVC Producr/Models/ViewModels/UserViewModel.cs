using Microsoft.Build.Framework;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace MVC_Producr.Models.ViewModels
{
    public class UserViewModel
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ElmålingsSystem.MVC.Models
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "BrugerLogin")]
        public int BrugerLogin { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}

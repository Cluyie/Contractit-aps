using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ElmålingsSystem.DAL.Models;
using Microsoft.AspNetCore.Identity;

namespace ElmålingsSystem.MVC.Models
{
    public class RegistrereViewModel
    {
        
        [Required]
        [Display(Name = "BrugerLogin")]
        public int BrugerLogin { get; set; }

        [Required]
        [StringLength(20,ErrorMessage = "{0} skal være mindst {2} og højest {1} bogstaver langt", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name="Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Bekræft Password")]
        [Compare("Password", ErrorMessage = "Password og bekræft password matcher ikke")]
        public string ConfirmPassword { get; set; }

        public string Name { get; set; }

        public List<IdentityRole> Roller { get; set; }



    }
}

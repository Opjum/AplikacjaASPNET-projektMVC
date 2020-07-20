using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AplikacjaASPNET.Views.ViewModels
{
    public class StudentCreateViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Imie")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Nazwisko")]
        public string LastName { get; set; }
        [Required]
        public string ClassCode { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string TitlePage { get; set; }
    }
}

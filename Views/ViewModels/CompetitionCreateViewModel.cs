using AplikacjaASPNET.Models.Konkurs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AplikacjaASPNET.Views.ViewModels
{
    public class CompetitionCreateViewModel
    {
        public int Id { get; set; }
        [Required]
        
        public string Name { get; set; }
        [Required]
        
        public string Adres { get; set; }
        [Required]
        public EnumCategory Category { get; set; }
        [Required]
        
        public string Organiser { get; set; }

        public string TitlePage { get; set; }


    }
}

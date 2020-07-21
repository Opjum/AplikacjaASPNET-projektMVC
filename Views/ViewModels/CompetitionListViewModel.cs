using AplikacjaASPNET.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplikacjaASPNET.Views.ViewModels
{
    public class CompetitionListViewModel : Competition
    {
        public List<Competition> competitions { get; set; }
         public SelectList categories { get; set; }
        public string competitionCategory { get; set; }
        public string searchString { get; set; }


    }
}

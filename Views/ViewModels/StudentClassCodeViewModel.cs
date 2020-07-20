using AplikacjaASPNET.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplikacjaASPNET.Views.ViewModels
{
    public class StudentClassCodeViewModel
    {

        public List<Student> Students { get; set; }
        public SelectList classCodes { get; set; }
        public string studentClassCodes { get; set; }
        public string searchString { get; set; }



    }
}

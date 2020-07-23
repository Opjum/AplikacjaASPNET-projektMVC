using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AplikacjaASPNET.Models
{
    public class CompetitionStudents
    {
        
        public int StudentId { get; set; }

        
        public int CompetitionId { get; set; }

        public Student Student { get; set; }
        public Competition Competition { get; set; }
    }
}

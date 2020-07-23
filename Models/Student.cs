using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AplikacjaASPNET.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required]
        
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string ClassCode { get; set; }
        [Required]
        public string Email { get; set; }

        
        public virtual ICollection<CompetitionStudents> CompetitionStudents { get; set; }




        public Student()
        {

        }

    }
}

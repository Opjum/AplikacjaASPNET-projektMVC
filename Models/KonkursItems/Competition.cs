using AplikacjaASPNET.Models.Konkurs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplikacjaASPNET.Models
{
    public class Competition
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public EnumCategory Category { get; set; }
        public string Adres { get; set; }
        public string Organiser { get; set; }

        public virtual ICollection<CompetitionStudents> CompetitionStudents { get; set; }


        public Competition()
        {

        }

    }
}

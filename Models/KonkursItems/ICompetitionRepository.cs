using AplikacjaASPNET.Models.Konkurs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace AplikacjaASPNET.Models
{
    public interface ICompetitionRepository
    {
        
        
            Competition GetById(int id);
            IEnumerable<Competition> GetAllCompetition();
            Competition Edit(Competition EditCompetition);
            Competition Delete(int id);
            Competition Create(Competition NewCompetition);
            IQueryable<string> GetAllEnumCategory();

        

    }

}

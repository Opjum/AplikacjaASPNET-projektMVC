using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplikacjaASPNET.Models
{
    public class SQLKonkursRepository : ICompetitionRepository
    {
        public AppDbContext _context;
        public Competition Create(Competition NewCompetition)
        {
            _context.CompetitionDB.Add(NewCompetition);
            _context.SaveChanges();
            return NewCompetition;
        }
        public SQLKonkursRepository(AppDbContext context)
        {
            this._context = context;
        }

        public Competition Delete(int id)
        {
            Competition competition = _context.CompetitionDB.Find(id);
            if (competition != null)
            {
                _context.CompetitionDB.Remove(competition);
                _context.SaveChanges();

            }
            return competition;
        }


        public Competition Edit(Competition EditCompetition)
        {
            var competition = _context.CompetitionDB.Attach(EditCompetition);
            competition.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return EditCompetition;
        }

        public IEnumerable<Competition> GetAllCompetition()
        {
            return _context.CompetitionDB;
        }

        public IQueryable<string> GetAllEnumCategory()
        {
            throw new NotImplementedException();
        }

        public Competition GetById(int id)
        {
            return _context.CompetitionDB.Find(id);
        }
    }
}

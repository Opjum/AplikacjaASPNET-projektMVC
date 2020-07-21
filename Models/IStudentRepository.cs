using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplikacjaASPNET.Models
{
    
        public interface IStudentRepository
        {
            Student GetById(int id);
            IEnumerable<Student> GetAllStudent();
            Student Edit(Student EditStudent);
            Student Delete(int id);
            Student Create(Student nowyStudent);
            IQueryable<string> GetAllClasses();

        }
    
}

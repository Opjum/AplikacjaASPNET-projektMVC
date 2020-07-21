using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplikacjaASPNET.Models
{
    public class SQLStudentRepository : IStudentRepository
    {
        private readonly AppDbContext context;

        public SQLStudentRepository(AppDbContext context)
        {
            this.context = context;
        }



        public Student Create(Student nowyStudent)
        {
            context.StudentDB.Add(nowyStudent);
            context.SaveChanges();
            return nowyStudent;

        }

        public Student Delete(int id)
        {
            Student Student = context.StudentDB.Find(id);
            if (Student != null)
            {
                context.StudentDB.Remove(Student);
                context.SaveChanges();

            }
            return Student;
        }

        public Student Edit(Student EditStudent)
        {
            var Student = context.StudentDB.Attach(EditStudent);
            Student.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return EditStudent;
        }

        public IEnumerable<Student> GetAllStudent()
        {
            return context.StudentDB;
        }

        public Student GetById(int id)
        {
            return context.StudentDB.Find(id);
        }

        public IQueryable<string> GetAllClasses()
        {
            var classes = context.StudentDB.Select(x => x.ClassCode);
            return classes;
        }
        


    }
}



using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AplikacjaASPNET.Models;
using AplikacjaASPNET.Views.ViewModels;
using System.Data.SqlTypes;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AplikacjaASPNET.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStudentRepository _StudentRepository;
        private readonly AppDbContext _context;


        public HomeController(IStudentRepository StudentRepository, AppDbContext context)
        {
            _StudentRepository = StudentRepository;
            _context = context;

        }
        [Route("")]
        [Route("Home")]
        [Route("Home/Index")]
        public ViewResult Index()
        {
            return View();
        }
        public IActionResult StudentList(string searchString, string studentClassCodes)
        {
            var query = _context.StudentDB.AsQueryable();

            if (!string.IsNullOrEmpty(studentClassCodes))
                query = query.Where(a => a.ClassCode == studentClassCodes);
            if (!string.IsNullOrEmpty(searchString))
                query = query.Where(a => a.FirstName.Contains(searchString) || a.Email.Contains(searchString));
       





            IQueryable<string> classCodesQuery = _StudentRepository.GetAllClasses();
            //IEnumerable<Student> students;
            //if (!string.IsNullOrEmpty(studentClassCodes))
            //{
            //    students = _StudentRepository.GetAllStudent().Where(s => s.ClassCode.ToLower().Contains(studentClassCodes.ToLower()));
            //}
            //if (!string.IsNullOrEmpty(searchString))
            //{
            //    students = _StudentRepository.GetAllStudent().Where(s => s.FirstName.ToLower().Contains(searchString.ToLower()) ||
            //                   s.LastName.ToLower().Contains(searchString.ToLower()));

            //}           
            //else
            //{
            //    students = _StudentRepository.GetAllStudent();
            //}
            

            var StudentClassCodeVM = new StudentClassCodeViewModel()
            {
                classCodes = new SelectList(classCodesQuery.Distinct()),
                Students = query.ToList()
            };


            return View(StudentClassCodeVM);

        }

        public ActionResult Details(int? id)
        {



            Student student = _StudentRepository.GetById(id ?? 1);
               
            
            return View(student);

        }

        public ViewResult NotFound()
        {
            return View();
        }

        [HttpGet]
        [Route("Home/Create")]
        public ViewResult Create()
        {
            
            return View();
        }
        [HttpPost]
        [Route("Home/Create")]
        public IActionResult Create(Student nowyStudent)
        {
            if (ModelState.IsValid)
            {
                Student newemploye = _StudentRepository.Create(nowyStudent);
                return RedirectToAction("details", new { id = newemploye.Id });
            }
            return View();
        }
        public IActionResult Delete(int id)
        {
            _StudentRepository.Delete(id);
            return RedirectToAction("StudentList");

        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            Student student = _StudentRepository.GetById(id);
            StudentEditViewModel studentEditViewModel = new StudentEditViewModel()
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                ClassCode = student.ClassCode,
                Email = student.Email,
            };

            return View(studentEditViewModel);
        }
        [HttpPost]
        public IActionResult Edit(StudentEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                Student student = _StudentRepository.GetById(model.Id);

                student.FirstName = model.FirstName;
                student.LastName = model.LastName;
                student.ClassCode = model.ClassCode;
                student.Email = model.Email;
                _StudentRepository.Edit(student);
                return RedirectToAction("Details", new { id = model.Id });
            }
            return View(model);
        }

        
        
    }
}



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
using AplikacjaASPNET.Models.Konkurs;

namespace AplikacjaASPNET.Controllers
{
    public class CompetitionController : Controller
    {
        private readonly ICompetitionRepository _CompetitionRepository;
        private readonly AppDbContext _context;


        public CompetitionController(ICompetitionRepository CompetitionRepository, AppDbContext context)
        {
            _CompetitionRepository = CompetitionRepository;
            _context = context;

        }
        
        [Route("Competition")]
        [Route("Competition/Index")]
        public ViewResult Index()
        {
            return View();
        }
        public IActionResult CompetitionList(string searchString, EnumCategory? CompetitionCategory)
        {
            var query = _context.CompetitionDB.AsQueryable();
            if (!string.IsNullOrEmpty(searchString))
                query = query.Where(a => a.Name.Contains(searchString) || a.Organiser.Contains(searchString));
            if (CompetitionCategory.HasValue)
                query = query.Where(a => a.Category == CompetitionCategory);
            

            CompetitionListViewModel competitionListViewModel = new CompetitionListViewModel()
            {
                categories = new SelectList(Enum.GetNames(typeof(EnumCategory))),

                competitions = query.ToList(),
            };
            return View(competitionListViewModel);
            
        }

        public ActionResult CompetitionDetails(int? id)
        {



            Competition Competition = _CompetitionRepository.GetById(id ?? 1);


            return View(Competition);

        }

        public ViewResult NotFound()
        {
            return View();
        }

        [HttpGet]
        [Route("Competition/CompetitionCreate")]
        public ViewResult CompetitionCreate()
        {
            SelectList categories = new SelectList(Enum.GetNames(typeof(EnumCategory)));
            return View();
        }
        [HttpPost]
        [Route("Competition/CompetitionCreate")]
        public IActionResult CompetitionCreate(Competition nowyCompetition)
        {
            if (ModelState.IsValid)
            {
                Competition newemploye = _CompetitionRepository.Create(nowyCompetition);
                return RedirectToAction("CompetitionDetails", new { id = newemploye.Id });
            }
            return View();
        }
        public IActionResult CompDelete(int id)
        {
            _CompetitionRepository.Delete(id);
            return RedirectToAction("CompetitionList");

        }

        [HttpGet]
        public ViewResult CompetitionEdit(int id)
        {
            Competition Competition = _CompetitionRepository.GetById(id);
            CompetitionEditViewModel CompetitionEditViewModel = new CompetitionEditViewModel()
            {
                
                Name = Competition.Name,
                Organiser = Competition.Organiser,
                Adres = Competition.Adres,
                Category = Competition.Category,
            };

            return View(CompetitionEditViewModel);
        }
        [HttpPost]
        public IActionResult CompetitionEdit(CompetitionEditViewModel newcompetition)
        {
            if (ModelState.IsValid)
            {
                Competition Competition = _CompetitionRepository.GetById(newcompetition.Id);

                
                Competition.Name = newcompetition.Name;
                Competition.Organiser = newcompetition.Organiser;
                Competition.Adres = newcompetition.Adres;
                Competition.Category = newcompetition.Category;
                _CompetitionRepository.Edit(Competition);
                return RedirectToAction("CompetitionDetails", new { id = Competition.Id });
            }
            return View(newcompetition);
        }



    }
}



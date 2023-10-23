using Microsoft.AspNetCore.Mvc;
using WebApplication2.Data;
using WebApplication2.Models;
using WebApplication2.Services;



namespace WebApplication2.Controllers
{
    
    public class InstructorController : Controller
    {
        private readonly AppDbContext _dbContext;

        public InstructorController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {

            return View(_dbContext.Instructors);
        }

        public IActionResult ShowDetail(int id)
        {
            //Search for the student whose id matches the given id
            Instructor? instructor = _dbContext.Instructors.FirstOrDefault(st => st.Id == id);

            if (instructor != null)//was an student found?
                return View(instructor);

            return NotFound();
        }
        [HttpGet]
        public IActionResult AddInstructor()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddInstructor(Instructor newInstructor)
        {
            _dbContext.Instructors.Add(newInstructor);
            _dbContext.SaveChanges();
            return View("Index", _dbContext.Instructors);
        }

        public IActionResult EditInstructor()
        {
            return View();
        }

        [HttpGet]
        public IActionResult EditInstructor(int id)
        {
            Instructor? instructor = _dbContext.Instructors.FirstOrDefault(st => st.Id == id);

            if (instructor != null)
                return View(instructor);

            return NotFound();
        }

        [HttpPost]
        public IActionResult EditInstructor(Instructor instChange)
        {
            var stud = _dbContext.Instructors.FirstOrDefault(st => st.Id == instChange.Id);

            if (stud != null)
            {
                stud.Id = instChange.Id;
                stud.FirstName = instChange.FirstName;
                stud.LastName = instChange.LastName;
                stud.isTenured = instChange.isTenured;
                stud.Rank = instChange.Rank;
                stud.HiringDate = instChange.HiringDate;
                _dbContext.SaveChanges();
                return View("Index", _dbContext.Instructors);
            }
            return NotFound();
        }
        [HttpGet]
        public  IActionResult DeleteInstructor(int id)
        {
            Instructor? instructor = _dbContext.Instructors.FirstOrDefault(st => st.Id == id);
            return View(instructor);
        }
        [HttpPost]
        public IActionResult DeleteInstructor(Instructor instructor)
        {
            var instructorChange = _dbContext.Instructors.FirstOrDefault(st => st.Id == instructor.Id);

            if (instructorChange != null)
            {
                _dbContext.Instructors.Remove(instructorChange);
                _dbContext.SaveChanges();
                return RedirectToAction("index");
            }
            return NotFound();
        }

    }
}


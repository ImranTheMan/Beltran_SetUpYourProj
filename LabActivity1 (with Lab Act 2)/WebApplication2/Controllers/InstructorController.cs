using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.Services;



namespace WebApplication2.Controllers
{
    
    public class InstructorController : Controller
    {
        private readonly IMyFakeDataService _fakeData;
        public InstructorController(IMyFakeDataService fakeData)
        {
            _fakeData = fakeData;
        }

        public IActionResult Index()
        {

            return View(_fakeData.InstructorList);
        }

        public IActionResult ShowDetail(int id)
        {
            //Search for the student whose id matches the given id
            Instructor? instructor = _fakeData.InstructorList.FirstOrDefault(st => st.Id == id);

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
            _fakeData.InstructorList.Add(newInstructor);
            return View("Index", _fakeData.InstructorList);
        }

        public IActionResult EditInstructor()
        {
            return View();
        }

        [HttpGet]
        public IActionResult EditInstructor(int id)
        {
            Instructor? instructor = _fakeData.InstructorList.FirstOrDefault(st => st.Id == id);

            if (instructor != null)
                return View(instructor);

            return NotFound();
        }

        [HttpPost]
        public IActionResult EditInstructor(Instructor instChange)
        {
            var stud = _fakeData.InstructorList.FirstOrDefault(st => st.Id == instChange.Id);

            if (stud != null)
            {
                stud.Id = instChange.Id;
                stud.FirstName = instChange.FirstName;
                stud.LastName = instChange.LastName;
                stud.isTenured = instChange.isTenured;
                stud.Rank = instChange.Rank;
                stud.HiringDate = instChange.HiringDate;
                return View("Index", _fakeData.InstructorList);
            }
            return NotFound();
        }
        [HttpGet]
        public  IActionResult DeleteInstructor(int id)
        {
            Instructor? instructor = _fakeData.InstructorList.FirstOrDefault(st => st.Id == id);
            return View(instructor);
        }
        [HttpPost]
        public IActionResult DeleteInstructor(Instructor instructor)
        {
            var instructorChange = _fakeData.InstructorList.FirstOrDefault(st => st.Id == instructor.Id);

            if (instructorChange != null)
            {
                _fakeData.InstructorList.Remove(instructorChange);
                return RedirectToAction("index");
            }
            return NotFound();
        }

    }
}


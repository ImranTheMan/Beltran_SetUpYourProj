using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;


namespace WebApplication2.Controllers
{
    public class InstructorController : Controller
    {
        List<Instructor> InstructorList = new List<Instructor>
            {
                new Instructor()
                {
                    Id= 1,FirstName = "Gabriel",LastName = "Montano",isTenured = true , Rank = Rank.AssistantProfessor, HiringDate = DateTime.Parse("2022-08-26"), 
                },
                new Instructor()
                {
                    Id= 2,FirstName = "Mariel",LastName = "Blanza", isTenured = false, Rank = Rank.AssociateProfessor, HiringDate = DateTime.Parse("2022-08-07"), 
                },
                new Instructor()
                {
                    Id= 3,FirstName = "Jovy",LastName = "Cabrera", isTenured = true, Rank = Rank.Professor, HiringDate = DateTime.Parse("2020-01-25"), 
                }
            };
        public IActionResult Index()
        {

            return View(InstructorList);
        }

        public IActionResult ShowDetail(int id)
        {
            //Search for the student whose id matches the given id
            Instructor? instructor = InstructorList.FirstOrDefault(st => st.Id == id);

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
            InstructorList.Add(newInstructor);
            return View("Index", InstructorList);
        }

        public IActionResult EditInstructor()
        {
            return View();
        }

        [HttpGet]
        public IActionResult EditInstructor(int id)
        {
            Instructor? instructor = InstructorList.FirstOrDefault(st => st.Id == id);

            if (instructor != null)
                return View(instructor);

            return NotFound();
        }

        [HttpPost]
        public IActionResult EditInstructor(Instructor instChange)
        {
            var stud = InstructorList.FirstOrDefault(st => st.Id == instChange.Id);

            if (stud != null)
            {
                stud.Id = instChange.Id;
                stud.FirstName = instChange.FirstName;
                stud.LastName = instChange.LastName;
                stud.isTenured = instChange.isTenured;
                stud.Rank = instChange.Rank;
                stud.HiringDate = instChange.HiringDate;
                return View("Index", InstructorList);
            }
            return NotFound();
        }

    }
}


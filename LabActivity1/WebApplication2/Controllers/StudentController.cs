using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;


namespace WebApplication2.Controllers
{
    public class StudentController : Controller
    {
        List<Students> StudentList = new List<Students>
            {
                new Students()
                {
                    Id= 1,FirstName = "Gabriel",LastName = "Montano", Course = Course.BSIT, AdmissionDate = DateTime.Parse("2022-08-26"), GPA = 1.5, Email = "ghaby021@gmail.com"
                },
                new Students()
                {
                    Id= 2,FirstName = "Zyx",LastName = "Montano", Course = Course.BSIS, AdmissionDate = DateTime.Parse("2022-08-07"), GPA = 1, Email = "zyx@gmail.com"
                },
                new Students()
                {
                    Id= 3,FirstName = "Aerdriel",LastName = "Montano", Course = Course.BSCS, AdmissionDate = DateTime.Parse("2020-01-25"), GPA = 1.5, Email = "aerdriel@gmail.com"
                }
            };
        public IActionResult Index()
        {

            return View(StudentList);
        }

        public IActionResult ShowDetail(int id)
        {
            //Search for the student whose id matches the given id
            Students? student = StudentList.FirstOrDefault(st => st.Id == id);

            if (student != null)//was an student found?
                return View(student);

            return NotFound();
        }
        [HttpGet]
        public IActionResult AddStudent()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddStudent(Students newStudent)
        {
            StudentList.Add(newStudent);
            return View("Index", StudentList);
        }

        public IActionResult EditStudent()
        {
            return View();
        }

        [HttpGet]
        public IActionResult EditStudent(int id)
        {
            Students? student = StudentList.FirstOrDefault(st => st.Id == id);

            if (student != null)
                return View(student);

            return NotFound();
        }

        [HttpPost]
        public IActionResult EditStudent(Students studentChange)
        {
            var stud = StudentList.FirstOrDefault(st => st.Id == studentChange.Id);

            if (stud != null)
            {
                stud.Id = studentChange.Id;
                stud.FirstName = studentChange.FirstName;
                stud.LastName = studentChange.LastName;
                stud.GPA = studentChange.GPA;
                stud.Course = studentChange.Course;
                stud.AdmissionDate = studentChange.AdmissionDate;
                stud.Email = studentChange.Email;
                return View("Index", StudentList);
            }
            return NotFound();
        }
    }
}

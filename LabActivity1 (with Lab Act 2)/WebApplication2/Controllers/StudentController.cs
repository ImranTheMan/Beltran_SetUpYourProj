using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.Services;


namespace WebApplication2.Controllers
{
    public class StudentController : Controller
    {
        private readonly IMyFakeDataService _fakeData;
        public StudentController(IMyFakeDataService fakeData)
        {
            _fakeData = fakeData;
        }

        public IActionResult Index()
        {

            return View(_fakeData.StudentList);
        }

        public IActionResult ShowDetail(int id)
        {
            //Search for the student whose id matches the given id
            Student? student = _fakeData.StudentList.FirstOrDefault(st => st.Id == id);

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
        public IActionResult AddStudent(Student newStudent)
        {
            _fakeData.StudentList.Add(newStudent);
            return RedirectToAction("Index", _fakeData.StudentList);
        }

        public IActionResult EditStudent()
        {
            return View();
        }

        [HttpGet]
        public IActionResult EditStudent(int id)
        {
            Student? student = _fakeData.StudentList.FirstOrDefault(st => st.Id == id);

            if (student != null)
                return View(student);

            return NotFound();
        }

        [HttpPost]
        public IActionResult EditStudent(Student studentChange)
        {
            var stud = _fakeData.StudentList.FirstOrDefault(st => st.Id == studentChange.Id);

            if (stud != null)
            {
                stud.Id = studentChange.Id;
                stud.FirstName = studentChange.FirstName;
                stud.LastName = studentChange.LastName;
                stud.GPA = studentChange.GPA;
                stud.Course = studentChange.Course;
                stud.AdmissionDate = studentChange.AdmissionDate;
                stud.Email = studentChange.Email;
                return RedirectToAction("index");
            }
            return NotFound();
        }
        [HttpGet]
        public IActionResult DeleteStudent(int id)
        {
            Student? student = _fakeData.StudentList.FirstOrDefault(st => st.Id==id);
            return View(student);
        }
        [HttpPost]
        public IActionResult DeleteStudent(Student student) { 
            var studentChange = _fakeData.StudentList.FirstOrDefault(st => st.Id == student.Id);

            if (studentChange != null)
            {
                _fakeData.StudentList.Remove(studentChange);
                return  RedirectToAction("index");
            }
            return NotFound();
        }

        
       
    }
}

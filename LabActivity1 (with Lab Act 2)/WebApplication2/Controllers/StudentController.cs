using Microsoft.AspNetCore.Mvc;
using WebApplication2.Data;
using WebApplication2.Models;
using WebApplication2.Services;


namespace WebApplication2.Controllers
{
    public class StudentController : Controller
    {
        private readonly AppDbContext _dbContext;

        public StudentController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {

            return View(_dbContext.Students);
        }

        public IActionResult ShowDetail(int id)
        {
            //Search for the student whose id matches the given id
            Student? student = _dbContext.Students.FirstOrDefault(st => st.Id == id);

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
            if (!ModelState.IsValid)
                return View();
            _dbContext.Students.Add(newStudent);
            _dbContext.SaveChanges();
            return RedirectToAction("Index", _dbContext.Students);
            
        }

        public IActionResult EditStudent()
        {
            return View();
        }

        [HttpGet]
        public IActionResult EditStudent(int id)
        {
            Student? student = _dbContext.Students.FirstOrDefault(st => st.Id == id);

            if (student != null)
                return View(student);

            return NotFound();
        }

        [HttpPost]
        public IActionResult EditStudent(Student studentChange)
        {
            var stud = _dbContext.Students.FirstOrDefault(st => st.Id == studentChange.Id);

            if (stud != null)
            {
                stud.Id = studentChange.Id;
                stud.FirstName = studentChange.FirstName;
                stud.LastName = studentChange.LastName;
                stud.GPA = studentChange.GPA;
                stud.Course = studentChange.Course;
                stud.AdmissionDate = studentChange.AdmissionDate;
                stud.Email = studentChange.Email;
                
            }
            _dbContext.SaveChanges();
            return RedirectToAction("index");
        }
        [HttpGet]
        public IActionResult DeleteStudent(int id)
        {
            Student? student = _dbContext.Students.FirstOrDefault(st => st.Id==id);
            return View(student);
        }
        [HttpPost]
        public IActionResult DeleteStudent(Student student) { 
            var studentChange = _dbContext.Students.FirstOrDefault(st => st.Id == student.Id);

            if (studentChange != null)
            {
                _dbContext.Students.Remove(studentChange);
                _dbContext.SaveChanges();
                return  RedirectToAction("index");
            }
            return NotFound();
        }

        
       
    }
}

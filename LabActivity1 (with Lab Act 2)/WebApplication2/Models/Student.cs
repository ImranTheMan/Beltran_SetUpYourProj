using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public enum Course
    {
        BSIT, BSCS, BSIS, OTHER
    }

    public class Student
    {
        [Required]
        public int Id { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage ="last name is required")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "A GPA is Required")]
        [Display(Name = "GPA")]
        public double GPA { get; set; }
        [Required(ErrorMessage ="Pls input what Course you are in")]
        [Display(Name = "Course Chosen")]
        public Course Course { get; set; }
        [Display(Name = "Date of Admission")]
        public DateTime AdmissionDate { get; set; }
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string? Email { get; set; }     

    }
}

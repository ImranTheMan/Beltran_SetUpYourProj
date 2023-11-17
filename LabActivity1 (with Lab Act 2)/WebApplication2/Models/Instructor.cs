using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public enum Rank
    {
        instructor, AssistantProfessor, AssociateProfessor, Professor
    }
     
    


    public class Instructor
    {
        [Required]
        public int Id { get; set; }
        [Display (Name ="First Name")]
        public string FirstName { get; set; }
        [Required (ErrorMessage = "Last Name is required")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [Display (Name = "Academic Rank")]
        public Rank Rank { get; set; }
        [Display (Name = "Is tenured")]
        public bool isTenured { get;set; }
        [Display (Name = " Hiring Date")]
        [DataType (DataType.Date)]

        
        public DateTime HiringDate { get; set; }
        /*[RegularExpression("[0-9] {3}-[0-9] {3} - [0-9]{4}", ErrorMessage ="You must follow the format 000-000")]
        [Display(Name = "Office phone number")]
        public String? PhoneNumber { get; set; }
        [EmailAddress]
        [Display (Name = "Email address")]
        public String? EmailAddress { get; set; }
        [Url]
        [Display(Name = "Personal webpage")]
        public String? PersonalURL { get; set; }
        
        [Required]
        [StringLength (10, MinimumLength = 5)]
        [Display(Name = "Password (NOT ACCEPTED")]
        [DataType(DataType.Password)]
        public string? UnusedPassword { get; set; }*/ 
            

    }
   /* public class YourModel
    {
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateProperty {get ; set;}
        [DisplayFormat(DataFormatString ="{0:C}")]
        public decimal Price { get; set; }
        [DisplayFormat(DataFormatString ="{0:0.00}")]
        public float FloatingNumber { get; set; }
    }*/

}

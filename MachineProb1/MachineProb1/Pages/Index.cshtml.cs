using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace MachineProb1.Pages
{
    public class IndexModel : PageModel
    {

        [BindProperty]
        public decimal PrelimGrade { get; set; }

        [BindProperty]
        public decimal FinalGrade { get; set; }

        public string FirstName { get; } = "Imran Jason";
        public string LastName { get; } = "Beltran";
        public string Email { get; } = "imranjason.beltran.cics@ust.edu.ph";
        public decimal SemGrade { get; private set; }
        public string TransmutedGrade { get; private set; }
        public bool Calculated { get; private set; }

        public void OnGet()
        {
            // Initialize properties as needed
        }

        public IActionResult OnPost()
        {
            // Calculate Semestral Grade and Transmuted Grade
            SemGrade = (PrelimGrade + FinalGrade) / 2;
            TransmutedGrade = CalculateTransmutedGrade(SemGrade);

            Calculated = true;

            return Page();
        }

        private string CalculateTransmutedGrade(decimal semGrade)
        {
            // Implement your logic for calculating the transmuted grade here
            // Example:
            if (semGrade >= 97)
            {
                return "1.00";
            }
            else if (semGrade >= 94)
            {
                return "1.25";
            }
            else if (semGrade >= 91)
            {
                return "1.50";
            }
            else if (semGrade >= 88)
            {
                return "1.75";
            }
            else
            {
                return "2.00";
            }
        }
    }
 }
    
          
    

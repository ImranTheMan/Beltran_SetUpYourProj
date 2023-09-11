using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            DateTime currentDate = DateTime.Now;

            // Define an array of month names
            string[] monthNames = {
            "January", "February", "March", "April", "May", "June", "July",
            "August", "September", "October", "November", "December"
        };

            // Format the date string
            string formattedDate = currentDate.ToString("dddd, d, MMMM");

            // Replace the month placeholder with the actual month name
            formattedDate = formattedDate.Replace("MMMM", monthNames[currentDate.Month - 1]);

            ViewBag.CurrentDate = formattedDate;

            return View();
        }
    }
}

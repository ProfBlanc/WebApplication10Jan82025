using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication10Jan82025.Models;

namespace WebApplication10Jan82025.Pages
{
    public class DealershipModel : PageModel
    {
        private readonly ILogger<DealershipModel> _logger;

        public DealershipModel(ILogger<DealershipModel> logger)
        {
            _logger = logger;
        }

        [BindProperty]
        public List<Car> Cars { get; set; }

        public void OnGet()
        {
            string filter = "All";
            //create a list of 5 cars.
            Cars = new List<Car> {
            new Car(){ CarId=1,Make="Toyota", Model="Prius", Color="Black",Year=2005 },
            new Car(){ CarId=2,Make="Toyota", Model="Carolla", Color="White",Year=2015 },
            new Car(){ CarId=3,Make="Honda", Model="Civic", Color="Green",Year=2025 },
            new Car(){ CarId=4,Make="Telsa", Model="Truck", Color="Silver",Year=2024 },
            new Car(){ CarId=5,Make="Nissan", Model="Rogue", Color="Beige",Year=2022 },
            };




           string result = HttpContext.Request.Query["Make"].ToString();
            if (result.Length > 0) {

                filter = result;
                Cars = Cars.FindAll(s => s.Make.Equals(filter)).ToList();

            }

            ViewData["Filter"] = filter;


        }
    }
}

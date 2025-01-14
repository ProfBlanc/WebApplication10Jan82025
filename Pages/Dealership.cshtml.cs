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

        [BindProperty]
        public List<string> Makes { get; set; }
        [BindProperty]
        public List<string> Models { get; set; }
        [BindProperty]
        public List<string> Cities { get; set; }

        public void OnGet()
        {

            Country canada = new Country() { CountryId = 1, IsoCode = "CA",  
                Name = "Canada" };

            List<Region> provinces = new List<Region>{
                new Region() {RegionID=1 ,Name="Ontario", ABRV="ON",
            Country=canada},
                new Region() {RegionID=2 ,Name="Quebec", ABRV="QC",
            Country=canada},

            };

            List<City> cityList = new List<City> {
                new City(){CityID = 1, Name="Toronto", Province=provinces[0]},
                new City(){CityID = 2, Name="Montreal", Province=provinces[1]},
                new City(){CityID = 3, Name="Brampton", Province=provinces[0]},
            };


            string filter = "All";
            //create a list of 5 cars.
            Cars = new List<Car> {
            new Car(){ CarId=1,Make="Toyota", Model="Prius", Color="Black",
                Year=2005,Location=cityList[0] },
            new Car(){ CarId=2,Make="Toyota", Model="Carolla", Color="White",
                Year=2015,Location=cityList[1] },
            new Car(){ CarId=3,Make="Honda", Model="Civic", Color="Green",
                Year=2025,Location=cityList[2] },
            new Car(){ CarId=4,Make="Telsa", Model="Truck", Color="Silver"
            ,Year=2024,Location=cityList[0] },
            new Car(){ CarId=5,Make="Nissan", Model="Rogue", Color="Beige"
            ,Year=2022,Location=cityList[1] },
            };

            Makes = (from c in Cars select c.Make).Distinct().ToList();
            Models = (from m in Cars select m.Model).Distinct().ToList();
            Cities = (from c in cityList select c.Name).Distinct().ToList();

            string result = string.Empty;

            result = HttpContext.Request.Query["Make"].ToString();
            if (result.Length > 0) {
//                filter = result;
                Cars = Cars.FindAll(s => s.Make.Equals(result)).ToList();
            }

            result = HttpContext.Request.Query["Model"].ToString();
            if (result.Length > 0)
            {
                Cars = Cars.FindAll(s => s.Model.Equals(result)).ToList();
            }
            result = HttpContext.Request.Query["City"].ToString();
            if (result.Length > 0)
            {
                Cars = Cars.FindAll(s => s.Location.Name.Equals(result)).ToList();
            }


            ViewData["Filter"] = filter;


        }
    }
}

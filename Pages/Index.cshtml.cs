using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication10Jan82025.Models;

namespace WebApplication10Jan82025.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        [BindProperty]
        public List<Country> NorthAmerica { get; set; }

        public void OnGet()
        {
            ViewData["author"] = "Ben Blanc";

           string result = HttpContext.Request.Query["CountryId"].ToString();

            ViewData["result"] = result;

            //create a list of 3 contries. Name list northAmerica
            NorthAmerica = new List<Country> {
            new Country{ Name="Canada", CountryId=1, IsoCode="CA" },
            new Country{ Name="United States", CountryId=2, IsoCode="US" },
            new Country{ Name="Mexico", CountryId=3, IsoCode="MX" },
            };

        }
    }
}

using System.ComponentModel.DataAnnotations;

namespace WebApplication10Jan82025.Models
{
    public class City
    {
        public int CityID { get; set; }

        [MinLength(4)]
        [MaxLength(15)]
        public string Name { get; set; }    

        public Region Province { get; set; }
    }
}

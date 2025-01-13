using System.ComponentModel.DataAnnotations;

namespace WebApplication10Jan82025.Models
{
    public class Region
    {
        public int RegionID { get; set; }

        public string Name { get; set;}

        [MinLength(2)]
        [MaxLength(5)]
        public string ABRV { get; set; }

        public Country Country { get; set; }
    }
}

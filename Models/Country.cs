namespace WebApplication10Jan82025.Models
{
    public class Country
    {
        /*
         * CountryID (primary key, unique numerical value to refer to 
         * 1 record of a class
         * 
         * 
         *  Name    Canada, United States, Mexico, etc
         *  
         *  
         *  IsoCode     CA      US          MX
         * 
         */ 

        public int CountryId { get; set; }
        public string Name { get; set; } = "";
        public string IsoCode { get; set; } = string.Empty; //= ""


    }
}

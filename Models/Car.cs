using System.Drawing;

namespace WebApplication10Jan82025.Models
{
    public class Car
    { 
     public int CarId {get;set;}
    public string Make {get;set;}
    public string Model {get; set;} 
    public ushort Year {get; set;} 
    public string Color {get; set;}
    
    public City Location { get; set; }
    }
}

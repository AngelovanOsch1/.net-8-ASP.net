using System.ComponentModel.DataAnnotations;
using WebApp.Models.Shirts.Validations;

namespace WebApp.Models.Shirts
{
    public class Shirt
    {
        public int ShirtId { get; set; }
        [Required]
        public string? Brand { get; set; }
        [Required]
        public string? Color { get; set; }
        [Shirt_EnsureCorrectSizing]
        public int? Size { get; set; }
        public string? Gender { get; set; }
        public int Price {  get; set; }
    }
}
   

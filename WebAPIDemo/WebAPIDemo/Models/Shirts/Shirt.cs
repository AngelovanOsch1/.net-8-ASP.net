using System.ComponentModel.DataAnnotations;
using WebAPIDemo.Models.Shirts.Validations;

namespace WebAPIDemo.Models.Shirts
{
    public class Shirt
    {
        public int ShirtId { get; set; }
        [Required]
        public string? Brand { get; set; }
        public string? Description { get; set; }
        [Required]
        public string? Color { get; set; }
        [Shirt_EnsureCorrectSizing]
        public int? Size { get; set; }
        public string? Gender { get; set; }
        public int Price {  get; set; }

        public bool ValidateDescription()
        {
            return !string.IsNullOrEmpty(Description);
        }
    }
}
   

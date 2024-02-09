using Microsoft.AspNetCore.Mvc;
using WebAPIDemo.Attributes;
using WebAPIDemo.data;
using WebAPIDemo.Filters.ActionFilters;
using WebAPIDemo.Filters.AuthFilter;
using WebAPIDemo.Filters.ExceptionFilters;
using WebAPIDemo.Models.Shirts;

namespace WebAPIDemo.Controllers.Shirts
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/[controller]")]
    [JwtTokenAuthFilter]

    public class ShirtsController : ControllerBase
    {
        private readonly ApplicationDbContext db;

        public ShirtsController(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        [RequiredClaim("read", "true")]
        public IActionResult GetShirts()
        {
            return Ok(db.Shirts.ToList());
        }

        [HttpGet("{id}")]
        [TypeFilter(typeof(Shirt_ValidateShirtIdFilterAttribute))]
        [RequiredClaim("write", "true")]
        public IActionResult GetShirtById(int id) 
        {

            return Ok(HttpContext.Items["shirt"]);
        }

        [HttpPost]
        [TypeFilter(typeof(Shirt_ValidateCreateShirtFilterAttribute))]
        [RequiredClaim("write", "true")]
        public IActionResult CreateShirts([FromBody]Shirt shirt)
        {
            this.db.Shirts.Add(shirt);
            this.db.SaveChanges();
            return CreatedAtAction(nameof(GetShirtById), new { id = shirt.ShirtId}, shirt);
        }

        [HttpPut("{id}")]
        [TypeFilter(typeof(Shirt_ValidateShirtIdFilterAttribute))]
        [Shirt_ValidateUpdateShirtFilter]
        [TypeFilter(typeof(Shirt_HandleUpdateExceptionsFilterAttribute))]
        [RequiredClaim("write", "true")]
        public IActionResult UpdateShirtById(int id, Shirt shirt)
        {
            var shirtToUpdate = HttpContext.Items["shirt"] as Shirt;
            shirtToUpdate.Brand = shirt.Brand;
            shirtToUpdate.Price = shirt.Price;
            shirtToUpdate.Size = shirt.Size;
            shirtToUpdate.Color = shirt.Color;
            shirtToUpdate.Gender = shirt.Gender;

            db.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        [TypeFilter(typeof(Shirt_ValidateShirtIdFilterAttribute))]
        [RequiredClaim("delete", "true")]
        public IActionResult DeleteShirtById(int id)
        {
            var shirtToDelete = HttpContext.Items["shirt"] as Shirt;
            db.Shirts.Remove(shirtToDelete);
            db.SaveChanges();
            return Ok(shirtToDelete);
        }
   }
}

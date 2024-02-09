using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebAPIDemo.data;

namespace WebAPIDemo.Filters.ExceptionFilters
{
    public class Shirt_HandleUpdateExceptionsFilterAttribute: ExceptionFilterAttribute
    {
        private readonly ApplicationDbContext db;

        public Shirt_HandleUpdateExceptionsFilterAttribute(ApplicationDbContext db)
        {
            this.db = db;
        }
        public override void OnException(ExceptionContext context)
        {
            base.OnException(context);

            var stringShirtId = context.RouteData.Values["id"] as string;
            if (int.TryParse(stringShirtId, out int shirtId))
            {
                if (db.Shirts.FirstOrDefault(x => x.ShirtId == shirtId) == null)
                {
                    context.ModelState.AddModelError("ShirtId", "ShirtId doesnt exist anymore");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status404NotFound
                    };
                    context.Result = new NotFoundObjectResult(problemDetails);
                }
            }
        }
    }
}

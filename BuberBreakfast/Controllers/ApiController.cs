using Microsoft.AspNetCore.Mvc;
using ErrorOr;


namespace BuberBreakfast.Controllers
{
    [ApiController]
    // // [Route("[Controller]")] // same as the previous line only that tis wil make the name of the class without controller as the parent route
    [Route("breakfast")] //you can use this as the parent route and let other request suffix this rout at the end
    public class ApiController : ControllerBase
    {
        protected IActionResult Problem(List<Error> errors)
        {
            // this customized problem handler will take a list of errors and return the 
            // customized error message
            var firstError = errors[0];

            var statusCode = firstError.Type switch
            {
                ErrorType.NotFound => StatusCodes.Status404NotFound,
                ErrorType.Validation => StatusCodes.Status400BadRequest,
                ErrorType.Conflict => StatusCodes.Status409Conflict,
                _ => StatusCodes.Status500InternalServerError
            };
            return Problem(statusCode: statusCode, title: firstError.Description);
        }

    }
}
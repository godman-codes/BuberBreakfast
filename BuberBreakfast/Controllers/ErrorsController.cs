using Microsoft.AspNetCore.Mvc;

namespace BuberBreakfast.Controllers
{
    public class ErrorsController : ControllerBase
    {
        [Route("/error")]
        // so the global exception handler specified in the program.cs file detects exception and reroutes 
        // the request to this controller and returns the problem
        public IActionResult Error()
        {
            return Problem();
        }
    }
}
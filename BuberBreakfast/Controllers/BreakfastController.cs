using BuberBreakfast.Contracts.Breakfast;
using BuberBreakfast.Models;
using BuberBreakfast.Services.Breakfasts;
using Microsoft.AspNetCore.Mvc;
using ErrorOr;

namespace BuberBreakfast.Controllers
{
    [ApiController]
    // [Route("[Controller]")] // same as the previous line only that tis wil make the name of the class without controller as the parent route
    [Route("breakfast")] //you can use this as the parent route and let other request suffix this rout at the end
    public class BreakfastController : ControllerBase
    {
        private readonly IBreakfastService _breakfastService;
        // this line is specifying a variable for the breakfast service with type
        // IBreakfastService created in the service file 

        public BreakfastController(IBreakfastService breakfastService)
        {
            // we created a constructor that takes in a parameter of type IBreakfastService
            // and assign it this class attribute of class IBreakfast
            _breakfastService = breakfastService;
        }

        [HttpPost]
        public IActionResult CreateBreakfast(CreateBreakfastRequest request)
        {
            var breakfast = new Breakfast(
                Guid.NewGuid(),
                request.Name,
                request.Description,
                request.StartDateTime,
                request.EndDateTime,
                DateTime.UtcNow,
                request.Savory,
                request.Sweet
            );
            // TODO: save breakfast to database

            _breakfastService.CreateBreakfast(breakfast);
            // we call the createBreakfast method of the IBreakfastService and 
            // pass the new breakfast collected from the request

            var response = new BreakfastResponse(
                breakfast.Id,
                breakfast.Name,
                breakfast.Description,
                breakfast.StartDateTime,
                breakfast.EndDateTime,
                breakfast.LastModifiedDateTime,
                breakfast.Savory,
                breakfast.Sweet
            );
            return CreatedAtAction(
                actionName: nameof(GetBreakfast),
                routeValues: new { id = breakfast.Id },
                value: response
                );
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetBreakfast(Guid id)
        {
            Console.WriteLine("Getting breakfast");
            // Breakfast breakfast = _breakfastService.GetBreakfast(id);
            // call the service method getBreakfast with id as parameter to get the breakfast
            ErrorOr<Breakfast> getBreakfastResult = _breakfastService.GetBreakfast(id);

            return getBreakfastResult.Match(breakfast => Ok(MapBreakfastResponse(breakfast)),
            errors => Problem());
            // the match function of the ErrorOr object maps the two values 
            // and error to what it is meant to be executed

            // if (getBreakfastResult.IsError && getBreakfastResult.FirstError == Errors.Breakfast.NotFound)
            // {
            //     // the ErrorOr return value can be the values or a list of error so we can check which one withe 
            //     // the above condition
            //     return NotFound();
            // }
            // var breakfast = getBreakfastResult.Value;
            // // access the value of the breakfast with .Value property

            // BreakfastResponse response = MapBreakfastResponse(breakfast);
            // // create a new response object with the destructured object and return it 
            // return Ok(response);
        }

        private static BreakfastResponse MapBreakfastResponse(Breakfast breakfast)
        {
            // extract method from the view
            return new BreakfastResponse(
                            breakfast.Id,
                            breakfast.Name,
                            breakfast.Description,
                            breakfast.StartDateTime,
                            breakfast.EndDateTime,
                            breakfast.LastModifiedDateTime,
                            breakfast.Savory,
                            breakfast.Sweet
                        );
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpsertBreakfast(Guid id, UpsertBreakfastRequest request)
        {
            Console.WriteLine("Updating breakfast");
            var breakfast = new Breakfast(
                id,
                request.Name,
                request.Description,
                request.StartDateTime,
                request.EndDateTime,
                DateTime.UtcNow,
                request.Savory,
                request.Sweet
            );
            _breakfastService.UpsertBreakfast(breakfast);

            // TODO: return 201 if a new breakfast was created
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteBreakfast(Guid id)
        {
            Console.WriteLine("Deleting");
            _breakfastService.DeleteBreakfast(id);
            return NoContent();
        }
    }
}
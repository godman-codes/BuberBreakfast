using BuberBreakfast.Contracts.Breakfast;
using BuberBreakfast.Models;
using BuberBreakfast.Services.Breakfasts;
using Microsoft.AspNetCore.Mvc;

namespace BuberBreakfast.Controllers
{
    [ApiController]
    [Route("[Controller]")] // same as the previous line only that tis wil make the name of the class without controller as the parent route
    // [Route("breakfasts")] //you can use this as the parent route and let other request suffix this rout at the end
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
            Breakfast breakfast = _breakfastService.GetBreakfast(id);

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
            return Ok(response);
        }


        [HttpPut("{id:guid}")]
        public IActionResult UpsertBreakfast(Guid id, UpsertBreakfastRequest request)
        {
            return Ok(request);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteBreakfast(Guid id)
        {
            return Ok(id);
        }
    }
}
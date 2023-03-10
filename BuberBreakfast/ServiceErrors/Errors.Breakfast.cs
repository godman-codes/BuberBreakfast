using ErrorOr;
using BuberBreakfast.Models;
namespace BuberBreakfast.ServiceErrors
{
    public class Errors
    {
        public static class Breakfast
        {
            // this method will contain all the error that we expect to see in our application
            public static Error NotFound => Error.NotFound(
                code: "Breakfast.NotFound",
                description: "Breakfast not found"
                );
            public static Error InvalidName => Error.Validation(
                code: "Breakfast.InvalidName",
                description: $"Breakfast name must be at least {Models.Breakfast.MinNameLength}"
                + $"and at most {Models.Breakfast.MaxNameLength} characters long"
            );
            public static Error InvalidDescription => Error.Validation(
                code: "Breakfast.InvalidDescription",
                description: $"Breakfast description must be at least {Models.Breakfast.MinDescriptionLength}"
                + $"and at most {Models.Breakfast.MaxDescriptionLength} characters long"
            );



            // this Error object is gotten from ErrorOr package
        }
    }
}
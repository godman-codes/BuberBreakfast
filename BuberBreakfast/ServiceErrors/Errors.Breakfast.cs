using ErrorOr;

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

            // this Error object is gotten from ErrorOr package
        }
    }
}
using BuberBreakfast.ServiceErrors;
using ErrorOr;

namespace BuberBreakfast.Models
{
    public class Breakfast
    {
        public const int MinNameLength = 3;
        public const int MaxNameLength = 50;
        public const int MinDescriptionLength = 3;
        public const int MaxDescriptionLength = 150;
        public Guid Id { get; }
        public string Name { get; }
        public string Description { get; }
        public DateTime StartDateTime { get; }
        public DateTime EndDateTime { get; }
        public DateTime LastModifiedDateTime { get; }
        public List<string> Savory { get; }
        public List<string> Sweet { get; }

        private Breakfast(
            Guid id,
            string name,
            string description,
            DateTime startDateTime,
            DateTime endDateTime,
            DateTime lastModifiedDateTime,
            List<string> savory,
            List<string> sweet
            )
        {
            // enforce invariants
            Id = id;
            Name = name;
            Description = description;
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
            LastModifiedDateTime = lastModifiedDateTime;
            Savory = savory;
            Sweet = sweet;
        }
        public static ErrorOr<Breakfast> create(
            // this function is used to create a new breakfast after the inputted data passes
            // some rules
            string name,
            string description,
            DateTime startDateTime,
            DateTime endDateTime,
            List<string> savory,
            List<string> sweet,
            Guid? id = null
        )
        {
            List<Error> errors = new();
            if (name.Length < MinNameLength || name.Length > MaxNameLength)
            {
                errors.Add(Errors.Breakfast.InvalidName);
            }
            if (description.Length < MinDescriptionLength || description.Length > MaxDescriptionLength)
            {
                errors.Add(Errors.Breakfast.InvalidDescription);
            }
            if (errors.Count > 0)
            {
                return errors;
            }
            // if (id != null) {
            //     Guid breakfastId = (Guid)id;
            // }else {

            // }
            return new Breakfast(
                id != null ? (Guid)id : Guid.NewGuid(),
                name,
                description,
                startDateTime,
                endDateTime,
                DateTime.UtcNow,
                savory,
                sweet
            );
        }


    }
}
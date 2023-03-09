
using BuberBreakfast.Models;
using ErrorOr;
using BuberBreakfast.ServiceErrors;
namespace BuberBreakfast.Services.Breakfasts
{
    public class BreakfastService : IBreakfastService
    // this class is going to inherit from the IBreakfast service withe interface class
    // and you can now overwrite and create your functions in it

    {
        private static readonly Dictionary<Guid, Breakfast> _breakfasts = new();
        // this dictionary is To Only pair id and name 
        // we put static because we don't want the dictionary created on every request

        public void CreateBreakfast(Breakfast breakfast)
        // this method overrides the interface class create Breakfast method
        {
            _breakfasts.Add(breakfast.Id, breakfast);
            // add the breakfast object and id to the dictionary
        }
        public ErrorOr<Breakfast> GetBreakfast(Guid id)
        {
            // this method will take an id as a parameter and look through the dictionary
            // and return the object with that id
            // NOTE: we are overriding the method in the IBreakfastService interface class
            // return _breakfasts[id];
            if (_breakfasts.TryGetValue(id, out var breakfast))
            {
                return breakfast;
            }
            // so if the object id pair not found in the dictionary 
            // we return the not found error from the NotFound methods in the 
            // error.Breakfast class
            return Errors.Breakfast.NotFound;
        }
        public void UpsertBreakfast(Breakfast breakfast)
        {
            _breakfasts[breakfast.Id] = breakfast;
        }

        public void DeleteBreakfast(Guid id)
        {
            _breakfasts.Remove(id);
        }
    }
}
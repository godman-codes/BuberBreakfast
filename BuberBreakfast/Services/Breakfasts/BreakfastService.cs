
using BuberBreakfast.Models;

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
        public Breakfast GetBreakfast(Guid id)
        {
            // this method will take an id as a parameter and look through the dictionary
            // and return the object with that id
            // NOTE: we are overriding the method in the IBreakfastService interface class
            return _breakfasts[id];
        }
    }
}
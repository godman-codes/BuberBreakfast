namespace BuberBreakfast.Contracts.Breakfast;

public record CreateBreakfastRequest(
    //: 1
    // this record represents an objects that
    // is used to make the breakfast request
    string Name,
    string Description,
    DateTime StartDateTime,
    DateTime EndDateTime,
    List<string> Savory,
    List<string> Sweet
);
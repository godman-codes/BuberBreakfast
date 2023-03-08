namespace BuberBreakfast.Contracts.Breakfast;

public record BreakfastResponse(
    //: 2
    // this record is used to get individual objects
    // of the breakfast in the database by using the unique id
    Guid id,
    string Name,
    string Description,
    DateTime StartDateTime,
    DateTime EndDateTime,
    DateTime LastModifiedDateTime,
    List<string> Savory,
    List<string> Sweet
);
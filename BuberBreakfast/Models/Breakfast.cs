using BuberBreakfast.ServiceErrors;
using ErrorOr;

namespace BuberBreakfast.Models;


public class Breakfast
{
    public const int MinNameLength = 3;
    public const int MaxNameLength = 50;
    public const int MinDescriptionLength = 10;
    public const int MaxDescriptionLength = 150;

    public Guid Id { get; }
    public string Name { get; }
    public string Description { get; }
    public DateTime StartDateTime { get; }
    public DateTime EndDateTime { get; }
    public DateTime LastModified { get; }
    public List<string> Savory { get; }
    public List<string> Sweet { get; }

    //generate base class constructor
    private Breakfast(
        Guid id,
        string name,
        string description,
        DateTime startDateTime,
        DateTime endDateTime,
        DateTime lastModified,
        List<string> savory,
        List<string> sweet)
    {
        //enforce invariants
        Id = id;
        Name = name;
        Description = description;
        StartDateTime = startDateTime;
        EndDateTime = endDateTime;
        LastModified = lastModified;
        Savory = savory;
        Sweet = sweet;
    }

    public static ErrorOr<Breakfast> Create(

        string name,
        string description,
        DateTime startDateTime,
        DateTime endDateTime,

        List<string> savory,
        List<string> sweet,
        Guid? id = null)
    {
        List<Error> errors = new();

        if (name.Length is < MinNameLength or > MaxNameLength)
        {
            errors.Add(Errors.Breakfast.InvalidName);
        }

        if (description.Length is < MinDescriptionLength or > MaxDescriptionLength)
        {
            errors.Add(Errors.Breakfast.InvalidDescription);
        }

        if (errors.Any())
        {
            return errors;
        }
        return new Breakfast(
            id ?? Guid.NewGuid(),
            name,
            description,
            startDateTime,
            endDateTime,
            DateTime.UtcNow,
            savory,
            sweet);
    }


}
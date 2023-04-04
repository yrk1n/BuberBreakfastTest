namespace BuberBreakfast.Models;


public class Breakfast
{
    public Guid Id { get; }
    public string Name { get; }
    public string Description { get; }
    public DateTime StartDateTime { get; }
    public DateTime EndDateTime { get; }
    public DateTime LastModified { get; }
    public List<string> Savory { get; }
    public List<string> Sweet { get; }

    //generate base class constructor
    public Breakfast(Guid id, string name, string description, DateTime startDateTime, DateTime endDateTime, DateTime lastModified, List<string> savory, List<string> sweet)
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

}


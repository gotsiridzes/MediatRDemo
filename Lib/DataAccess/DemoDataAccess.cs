using Lib.Models;

namespace Lib.DataAccess;

public class DemoDataAccess : IDataAccess
{
    private readonly List<PersonModel> _people = new();

    public DemoDataAccess()
    {
        _people.Add(new PersonModel { Id = 1, FirstName = "Saba", LastName = "Gotsiridze" });
        _people.Add(new PersonModel { Id = 2, FirstName = "Saba1", LastName = "Gotsiridze1" });
        _people.Add(new PersonModel { Id = 3, FirstName = "Saba2", LastName = "Gotsiridze2" });
        _people.Add(new PersonModel { Id = 4, FirstName = "Saba3", LastName = "Gotsiridze3" });
        _people.Add(new PersonModel { Id = 5, FirstName = "Saba4", LastName = "Gotsiridze4" });
    }

    public List<PersonModel> GetPeople()
    {
        return _people;
    }

    public PersonModel CreatePerson(string firstName, string lastName)
    {
        var person = new PersonModel
        {
            FirstName = firstName,
            LastName = lastName,
            Id = _people.Max(x => x.Id) + 1
        };
        _people.Add(person);
        return person;
    }
}

public interface IDataAccess
{
    PersonModel CreatePerson(string firstName, string lastName);
    List<PersonModel> GetPeople();
}
using TestingWithAutoFixtureAndMoq.Infrastructure;
using TestingWithAutoFixtureAndMoq.Models;

namespace TestingWithAutoFixtureAndMoq.Repositories;

public class PersonRepository
{
    private readonly ApplicationContext _context;

    public PersonRepository(ApplicationContext context)
    {
        _context = context;
    }

    public Person? Get(Guid personId)
    {
        return _context.People.SingleOrDefault(p => p.Id == personId);        
    }
}

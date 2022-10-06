using TestingWithAutoFixtureAndMoq.Models;

namespace TestingWithAutoFixtureAndMoq.Repositories;

public interface IPersonRepository
{
    Person? Get(Guid personId);
}

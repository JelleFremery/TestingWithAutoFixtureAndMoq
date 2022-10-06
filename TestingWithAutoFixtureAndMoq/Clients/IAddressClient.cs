using TestingWithAutoFixtureAndMoq.Models;

namespace TestingWithAutoFixtureAndMoq.Clients;

public interface IAddressClient
{
    Address GetAddress(string houseNumber, string zipCode);
}

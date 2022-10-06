using TestingWithAutoFixtureAndMoq.Models;

namespace TestingWithAutoFixtureAndMoq.Clients
{
    public class AdressGetter : IAddressClient
    {
        public Address GetAddress(string houseNumber, string zipCode)
        {
            //TODO: Make Http call here to address service
            throw new NotImplementedException();
        }
    }
}

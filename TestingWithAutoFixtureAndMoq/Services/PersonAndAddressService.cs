using TestingWithAutoFixtureAndMoq.Clients;
using TestingWithAutoFixtureAndMoq.Models;
using TestingWithAutoFixtureAndMoq.Repositories;

namespace TestingWithAutoFixtureAndMoq.Services
{
    public class PersonAndAddressService
    {
        private readonly IAddressClient _addressGetter;
        private readonly IPersonRepository _personRepository;

        public PersonAndAddressService(IAddressClient addressGetter, IPersonRepository personRepository)
        {
            _addressGetter = addressGetter;
            _personRepository = personRepository;
        }

        public Address GetAddress(Guid personId)
        {
            var person = _personRepository.Get(personId);
            ArgumentNullException.ThrowIfNull(person);
            
            var address = _addressGetter.GetAddress(person.HouseNumber, person.ZipCode);
            return address;
        }
    }
}

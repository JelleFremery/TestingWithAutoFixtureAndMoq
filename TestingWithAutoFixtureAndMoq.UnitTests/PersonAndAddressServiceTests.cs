namespace TestingWithAutoFixtureAndMoq.UnitTests;

[TestFixture]
public class Tests
{
    private const string DefaultHouseNumber = "1";
    private const string DefaultZipCode = "1111AA";

    private readonly Address _defaultAddress = new() { StreetName = "Street", HouseNumber = DefaultHouseNumber, ZipCode = DefaultZipCode, CountryCode = "NL" };

    [Test]
    [AutoMoq]
    public void GivenPersonExists_WhenGetAddress_ThenAddressIsRetrieved(Guid id, 
        [Frozen] Mock<IPersonRepository> personRepository, 
        [Frozen] Mock<IAddressClient> addressClient,
        PersonAndAddressService sut)
    {        
        Person person = new() { Id = id, HouseNumber = DefaultHouseNumber, ZipCode = DefaultZipCode };
        personRepository.Setup(repo => repo.Get(id)).Returns(person);        
        addressClient.Setup(c => c.GetAddress(DefaultHouseNumber, DefaultZipCode)).Returns(_defaultAddress);
        
        var result = sut.GetAddress(id);
        
        result.Should().BeEquivalentTo(_defaultAddress);
    }

    [Test]
    [AutoMoq]
    public void GivenPersonDoesNotExist_WhenGetAddress_ThenArgumentNullException(Guid id,
        [Frozen] Mock<IPersonRepository> personRepository,
        [Frozen] Mock<IAddressClient> addressClient,
        PersonAndAddressService sut)
    {
        Person? person = null;
        personRepository.Setup(repo => repo.Get(id)).Returns(person);        
        addressClient.Setup(c => c.GetAddress(DefaultHouseNumber, DefaultZipCode)).Returns(_defaultAddress);

        sut.Invoking(s => s.GetAddress(id)).Should().Throw<ArgumentNullException>();        
    }

    [Test]
    [InlineAutoMoq("114A")]
    public void GivenCustomHouseNumbers_WhenGetAddress_ThenReturnsAddress(string houseNumber,
        Guid id,
        [Frozen] Mock<IPersonRepository> personRepository,
        [Frozen] Mock<IAddressClient> addressClient,
        PersonAndAddressService sut)
    {
        Person person = new() { HouseNumber = houseNumber, ZipCode = DefaultZipCode }; 
        personRepository.Setup(repo => repo.Get(id)).Returns(person);
        addressClient.Setup(c => c.GetAddress(houseNumber, DefaultZipCode)).Returns(_defaultAddress);

        var result = sut.GetAddress(id);

        result.Should().BeEquivalentTo(_defaultAddress);

    }
}
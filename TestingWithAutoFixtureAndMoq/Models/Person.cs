namespace TestingWithAutoFixtureAndMoq.Models
{
    public class Person
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string Infix { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string HouseNumber { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty;        
    }
}

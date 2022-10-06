using TestingWithAutoFixtureAndMoq.Infrastructure;

namespace TestingWithAutoFixtureAndMoq.UnitTests.TestInfra;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public class InlineAutoMoqAttribute : InlineAutoDataAttribute
{
    public InlineAutoMoqAttribute(params object[] arguments)
        : base(() =>
        {
            var fixture = new Fixture();
            fixture.Customize(new AutoMoqCustomization { ConfigureMembers = true, GenerateDelegates = true });

            fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
            .ForEach(b => fixture.Behaviors.Remove(b));
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            fixture.Inject(new ApplicationContext(new DbContextOptionsBuilder<ApplicationContext>()
            .UseInMemoryDatabase(fixture.Create<string>())
            .Options));

            return fixture;
        }, arguments)
    { }
}

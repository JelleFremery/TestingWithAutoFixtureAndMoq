using TestingWithAutoFixtureAndMoq.Infrastructure;

namespace TestingWithAutoFixtureAndMoq.UnitTests.TestInfra;

[AttributeUsage(AttributeTargets.Method)]
internal class AutoMoqAttribute : AutoDataAttribute
{
    public AutoMoqAttribute() : base(() =>
    {
        var fixture = new Fixture();
        fixture.Customize(new AutoMoqCustomization { ConfigureMembers = true, GenerateDelegates = true });

        fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
            .ForEach(b => fixture.Behaviors.Remove(b));
        fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        ConfigureFixtureForEntityFramework(fixture);            

        return fixture;
    })
    { }

    private static void ConfigureFixtureForEntityFramework(Fixture fixture)
    {
        fixture.Inject(new ApplicationContext(
            new DbContextOptionsBuilder<ApplicationContext>().UseInMemoryDatabase(fixture.Create<string>()).Options));
    }        
}
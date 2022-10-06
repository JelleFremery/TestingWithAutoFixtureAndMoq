using Microsoft.EntityFrameworkCore;
using TestingWithAutoFixtureAndMoq.Models;

namespace TestingWithAutoFixtureAndMoq.Infrastructure
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<Person> People => Set<Person>();
    }
}
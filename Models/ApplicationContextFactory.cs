using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Community2._0.Models
{
    public sealed class ApplicationContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        public ApplicationContext CreateDbContext(string[] args)
        {
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseNpgsql("Server=localhost;Port=5432;Database=Community20;User Id=postgres;Password=kasymov2002")
                .Options;

            return new ApplicationContext(options);
        }
    }
}
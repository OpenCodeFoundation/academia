using Academia.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Academia.Infrastructure.Data
{
    public class AcademiaContext : DbContext
    {
        public AcademiaContext(DbContextOptions<AcademiaContext> options): base(options)
        {

        }

        public DbSet<Institute> Institutes { get; set; }
        public DbSet<ClassInfo> ClassInfos { get; set; }
    }

    // https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/dbcontext-creation
    public class AcademiaContextDesignFactory : IDesignTimeDbContextFactory<AcademiaContext>
    {
        public AcademiaContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AcademiaContext>()
                .UseSqlServer("Server=.;Initial Catalog=Techcombd.AcademiaDb;Integrated Security=true");

            return new AcademiaContext(optionsBuilder.Options);
        }
    }
}

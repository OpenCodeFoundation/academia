using Academia.Core.Entities;
using Academia.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UnitTests.Entities
{
    public class GuidPrimaryKeyTests
    {
        private readonly DbContextOptions<AppDbContext> options;
        public GuidPrimaryKeyTests()
        {
            var dbOptionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            dbOptionsBuilder.UseInMemoryDatabase("test-academia");
            options = dbOptionsBuilder.Options;
        }

        [Fact]
        public void ShouldGenerateGuidWhenCreatingEntity()
        {
            var institute = new Institute
            {
                Name = "Best Instutute",
            };

            using (var db = new AppDbContext(options))
            {
                db.Institutes.Add(institute);
                db.SaveChanges();
            }

            Assert.NotEqual(Guid.Empty, institute.Id);
        }
    }
}

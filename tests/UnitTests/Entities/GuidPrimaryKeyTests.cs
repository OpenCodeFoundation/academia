using Academia.Core.Entities;
using Academia.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
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
            var institute = CreateNewInstitute();

            using (var db = new AppDbContext(options))
            {
                db.Institutes.Add(institute);
                db.SaveChanges();
            }

            Assert.NotEqual(Guid.Empty, institute.Id);
        }

        [Fact]
        public void NumberOfSavedContentShouldBeNullWhenNoItemAdded()
        {
            Institute actual = null;

            using (var db = new AppDbContext(options))
            {
                actual = db.Institutes.FirstOrDefault();
            }

            Assert.Null(actual);
        }

        [Fact]
        public void ShouldRetriveSavedEntityWithPrimaryKey()
        {
            var institute = CreateNewInstitute();

            Institute retrivedInstitute = null;

            using (var db = new AppDbContext(options))
            {
                db.Institutes.Add(institute);
                db.SaveChanges();

                retrivedInstitute = db.Institutes.Find(institute.Id);
            }

            Assert.Equal(institute, retrivedInstitute);
        }

        private Institute CreateNewInstitute()
        {
            return new Institute
            {
                Name = "Best Institute",
                Website = "http://www.bestinstitute.com",
                Address = "Bangladesh"
            };
        }
    }
}

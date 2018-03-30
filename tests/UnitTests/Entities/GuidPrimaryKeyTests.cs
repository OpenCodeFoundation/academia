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

        [Fact]
        public void ShouldGenerateGuidWhenCreatingEntity()
        {
            var institute = CreateNewInstitute();

            using (var db = new AppDbContext(GetDbContextOptions()))
            {
                db.Institutes.Add(institute);
                db.SaveChanges();
            }

            Assert.NotEqual(Guid.Empty, institute.Id);
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

        private DbContextOptions<AppDbContext> GetDbContextOptions()
        {
            var dbOptionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            string dbName = Guid.NewGuid().ToString();
            dbOptionsBuilder.UseInMemoryDatabase(dbName);
            return dbOptionsBuilder.Options;
        }

        [Fact]
        public void NumberOfSavedContentShouldBeNullWhenNoItemAdded()
        {
            Institute actual = null;

            using (var db = new AppDbContext(GetDbContextOptions()))
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

            using (var db = new AppDbContext(GetDbContextOptions()))
            {
                db.Institutes.Add(institute);
                db.SaveChanges();

                retrivedInstitute = db.Institutes.Find(institute.Id);
            }

            Assert.Equal(institute, retrivedInstitute);
        }
    }
}

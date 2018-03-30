using Academia.Core.Entities;
using Academia.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using UnitTests.Builders;
using Xunit;

namespace UnitTests.Entities
{
    public class GuidPrimaryKeyTests
    {
        private InstituteBuilder InstituteBuilder { get; } = new InstituteBuilder();

        [Fact]
        public void ShouldGenerateGuidWhenCreatingEntity()
        {
            var institute = InstituteBuilder.Build();

            using (var db = new AcademiaContext(GetDbContextOptions()))
            {
                db.Institutes.Add(institute);
                db.SaveChanges();
            }

            Assert.NotEqual(Guid.Empty, institute.Id);
        }

        private DbContextOptions<AcademiaContext> GetDbContextOptions()
        {
            var dbOptionsBuilder = new DbContextOptionsBuilder<AcademiaContext>();
            string dbName = Guid.NewGuid().ToString();
            dbOptionsBuilder.UseInMemoryDatabase(dbName);
            return dbOptionsBuilder.Options;
        }

        [Fact]
        public void NumberOfSavedContentShouldBeNullWhenNoItemAdded()
        {
            Institute actual = null;

            using (var db = new AcademiaContext(GetDbContextOptions()))
            {
                actual = db.Institutes.FirstOrDefault();
            }

            Assert.Null(actual);
        }

        [Fact]
        public void ShouldRetriveSavedEntityWithPrimaryKey()
        {
            var institute = InstituteBuilder.Build();

            Institute retrivedInstitute = null;

            using (var db = new AcademiaContext(GetDbContextOptions()))
            {
                db.Institutes.Add(institute);
                db.SaveChanges();

                retrivedInstitute = db.Institutes.Find(institute.Id);
            }

            Assert.Equal(institute, retrivedInstitute);
        }
    }
}

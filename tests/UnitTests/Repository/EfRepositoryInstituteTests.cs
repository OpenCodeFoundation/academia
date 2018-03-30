using Academia.Core.Entities;
using Academia.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using UnitTests.Builders;
using Xunit;

namespace UnitTests.Repository
{
    public class EfReositoryInstituteTests
    {
        private readonly EfRepository<Institute> _efRepository;
        private InstituteBuilder InstituteBuilder { get; } = new InstituteBuilder();

        public EfReositoryInstituteTests()
        {
            var dbOptions = new DbContextOptionsBuilder<AcademiaContext>()
                .UseInMemoryDatabase(databaseName: "TestContext")
                .Options;

            AcademiaContext dbContext = new AcademiaContext(dbOptions);

            _efRepository = new EfRepository<Institute>(dbContext);
        }

        [Fact]
        public void EfRepositoryShouldDoAsExpected()
        {
            var institute = InstituteBuilder.Build();
            institute = _efRepository.Add(institute);
            var actual = _efRepository.GetById(institute.Id);
            Assert.Equal(institute, actual);

            string updatedName = "Changed Name";
            institute.Name = updatedName;
            _efRepository.Update(institute);
            var updatedInstitute = _efRepository.GetById(institute.Id);
            Assert.Equal(updatedName, updatedInstitute.Name);

            _efRepository.Delete(updatedInstitute);
            var emptyInstitute = _efRepository.GetById(institute.Id);
            Assert.Null(emptyInstitute);
        }
    }
}

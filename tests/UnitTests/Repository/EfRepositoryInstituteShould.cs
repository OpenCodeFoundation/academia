using Academia.Core.Entities;
using Academia.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTests.Builders;
using Xunit;

namespace UnitTests.Repository
{
    public class EfReositoryInstituteShould
    {
        private AcademiaContext _dbContext;
        
        private static DbContextOptions<AcademiaContext> CreateNewContextOptions()
        {
            // Create a fresh service provider, and therefore a fresh 
            // InMemory database instance.
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            // Create a new options instance telling the context to use an
            // InMemory database and the new service provider.
            var builder = new DbContextOptionsBuilder<AcademiaContext>();
            builder.UseInMemoryDatabase("academia")
                .UseInternalServiceProvider(serviceProvider);

            return builder.Options;
        }

        /// <summary>
        /// This method returns a fresh repository every time it is called
        /// </summary>
        /// <returns></returns>
        private EfRepository<Institute> GetRepository()
        {
            var options = CreateNewContextOptions();
            _dbContext = new AcademiaContext(options);
            return new EfRepository<Institute>(_dbContext);
        }

        [Fact]
        public void AddInstituteAndSetId()
        {
            var repository = GetRepository();
            var institute = new Institute();
            repository.Add(institute);

            var newInstitute = repository.ListAll().FirstOrDefault();

            Assert.Equal(institute, newInstitute);
            Assert.NotEqual(Guid.Empty, newInstitute.Id);
        }

        [Fact]
        public void GetItemUsingId()
        {
            var repository = GetRepository();
            var initialName = Guid.NewGuid().ToString();
            var institute = new Institute()
            {
                Name = initialName
            };

            repository.Add(institute);
            var initialId = institute.Id;
            Assert.NotEqual(Guid.Empty, initialId);

            // detach
            _dbContext.Entry(institute).State = EntityState.Detached;

            var newInstitute = repository.GetById(initialId);
            Assert.NotNull(newInstitute);
            Assert.NotSame(institute, newInstitute);
            Assert.Equal(initialName, newInstitute.Name);
        }

        [Fact]
        public async Task GetItemUsingIdAsync()
        {
            var repository = GetRepository();
            var initialName = Guid.NewGuid().ToString();
            var institute = new Institute()
            {
                Name = initialName
            };

            await repository.AddAsync(institute);
            var initialId = institute.Id;
            Assert.NotEqual(Guid.Empty, initialId);

            // detach
            _dbContext.Entry(institute).State = EntityState.Detached;

            var newInstitute = await repository.GetByIdAsync(initialId);
            Assert.NotNull(newInstitute);
            Assert.NotSame(institute, newInstitute);
            Assert.Equal(initialName, newInstitute.Name);
        }

        [Fact]
        public async Task AddInstituteAndSetIdAsync()
        {
            var repository = GetRepository();
            var institute = new Institute();
            await repository.AddAsync(institute);

            var newInstitute = (await repository.ListAllAsync()).FirstOrDefault();

            Assert.Equal(institute, newInstitute);
            Assert.NotEqual(Guid.Empty, newInstitute.Id);
        }

        [Fact]
        public void UpdateInstituteAfterAddingIt()
        {
            var repository = GetRepository();
            var initialName = Guid.NewGuid().ToString();
            var initialAddress = Guid.NewGuid().ToString();
            var institute = new Institute()
            {
                Name = initialName,
                Address = initialAddress
            };

            repository.Add(institute);

            // detach the institute so we get a different instace
            _dbContext.Entry(institute).State = EntityState.Detached;

            var newInstitute = repository.ListAll().FirstOrDefault();
            Assert.NotSame(institute, newInstitute);

            // We can use AutoFixure to generate random string
            // need to check and implement if relevant 
            var newName = Guid.NewGuid().ToString();
            var newAddress = Guid.NewGuid().ToString();

            newInstitute.Name = newName;
            newInstitute.Address = newAddress;

            repository.Update(newInstitute);


            // Detach the newInstitute so we get a different instace
            _dbContext.Entry(newInstitute).State = EntityState.Detached;

            var updatedInstitute = repository.ListAll().FirstOrDefault();
            Assert.NotSame(newInstitute, updatedInstitute);
            Assert.NotEqual(institute.Name, updatedInstitute.Name);
            Assert.NotEqual(institute.Address, updatedInstitute.Address);
        }

        [Fact]
        public async Task UpdateInstituteAfterAddingItAsync()
        {
            var repository = GetRepository();
            var initialName = Guid.NewGuid().ToString();
            var initialAddress = Guid.NewGuid().ToString();
            var institute = new Institute()
            {
                Name = initialName,
                Address = initialAddress
            };

            await repository.AddAsync(institute);

            // detach the institute so we get a different instace
            _dbContext.Entry(institute).State = EntityState.Detached;

            var newInstitute = ( await repository.ListAllAsync()).FirstOrDefault();
            Assert.NotSame(institute, newInstitute);

            // We can use AutoFixure to generate random string
            // need to check and implement if relevant 
            var newName = Guid.NewGuid().ToString();
            var newAddress = Guid.NewGuid().ToString();

            newInstitute.Name = newName;
            newInstitute.Address = newAddress;

            await repository.UpdateAsync(newInstitute);


            // Detach the newInstitute so we get a different instace
            _dbContext.Entry(newInstitute).State = EntityState.Detached;

            var updatedInstitute = ( await repository.ListAllAsync()).FirstOrDefault();
            Assert.NotSame(newInstitute, updatedInstitute);
            Assert.NotEqual(institute.Name, updatedInstitute.Name);
            Assert.NotEqual(institute.Address, updatedInstitute.Address);
        }

        [Fact]
        public void DeleteInstituteAfterAddingIt()
        {
            var repository = GetRepository();
            var initialName = Guid.NewGuid().ToString();
            var institute = new Institute()
            {
                Name = initialName
            };
            repository.Add(institute);

            repository.Delete(institute);
            
            Assert.DoesNotContain(repository.ListAll(), i => i.Name == initialName);

        }

        [Fact]
        public async Task DeleteInstituteAfterAddingItAsyc()
        {
            var repository = GetRepository();
            var initialName = Guid.NewGuid().ToString();
            var institute = new Institute()
            {
                Name = initialName
            };
            await repository.AddAsync(institute);

            await repository.DeleteAsync(institute);

            Assert.DoesNotContain( await repository.ListAllAsync(), i => i.Name == initialName);

        }
        
    }
}

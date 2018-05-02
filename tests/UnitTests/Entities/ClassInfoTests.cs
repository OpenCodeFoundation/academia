using Academia.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UnitTests.Entities
{
    public class ClassInfoTests
    {
        [Fact]
        public void ShouldGenerateGUID()
        {
            var classInfo = new ClassInfo
            {
                Name = "IX",
                Description = "Class Nine"
            };

            Assert.NotEqual(Guid.Empty, classInfo.Id);
        }
    }
}

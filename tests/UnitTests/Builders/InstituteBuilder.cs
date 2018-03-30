using Academia.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests.Builders
{
    public class InstituteBuilder
    {
        public string TestName => "Best Institute";
        public string TestAddress => "Bangladesh";
        public string TestEmail => "test@institute.com";

        public Institute Build()
        {
            return new Institute()
            {
                Name = TestName,
                Address = TestAddress,
                Email = TestAddress
            };
        }
    }
}

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
        public string TestWebsite => "http://www.bestinstitute.com";

        public Institute Build()
        {
            return new Institute()
            {
                Name = TestName,
                Address = TestAddress,
                Website = TestWebsite
            };
        }
    }
}

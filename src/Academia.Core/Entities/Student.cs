using Academia.Core.SharedKernel;
using System;

namespace Academia.Core.Entities
{
    public class Student : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNo { get; set; }
    }
}
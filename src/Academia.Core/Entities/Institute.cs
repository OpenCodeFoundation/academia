using Academia.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Academia.Core.Entities
{
    public class Institute : Entity
    {
        public String Name { get; set; }

        public String Address { get; set; }

        public String Email { get; set; }
    }
}

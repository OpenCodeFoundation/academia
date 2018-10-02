using Academia.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Academia.Core.Entities
{
    public class ClassInfo : Entity
    {
        public String Name { get; set; }

        public String Code { get; set; }

        public String Description { get; set; }
    }
}

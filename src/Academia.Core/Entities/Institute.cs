using Academia.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Academia.Core.Entities
{
    public class Institute : Entity
    {
        public String Name { get; set; }

        public String Code { get; set; }

        public String Slogan { get; set; }

        public String Address { get; set; }

        public String Email { get; set; }

        public String Website { get; set; }

        public String Logo { get; set; }

        public DateTime DateOfEstablishment { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Academia.Core.SharedKernel
{
    /// <summary>
    /// extend this class to every entity
    /// </summary>
    public abstract class Entity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}

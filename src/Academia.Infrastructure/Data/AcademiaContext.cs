using Academia.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Academia.Infrastructure.Data
{
    public class AcademiaContext : DbContext
    {
        public AcademiaContext(DbContextOptions<AcademiaContext> options): base(options)
        {

        }

        public DbSet<Institute> Institutes { get; set; }
    }
}

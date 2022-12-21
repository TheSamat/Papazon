using Microsoft.EntityFrameworkCore;
using Papazon.Application.Interfaces;
using Papazon.Domain;
using Papazon.Persistence.EntityTypeConfigurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papazon.Persistence
{
    public class PapazonDBContext : DbContext, IPapazonDBContext
    {
        public DbSet<Product> Products { get; set; }
        public PapazonDBContext(DbContextOptions<PapazonDBContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder) 
        {
            builder.ApplyConfiguration(new ProductConfiguration());
            base.OnModelCreating(builder);
        }
    }
}

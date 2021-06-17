using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Holodeck
{
    public class MetaContext : DbContext
    {
        public DbSet<MetaData> Metas { get; set; }
        public DbSet<Template> Templates { get; set; }


        public MetaContext(DbContextOptions<MetaContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MetaData>().HasMany(x => x.Templates).WithOne(x => x.MetaData).HasForeignKey(x => x.MetaId);
        }
    }
}
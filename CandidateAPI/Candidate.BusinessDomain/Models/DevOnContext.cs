using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CandidateAPI
{
    public partial class DevOnContext : DbContext
    {
        public DevOnContext()
        {
        }

        public DevOnContext(DbContextOptions<DevOnContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CandidateOverview> CandidateOverviews { get; set; } = null!;

        // Unable to generate entity type for table 'dbo.CandidateStore' since its primary key could not be scaffolded. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=DevOn;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CandidateOverview>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

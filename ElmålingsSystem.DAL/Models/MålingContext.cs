using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElmålingsSystem.DAL.Models
{
    public class MålingContext : DbContext
    {
        public DbSet<Installation> Installationer { get; set; }
        public DbSet<EjerKunde> EjerKunder { get; set; }
        public DbSet<LejerKunde> LejerKunder { get; set; }
        public DbSet <Måler> Måler { get; set; }
        public DbSet<Måleværdier> Måleværdier { get; set; }

        public MålingContext(DbContextOptions<MålingContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            //Her opretter vi en EjerkundeFK i installationer
            modelBuilder.Entity<Installation>()
                .HasOne(p => p.EjerKunde)
                .WithMany(b => b.Installationer)
                .HasForeignKey(p => p.EjerKundeFK);

            //Her opretter vi en installationFK i lejerkunde
            modelBuilder.Entity<Installation>()
                .HasOne(p => p.LejerKunde)
                .WithOne(i => i.Installation)
                .HasForeignKey<LejerKunde>(b => b.InstallionFK);

            //her opretter vi en installationFK i måler
            modelBuilder.Entity<Installation>()
                .HasOne(p => p.Måler)
                .WithOne(i => i.Installation)
                .HasForeignKey<Måler>(b => b.InstallionFK);

            //her opretter vi en MålerFK i måleværdier
            modelBuilder.Entity<Måleværdier>()
                .HasOne(p => p.Måler)
                .WithMany(b => b.Måleværdier)
                .HasForeignKey(p => p.MålerFK);
                
        }

        
    }
}

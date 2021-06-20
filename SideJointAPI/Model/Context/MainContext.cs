using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SideJointAPI.Model
{
    public class MainContext:DbContext
    {
        public DbSet<MasterItem> MasterItems { get; set; }
        public DbSet<PriceTracker> PriceTracker { get; set; }

        public MainContext(DbContextOptions<MainContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {       

            // Map entities to tables  
            modelBuilder.Entity<MasterItem>().ToTable("masteritems");
            // Configure Primary Keys  
            modelBuilder.Entity<MasterItem>().HasKey(u => u.id).HasName("PK_masteritems");
            // Configure columns  
            modelBuilder.Entity<MasterItem>().Property(ug => ug.id).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
            modelBuilder.Entity<MasterItem>().Property(ug => ug.name).HasColumnType("varchar(100)").IsRequired();
            modelBuilder.Entity<MasterItem>().Property(ug => ug.email).HasColumnType("varchar(100)").IsRequired();
            modelBuilder.Entity<MasterItem>().Property(ug => ug.todayopenvalue).HasColumnType("decimal").IsRequired();
            // Map entities to tables  
            modelBuilder.Entity<PriceTracker>().ToTable("pricetracker");
            // Configure Primary Keys  
            modelBuilder.Entity<PriceTracker>().HasKey(u => u.id).HasName("PK_pricetracker");
            // Configure columns  
            modelBuilder.Entity<PriceTracker>().Property(ug => ug.itemid).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
            modelBuilder.Entity<PriceTracker>().Property(ug => ug.price).HasColumnType("decimal").IsRequired();
            modelBuilder.Entity<PriceTracker>().Property(ug => ug.createdat).HasColumnType("timestamp").IsRequired();
            modelBuilder.Entity<PriceTracker>().Property(ug => ug.createdby).HasColumnType("int").IsRequired();
            

        }
    }
}

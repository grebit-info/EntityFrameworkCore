using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCORE.CodeFirst
{
    public class MobileStoreDbContext : DbContext
    {

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer(@"data source=LAPTOP-D97CKR99; initial catalog=MobileStore;integrated security=True;");
                //base.Add(optionsBuilder);
            }

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Product>().Property(p => p.Image)
                .HasMaxLength(150)
                .HasColumnName("img")
                .IsRequired();

        }


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("@data source = LAPTOP-D97CKR99; initial catalog = MobileStore; integrated security = True;");
        //    base.Add(optionsBuilder);

        //}
    }
}

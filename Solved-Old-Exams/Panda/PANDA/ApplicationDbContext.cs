using Microsoft.EntityFrameworkCore;
using PANDA.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PANDA
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=PANDA;Integrated Security=True;");
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Package> Packages { get; set; }

        public DbSet<Receipt> Receipts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Receipt>(entity =>
            {
                entity.HasOne(r => r.Recipient)
                .WithMany(u => u.Receipts)
                .HasForeignKey(r => r.RecipientId)
                .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using CashRegister.Data.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace CashRegister.Data.Entities
{
    public class CashRegisterContext : DbContext
    {
        public CashRegisterContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Bill> Bills { get; set; }
        public DbSet<Cashier> Cashiers { get; set; }
        public DbSet<CashierRegister> CashierRegisters { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Register> Registers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CashierRegister>()
                .HasKey(cr => new {cr.CashierId, cr.RegisterId});
            modelBuilder.Entity<CashierRegister>()
                .HasOne(cr => cr.Cashier)
                .WithMany(c => c.CashierRegisters)
                .HasForeignKey(cr => cr.CashierId);
            modelBuilder.Entity<CashierRegister>()
                .HasOne(cr => cr.Register)
                .WithMany(r => r.CashierRegisters)
                .HasForeignKey(cr => cr.RegisterId);

            modelBuilder.Entity<BillProduct>()
                .HasKey(bp => new {bp.BillId, bp.ProductId});
            modelBuilder.Entity<BillProduct>()
                .HasOne(bp => bp.Bill)
                .WithMany(b => b.BillProducts)
                .HasForeignKey(bp => bp.BillId);
            modelBuilder.Entity<BillProduct>()
                .HasOne(bp => bp.Product)
                .WithMany(p => p.BillProducts)
                .HasForeignKey(bp => bp.BillId);


        }
    }
}

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
        public DbSet<BillProduct> BillProducts { get; set; }
        public DbSet<Cashier> Cashiers { get; set; }
        public DbSet<CashierRegister> CashierRegisters { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Register> Registers { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CashierRegister>()
                .HasKey(cr => new { cr.CashierId, cr.RegisterId });
            modelBuilder.Entity<CashierRegister>()
                .HasOne(cr => cr.Cashier)
                .WithMany(c => c.CashierRegisters)
                .HasForeignKey(cr => cr.CashierId);
            modelBuilder.Entity<CashierRegister>()
                .HasOne(cr => cr.Register)
                .WithMany(r => r.CashierRegisters)
                .HasForeignKey(cr => cr.RegisterId);

            modelBuilder.Entity<BillProduct>()
                .HasKey(bp => new { bp.BillId, bp.ProductId });
            modelBuilder.Entity<BillProduct>()
                .HasOne(bp => bp.Bill)
                .WithMany(b => b.BillProducts)
                .HasForeignKey(bp => bp.BillId);
            modelBuilder.Entity<BillProduct>()
                .HasOne(bp => bp.Product)
                .WithMany(p => p.BillProducts)
                .HasForeignKey(bp => bp.ProductId);
            

            modelBuilder.Entity<Register>().HasData(
                new Register() { Id = 1 },
                new Register() { Id = 2 },
                new Register() { Id = 3 },
                new Register() { Id = 4 },
                new Register() { Id = 5 },
                new Register() { Id = 6 },
                new Register() { Id = 7 },
                new Register() { Id = 8 }
            );

            modelBuilder.Entity<Cashier>().HasData(
                new  { Id = 1, Name = "Mate Matic" },
                new  { Id = 2, Name = "Jure Juric" },
                new  { Id = 3, Name = "Stipe Stipic" },
                new  { Id = 4, Name = "Tomo Tomic" },
                new  { Id = 5, Name = "Ana Anic" },
                new  { Id = 6, Name = "Mila Milic" },
                new  { Id = 7, Name = "Iva Ivic" },
                new  { Id = 9, Name = "Teta Tetic" }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product()
                { Id = 1, Name = "Banana", Barcode = "1111111111111", Price = 3, Tax = 25, Amount = 100 },
                new Product()
                { Id = 2, Name = "Orange", Barcode = "1111111111112", Price = 4, Tax = 5, Amount = 100 },
                new Product()
                { Id = 3, Name = "Lemon", Barcode = "1111111111113", Price = 3, Tax = 20, Amount = 100 },
                new Product()
                { Id = 4, Name = "Apple", Barcode = "1111111111114", Price = 2, Tax = 25, Amount = 100 },
                new Product()
                { Id = 5, Name = "Cherry", Barcode = "1111111111115", Price = 5, Tax = 25, Amount = 100 },
                new Product()
                { Id = 6, Name = "Chewing gum", Barcode = "1111111111116", Price = 7, Tax = 25, Amount = 100 },
                new Product()
                { Id = 7, Name = "Apple juice", Barcode = "1111111111117", Price = 12, Tax = 25, Amount = 100 },
                new Product()
                { Id = 8, Name = "Apple cider", Barcode = "1111111111118", Price = 15, Tax = 5, Amount = 100 },
                new Product()
                { Id = 9, Name = "Apple pie", Barcode = "1111111111119", Price = 27, Tax = 25, Amount = 100 },
                new Product()
                { Id = 10, Name = "Watermelon", Barcode = "1111111111120", Price = 21, Tax = 25, Amount = 100 },
                new Product()
                { Id = 11, Name = "Sprite", Barcode = "1111111111121", Price = 10, Tax = 25, Amount = 100 },
                new Product()
                { Id = 12, Name = "Fanta", Barcode = "1111111111122", Price = 10, Tax = 25, Amount = 100 },
                new Product()
                { Id = 13, Name = "Coca Cola", Barcode = "1111111111123", Price = 10, Tax = 25, Amount = 100 },
                new Product()
                { Id = 14, Name = "Orangina", Barcode = "1111111111124", Price = 15, Tax = 25, Amount = 100 },
                new Product()
                { Id = 15, Name = "Pepsi", Barcode = "1111111111125", Price = 10, Tax = 25, Amount = 100 },
                new Product()
                { Id = 16, Name = "Wine", Barcode = "1111111111126", Price = 137, Tax = 5, Amount = 100 },
                new Product()
                { Id = 17, Name = "Chips", Barcode = "1111111111127", Price = 15, Tax = 25, Amount = 100 },
                new Product()
                { Id = 18, Name = "Cigarettes", Barcode = "1111111111128", Price = 24, Tax = 5, Amount = 100 },
                new Product()
                { Id = 19, Name = "Coffe", Barcode = "1111111111129", Price = 34, Tax = 20, Amount = 100 },
                new Product()
                { Id = 20, Name = "Batteries", Barcode = "1111111111130", Price = 42, Tax = 5, Amount = 100 }
            );

            modelBuilder.Entity<BillProduct>().HasData(
                new BillProduct()
                { BillId = 1, ProductId = 1, AmountBought = 1, PriceAtPurchase = 1, TaxAtPurchase = 1 },
                new BillProduct()
                { BillId = 2, ProductId = 1, AmountBought = 1, PriceAtPurchase = 1, TaxAtPurchase = 1 },
                new BillProduct()
                { BillId = 3, ProductId = 1, AmountBought = 1, PriceAtPurchase = 1, TaxAtPurchase = 1 },
                new BillProduct()
                { BillId = 4, ProductId = 1, AmountBought = 1, PriceAtPurchase = 1, TaxAtPurchase = 1 },
                new BillProduct()
                { BillId = 5, ProductId = 1, AmountBought = 1, PriceAtPurchase = 1, TaxAtPurchase = 1 },
                new BillProduct()
                { BillId = 6, ProductId = 1, AmountBought = 1, PriceAtPurchase = 1, TaxAtPurchase = 1 },
                new BillProduct()
                { BillId = 7, ProductId = 1, AmountBought = 1, PriceAtPurchase = 1, TaxAtPurchase = 1 },
                new BillProduct()
                { BillId = 8, ProductId = 1, AmountBought = 1, PriceAtPurchase = 1, TaxAtPurchase = 1 },
                new BillProduct()
                { BillId = 9, ProductId = 1, AmountBought = 1, PriceAtPurchase = 1, TaxAtPurchase = 1 },
                new BillProduct()
                { BillId = 10, ProductId = 1, AmountBought = 1, PriceAtPurchase = 1, TaxAtPurchase = 1 },
                new BillProduct()
                { BillId = 11, ProductId = 1, AmountBought = 1, PriceAtPurchase = 1, TaxAtPurchase = 1 },
                new BillProduct()
                { BillId = 12, ProductId = 1, AmountBought = 1, PriceAtPurchase = 1, TaxAtPurchase = 1 },
                new BillProduct()
                { BillId = 13, ProductId = 1, AmountBought = 1, PriceAtPurchase = 1, TaxAtPurchase = 1 },
                new BillProduct()
                { BillId = 14, ProductId = 1, AmountBought = 1, PriceAtPurchase = 1, TaxAtPurchase = 1 },
                new BillProduct()
                { BillId = 15, ProductId = 1, AmountBought = 1, PriceAtPurchase = 1, TaxAtPurchase = 1 },
                new BillProduct()
                { BillId = 16, ProductId = 1, AmountBought = 1, PriceAtPurchase = 1, TaxAtPurchase = 1 },
                new BillProduct()
                { BillId = 17, ProductId = 1, AmountBought = 1, PriceAtPurchase = 1, TaxAtPurchase = 1 },
                new BillProduct()
                { BillId = 18, ProductId = 1, AmountBought = 1, PriceAtPurchase = 1, TaxAtPurchase = 1 },
                new BillProduct()
                { BillId = 19, ProductId = 1, AmountBought = 1, PriceAtPurchase = 1, TaxAtPurchase = 1 },
                new BillProduct()
                { BillId = 20, ProductId = 1, AmountBought = 1, PriceAtPurchase = 1, TaxAtPurchase = 1 },
                new BillProduct()
                { BillId = 21, ProductId = 1, AmountBought = 1, PriceAtPurchase = 1, TaxAtPurchase = 1 },
                new BillProduct()
                { BillId = 22, ProductId = 1, AmountBought = 1, PriceAtPurchase = 1, TaxAtPurchase = 1 },
                new BillProduct()
                { BillId = 23, ProductId = 1, AmountBought = 1, PriceAtPurchase = 1, TaxAtPurchase = 1 },
                new BillProduct()
                { BillId = 24, ProductId = 1, AmountBought = 1, PriceAtPurchase = 1, TaxAtPurchase = 1 },
                new BillProduct()
                { BillId = 25, ProductId = 1, AmountBought = 1, PriceAtPurchase = 1, TaxAtPurchase = 1 },
                new BillProduct()
                { BillId = 26, ProductId = 1, AmountBought = 1, PriceAtPurchase = 1, TaxAtPurchase = 1 },
                new BillProduct()
                { BillId = 27, ProductId = 1, AmountBought = 1, PriceAtPurchase = 1, TaxAtPurchase = 1 },
                new BillProduct()
                { BillId = 28, ProductId = 1, AmountBought = 1, PriceAtPurchase = 1, TaxAtPurchase = 1 },
                new BillProduct()
                { BillId = 29, ProductId = 1, AmountBought = 1, PriceAtPurchase = 1, TaxAtPurchase = 1 },
                new BillProduct()
                { BillId = 30, ProductId = 1, AmountBought = 1, PriceAtPurchase = 1, TaxAtPurchase = 1 },
                new BillProduct()
                { BillId = 31, ProductId = 1, AmountBought = 1, PriceAtPurchase = 1, TaxAtPurchase = 1 },
                new BillProduct()
                { BillId = 32, ProductId = 1, AmountBought = 1, PriceAtPurchase = 1, TaxAtPurchase = 1 },
                new BillProduct()
                { BillId = 33, ProductId = 1, AmountBought = 1, PriceAtPurchase = 1, TaxAtPurchase = 1 },
                new BillProduct()
                { BillId = 34, ProductId = 1, AmountBought = 1, PriceAtPurchase = 1, TaxAtPurchase = 1 },
                new BillProduct()
                { BillId = 35, ProductId = 1, AmountBought = 1, PriceAtPurchase = 1, TaxAtPurchase = 1 },
                new BillProduct()
                { BillId = 36, ProductId = 1, AmountBought = 1, PriceAtPurchase = 1, TaxAtPurchase = 1 },
                new BillProduct()
                { BillId = 37, ProductId = 1, AmountBought = 1, PriceAtPurchase = 1, TaxAtPurchase = 1 },
                new BillProduct()
                { BillId = 38, ProductId = 1, AmountBought = 1, PriceAtPurchase = 1, TaxAtPurchase = 1 },
                new BillProduct()
                { BillId = 39, ProductId = 1, AmountBought = 1, PriceAtPurchase = 1, TaxAtPurchase = 1 },
                new BillProduct()
                { BillId = 40, ProductId = 1, AmountBought = 1, PriceAtPurchase = 1, TaxAtPurchase = 1 },
                new BillProduct()
                { BillId = 41, ProductId = 1, AmountBought = 1, PriceAtPurchase = 1, TaxAtPurchase = 1 },
                new BillProduct()
                { BillId = 42, ProductId = 1, AmountBought = 1, PriceAtPurchase = 1, TaxAtPurchase = 1 },
                new BillProduct()
                { BillId = 43, ProductId = 1, AmountBought = 1, PriceAtPurchase = 1, TaxAtPurchase = 1 },
                new BillProduct()
                { BillId = 44, ProductId = 1, AmountBought = 1, PriceAtPurchase = 1, TaxAtPurchase = 1 },
                new BillProduct()
                { BillId = 45, ProductId = 1, AmountBought = 1, PriceAtPurchase = 1, TaxAtPurchase = 1 },
                new BillProduct()
                { BillId = 46, ProductId = 1, AmountBought = 1, PriceAtPurchase = 1, TaxAtPurchase = 1 },
                new BillProduct()
                { BillId = 47, ProductId = 1, AmountBought = 1, PriceAtPurchase = 1, TaxAtPurchase = 1 },
                new BillProduct()
                { BillId = 48, ProductId = 1, AmountBought = 1, PriceAtPurchase = 1, TaxAtPurchase = 1 },
                new BillProduct()
                { BillId = 49, ProductId = 1, AmountBought = 1, PriceAtPurchase = 1, TaxAtPurchase = 1 }
            );

            modelBuilder.Entity<CashierRegister>().HasData(
                new CashierRegister() {CashierId = 1, RegisterId = 1}
            );

            modelBuilder.Entity<Bill>().HasData(
                new
                {
                    Id = 1,
                    Guid = Guid.NewGuid(),
                    IssueDate = new DateTime(2012, 12, 25),
                    TotalPriceWithoutTax = 20.0,
                    ExciseDutyAmount = 1.0,
                    ValueAddedTaxAmount = 1.0,
                    CustomTaxAmount = 1.0,
                    TotalPriceWithTax = 1.0,
                    CashierRegisterId = new {CashierId = 1, RegisterId = 1}
                },
                new
                {
                    Id = 2,
                    Guid = Guid.NewGuid(),
                    IssueDate = new DateTime(2012, 12, 25),
                    TotalPriceWithoutTax = 20.0,
                    ExciseDutyAmount = 1.0,
                    ValueAddedTaxAmount = 1.0,
                    CustomTaxAmount = 1.0,
                    TotalPriceWithTax = 1.0,
                    CashierRegisterId = new {CashierId = 1, RegisterId = 1}
                },
                new
                {
                    Id = 3,
                    Guid = Guid.NewGuid(),
                    IssueDate = new DateTime(2012, 12, 25),
                    TotalPriceWithoutTax = 20.0,
                    ExciseDutyAmount = 1.0,
                    ValueAddedTaxAmount = 1.0,
                    CustomTaxAmount = 1.0,
                    TotalPriceWithTax = 1.0,
                    CashierRegisterId = new {CashierId = 1, RegisterId = 1}
                },
                new
                {
                    Id = 4,
                    Guid = Guid.NewGuid(),
                    IssueDate = new DateTime(2012, 12, 25),
                    TotalPriceWithoutTax = 20.0,
                    ExciseDutyAmount = 1.0,
                    ValueAddedTaxAmount = 1.0,
                    CustomTaxAmount = 1.0,
                    TotalPriceWithTax = 1.0,
                    CashierRegisterId = new {CashierId = 1, RegisterId = 1}
                },
                new
                {
                    Id = 5,
                    Guid = Guid.NewGuid(),
                    IssueDate = new DateTime(2012, 12, 25),
                    TotalPriceWithoutTax = 20.0,
                    ExciseDutyAmount = 1.0,
                    ValueAddedTaxAmount = 1.0,
                    CustomTaxAmount = 1.0,
                    TotalPriceWithTax = 1.0,
                    CashierRegisterId = new {CashierId = 1, RegisterId = 1}
                },
                new
                {
                    Id = 6,
                    Guid = Guid.NewGuid(),
                    IssueDate = new DateTime(2012, 12, 25),
                    TotalPriceWithoutTax = 20.0,
                    ExciseDutyAmount = 1.0,
                    ValueAddedTaxAmount = 1.0,
                    CustomTaxAmount = 1.0,
                    TotalPriceWithTax = 1.0,
                    CashierRegisterId = new {CashierId = 1, RegisterId = 1}
                },
                new
                {
                    Id = 7,
                    Guid = Guid.NewGuid(),
                    IssueDate = new DateTime(2012, 12, 25),
                    TotalPriceWithoutTax = 20.0,
                    ExciseDutyAmount = 1.0,
                    ValueAddedTaxAmount = 1.0,
                    CustomTaxAmount = 1.0,
                    TotalPriceWithTax = 1.0,
                    CashierRegisterId = new {CashierId = 1, RegisterId = 1}
                },
                new
                {
                    Id = 8,
                    Guid = Guid.NewGuid(),
                    IssueDate = new DateTime(2012, 12, 25),
                    TotalPriceWithoutTax = 20.0,
                    ExciseDutyAmount = 1.0,
                    ValueAddedTaxAmount = 1.0,
                    CustomTaxAmount = 1.0,
                    TotalPriceWithTax = 1.0,
                    CashierRegisterId = new {CashierId = 1, RegisterId = 1}
                },
                new
                {
                    Id = 9,
                    Guid = Guid.NewGuid(),
                    IssueDate = new DateTime(2012, 12, 25),
                    TotalPriceWithoutTax = 20.0,
                    ExciseDutyAmount = 1.0,
                    ValueAddedTaxAmount = 1.0,
                    CustomTaxAmount = 1.0,
                    TotalPriceWithTax = 1.0,
                    CashierRegisterId = new {CashierId = 1, RegisterId = 1}
                },
                new
                {
                    Id = 10,
                    Guid = Guid.NewGuid(),
                    IssueDate = new DateTime(2012, 12, 25),
                    TotalPriceWithoutTax = 20.0,
                    ExciseDutyAmount = 1.0,
                    ValueAddedTaxAmount = 1.0,
                    CustomTaxAmount = 1.0,
                    TotalPriceWithTax = 1.0,
                    CashierRegisterId = new {CashierId = 1, RegisterId = 1}
                },
                new
                {
                    Id = 11,
                    Guid = Guid.NewGuid(),
                    IssueDate = new DateTime(2012, 12, 25),
                    TotalPriceWithoutTax = 20.0,
                    ExciseDutyAmount = 1.0,
                    ValueAddedTaxAmount = 1.0,
                    CustomTaxAmount = 1.0,
                    TotalPriceWithTax = 1.0,
                    CashierRegisterId = new {CashierId = 1, RegisterId = 1}
                },
                new
                {
                    Id = 12,
                    Guid = Guid.NewGuid(),
                    IssueDate = new DateTime(2012, 12, 25),
                    TotalPriceWithoutTax = 20.0,
                    ExciseDutyAmount = 1.0,
                    ValueAddedTaxAmount = 1.0,
                    CustomTaxAmount = 1.0,
                    TotalPriceWithTax = 1.0,
                    CashierRegisterId = new {CashierId = 1, RegisterId = 1}
                },
                new
                {
                    Id = 13,
                    Guid = Guid.NewGuid(),
                    IssueDate = new DateTime(2012, 12, 25),
                    TotalPriceWithoutTax = 20.0,
                    ExciseDutyAmount = 1.0,
                    ValueAddedTaxAmount = 1.0,
                    CustomTaxAmount = 1.0,
                    TotalPriceWithTax = 1.0,
                    CashierRegisterId = new {CashierId = 1, RegisterId = 1}
                },
                new
                {
                    Id = 14,
                    Guid = Guid.NewGuid(),
                    IssueDate = new DateTime(2012, 12, 25),
                    TotalPriceWithoutTax = 20.0,
                    ExciseDutyAmount = 1.0,
                    ValueAddedTaxAmount = 1.0,
                    CustomTaxAmount = 1.0,
                    TotalPriceWithTax = 1.0,
                    CashierRegisterId = new {CashierId = 1, RegisterId = 1}
                },
                new
                {
                    Id = 15,
                    Guid = Guid.NewGuid(),
                    IssueDate = new DateTime(2012, 12, 25),
                    TotalPriceWithoutTax = 20.0,
                    ExciseDutyAmount = 1.0,
                    ValueAddedTaxAmount = 1.0,
                    CustomTaxAmount = 1.0,
                    TotalPriceWithTax = 1.0,
                    CashierRegisterId = new {CashierId = 1, RegisterId = 1}
                },
                new
                {
                    Id = 16,
                    Guid = Guid.NewGuid(),
                    IssueDate = new DateTime(2012, 12, 25),
                    TotalPriceWithoutTax = 20.0,
                    ExciseDutyAmount = 1.0,
                    ValueAddedTaxAmount = 1.0,
                    CustomTaxAmount = 1.0,
                    TotalPriceWithTax = 1.0,
                    CashierRegisterId = new {CashierId = 1, RegisterId = 1}
                },
                new
                {
                    Id = 17,
                    Guid = Guid.NewGuid(),
                    IssueDate = new DateTime(2012, 12, 25),
                    TotalPriceWithoutTax = 20.0,
                    ExciseDutyAmount = 1.0,
                    ValueAddedTaxAmount = 1.0,
                    CustomTaxAmount = 1.0,
                    TotalPriceWithTax = 1.0,
                    CashierRegisterId = new {CashierId = 1, RegisterId = 1}
                },
                new
                {
                    Id = 18,
                    Guid = Guid.NewGuid(),
                    IssueDate = new DateTime(2012, 12, 25),
                    TotalPriceWithoutTax = 20.0,
                    ExciseDutyAmount = 1.0,
                    ValueAddedTaxAmount = 1.0,
                    CustomTaxAmount = 1.0,
                    TotalPriceWithTax = 1.0,
                    CashierRegisterId = new {CashierId = 1, RegisterId = 1}
                },
                new
                {
                    Id = 19,
                    Guid = Guid.NewGuid(),
                    IssueDate = new DateTime(2012, 12, 25),
                    TotalPriceWithoutTax = 20.0,
                    ExciseDutyAmount = 1.0,
                    ValueAddedTaxAmount = 1.0,
                    CustomTaxAmount = 1.0,
                    TotalPriceWithTax = 1.0,
                    CashierRegisterId = new {CashierId = 1, RegisterId = 1}
                },
                new
                {
                    Id = 20,
                    Guid = Guid.NewGuid(),
                    IssueDate = new DateTime(2012, 12, 25),
                    TotalPriceWithoutTax = 20.0,
                    ExciseDutyAmount = 1.0,
                    ValueAddedTaxAmount = 1.0,
                    CustomTaxAmount = 1.0,
                    TotalPriceWithTax = 1.0,
                    CashierRegisterId = new {CashierId = 1, RegisterId = 1}
                },
                new
                {
                    Id = 21,
                    Guid = Guid.NewGuid(),
                    IssueDate = new DateTime(2012, 12, 25),
                    TotalPriceWithoutTax = 20.0,
                    ExciseDutyAmount = 1.0,
                    ValueAddedTaxAmount = 1.0,
                    CustomTaxAmount = 1.0,
                    TotalPriceWithTax = 1.0,
                    CashierRegisterId = new {CashierId = 1, RegisterId = 1}
                },
                new
                {
                    Id = 22,
                    Guid = Guid.NewGuid(),
                    IssueDate = new DateTime(2012, 12, 25),
                    TotalPriceWithoutTax = 20.0,
                    ExciseDutyAmount = 1.0,
                    ValueAddedTaxAmount = 1.0,
                    CustomTaxAmount = 1.0,
                    TotalPriceWithTax = 1.0,
                    CashierRegisterId = new {CashierId = 1, RegisterId = 1}
                },
                new
                {
                    Id = 23,
                    Guid = Guid.NewGuid(),
                    IssueDate = new DateTime(2012, 12, 25),
                    TotalPriceWithoutTax = 20.0,
                    ExciseDutyAmount = 1.0,
                    ValueAddedTaxAmount = 1.0,
                    CustomTaxAmount = 1.0,
                    TotalPriceWithTax = 1.0,
                    CashierRegisterId = new {CashierId = 1, RegisterId = 1}
                },
                new
                {
                    Id = 24,
                    Guid = Guid.NewGuid(),
                    IssueDate = new DateTime(2012, 12, 25),
                    TotalPriceWithoutTax = 20.0,
                    ExciseDutyAmount = 1.0,
                    ValueAddedTaxAmount = 1.0,
                    CustomTaxAmount = 1.0,
                    TotalPriceWithTax = 1.0,
                    CashierRegisterId = new {CashierId = 1, RegisterId = 1}
                },
                new
                {
                    Id = 25,
                    Guid = Guid.NewGuid(),
                    IssueDate = new DateTime(2012, 12, 25),
                    TotalPriceWithoutTax = 20.0,
                    ExciseDutyAmount = 1.0,
                    ValueAddedTaxAmount = 1.0,
                    CustomTaxAmount = 1.0,
                    TotalPriceWithTax = 1.0,
                    CashierRegisterId = new {CashierId = 1, RegisterId = 1}
                },
                new
                {
                    Id = 26,
                    Guid = Guid.NewGuid(),
                    IssueDate = new DateTime(2012, 12, 25),
                    TotalPriceWithoutTax = 20.0,
                    ExciseDutyAmount = 1.0,
                    ValueAddedTaxAmount = 1.0,
                    CustomTaxAmount = 1.0,
                    TotalPriceWithTax = 1.0,
                    CashierRegisterId = new {CashierId = 1, RegisterId = 1}
                },
                new
                {
                    Id = 27,
                    Guid = Guid.NewGuid(),
                    IssueDate = new DateTime(2012, 12, 25),
                    TotalPriceWithoutTax = 20.0,
                    ExciseDutyAmount = 1.0,
                    ValueAddedTaxAmount = 1.0,
                    CustomTaxAmount = 1.0,
                    TotalPriceWithTax = 1.0,
                    CashierRegisterId = new {CashierId = 1, RegisterId = 1}
                },
                new
                {
                    Id = 28,
                    Guid = Guid.NewGuid(),
                    IssueDate = new DateTime(2012, 12, 25),
                    TotalPriceWithoutTax = 20.0,
                    ExciseDutyAmount = 1.0,
                    ValueAddedTaxAmount = 1.0,
                    CustomTaxAmount = 1.0,
                    TotalPriceWithTax = 1.0,
                    CashierRegisterId = new {CashierId = 1, RegisterId = 1}
                },
                new
                {
                    Id = 29,
                    Guid = Guid.NewGuid(),
                    IssueDate = new DateTime(2012, 12, 25),
                    TotalPriceWithoutTax = 20.0,
                    ExciseDutyAmount = 1.0,
                    ValueAddedTaxAmount = 1.0,
                    CustomTaxAmount = 1.0,
                    TotalPriceWithTax = 1.0,
                    CashierRegisterId = new {CashierId = 1, RegisterId = 1}
                },
                new
                {
                    Id = 30,
                    Guid = Guid.NewGuid(),
                    IssueDate = new DateTime(2012, 12, 25),
                    TotalPriceWithoutTax = 20.0,
                    ExciseDutyAmount = 1.0,
                    ValueAddedTaxAmount = 1.0,
                    CustomTaxAmount = 1.0,
                    TotalPriceWithTax = 1.0,
                    CashierRegisterId = new {CashierId = 1, RegisterId = 1}
                },
                new
                {
                    Id = 31,
                    Guid = Guid.NewGuid(),
                    IssueDate = new DateTime(2012, 12, 25),
                    TotalPriceWithoutTax = 20.0,
                    ExciseDutyAmount = 1.0,
                    ValueAddedTaxAmount = 1.0,
                    CustomTaxAmount = 1.0,
                    TotalPriceWithTax = 1.0,
                    CashierRegisterId = new {CashierId = 1, RegisterId = 1}
                },
                new
                {
                    Id = 32,
                    Guid = Guid.NewGuid(),
                    IssueDate = new DateTime(2012, 12, 25),
                    TotalPriceWithoutTax = 20.0,
                    ExciseDutyAmount = 1.0,
                    ValueAddedTaxAmount = 1.0,
                    CustomTaxAmount = 1.0,
                    TotalPriceWithTax = 1.0,
                    CashierRegisterId = new {CashierId = 1, RegisterId = 1}
                },
                new
                {
                    Id = 33,
                    Guid = Guid.NewGuid(),
                    IssueDate = new DateTime(2012, 12, 25),
                    TotalPriceWithoutTax = 20.0,
                    ExciseDutyAmount = 1.0,
                    ValueAddedTaxAmount = 1.0,
                    CustomTaxAmount = 1.0,
                    TotalPriceWithTax = 1.0,
                    CashierRegisterId = new {CashierId = 1, RegisterId = 1}
                },
                new
                {
                    Id = 34,
                    Guid = Guid.NewGuid(),
                    IssueDate = new DateTime(2012, 12, 25),
                    TotalPriceWithoutTax = 20.0,
                    ExciseDutyAmount = 1.0,
                    ValueAddedTaxAmount = 1.0,
                    CustomTaxAmount = 1.0,
                    TotalPriceWithTax = 1.0,
                    CashierRegisterId = new {CashierId = 1, RegisterId = 1}
                },
                new
                {
                    Id = 35,
                    Guid = Guid.NewGuid(),
                    IssueDate = new DateTime(2012, 12, 25),
                    TotalPriceWithoutTax = 20.0,
                    ExciseDutyAmount = 1.0,
                    ValueAddedTaxAmount = 1.0,
                    CustomTaxAmount = 1.0,
                    TotalPriceWithTax = 1.0,
                    CashierRegisterId = new {CashierId = 1, RegisterId = 1}
                },
                new
                {
                    Id = 36,
                    Guid = Guid.NewGuid(),
                    IssueDate = new DateTime(2012, 12, 25),
                    TotalPriceWithoutTax = 20.0,
                    ExciseDutyAmount = 1.0,
                    ValueAddedTaxAmount = 1.0,
                    CustomTaxAmount = 1.0,
                    TotalPriceWithTax = 1.0,
                    CashierRegisterId = new {CashierId = 1, RegisterId = 1}
                },
                new
                {
                    Id = 37,
                    Guid = Guid.NewGuid(),
                    IssueDate = new DateTime(2012, 12, 25),
                    TotalPriceWithoutTax = 20.0,
                    ExciseDutyAmount = 1.0,
                    ValueAddedTaxAmount = 1.0,
                    CustomTaxAmount = 1.0,
                    TotalPriceWithTax = 1.0,
                    CashierRegisterId = new {CashierId = 1, RegisterId = 1}
                },
                new
                {
                    Id = 38,
                    Guid = Guid.NewGuid(),
                    IssueDate = new DateTime(2012, 12, 25),
                    TotalPriceWithoutTax = 20.0,
                    ExciseDutyAmount = 1.0,
                    ValueAddedTaxAmount = 1.0,
                    CustomTaxAmount = 1.0,
                    TotalPriceWithTax = 1.0,
                    CashierRegisterId = new {CashierId = 1, RegisterId = 1}
                },
                new
                {
                    Id = 39,
                    Guid = Guid.NewGuid(),
                    IssueDate = new DateTime(2012, 12, 25),
                    TotalPriceWithoutTax = 20.0,
                    ExciseDutyAmount = 1.0,
                    ValueAddedTaxAmount = 1.0,
                    CustomTaxAmount = 1.0,
                    TotalPriceWithTax = 1.0,
                    CashierRegisterId = new {CashierId = 1, RegisterId = 1}
                },
                new
                {
                    Id = 40,
                    Guid = Guid.NewGuid(),
                    IssueDate = new DateTime(2012, 12, 25),
                    TotalPriceWithoutTax = 20.0,
                    ExciseDutyAmount = 1.0,
                    ValueAddedTaxAmount = 1.0,
                    CustomTaxAmount = 1.0,
                    TotalPriceWithTax = 1.0,
                    CashierRegisterId = new {CashierId = 1, RegisterId = 1}
                },
                new
                {
                    Id = 41,
                    Guid = Guid.NewGuid(),
                    IssueDate = new DateTime(2012, 12, 25),
                    TotalPriceWithoutTax = 20.0,
                    ExciseDutyAmount = 1.0,
                    ValueAddedTaxAmount = 1.0,
                    CustomTaxAmount = 1.0,
                    TotalPriceWithTax = 1.0,
                    CashierRegisterId = new {CashierId = 1, RegisterId = 1}
                },
                new
                {
                    Id = 42,
                    Guid = Guid.NewGuid(),
                    IssueDate = new DateTime(2012, 12, 25),
                    TotalPriceWithoutTax = 20.0,
                    ExciseDutyAmount = 1.0,
                    ValueAddedTaxAmount = 1.0,
                    CustomTaxAmount = 1.0,
                    TotalPriceWithTax = 1.0,
                    CashierRegisterId = new {CashierId = 1, RegisterId = 1}
                },
                new
                {
                    Id = 43,
                    Guid = Guid.NewGuid(),
                    IssueDate = new DateTime(2012, 12, 25),
                    TotalPriceWithoutTax = 20.0,
                    ExciseDutyAmount = 1.0,
                    ValueAddedTaxAmount = 1.0,
                    CustomTaxAmount = 1.0,
                    TotalPriceWithTax = 1.0,
                    CashierRegisterId = new {CashierId = 1, RegisterId = 1}
                },
                new
                {
                    Id = 44,
                    Guid = Guid.NewGuid(),
                    IssueDate = new DateTime(2012, 12, 25),
                    TotalPriceWithoutTax = 20.0,
                    ExciseDutyAmount = 1.0,
                    ValueAddedTaxAmount = 1.0,
                    CustomTaxAmount = 1.0,
                    TotalPriceWithTax = 1.0,
                    CashierRegisterId = new {CashierId = 1, RegisterId = 1}
                },
                new
                {
                    Id = 45,
                    Guid = Guid.NewGuid(),
                    IssueDate = new DateTime(2012, 12, 25),
                    TotalPriceWithoutTax = 20.0,
                    ExciseDutyAmount = 1.0,
                    ValueAddedTaxAmount = 1.0,
                    CustomTaxAmount = 1.0,
                    TotalPriceWithTax = 1.0,
                    CashierRegisterId = new {CashierId = 1, RegisterId = 1}
                },
                new
                {
                    Id = 46,
                    Guid = Guid.NewGuid(),
                    IssueDate = new DateTime(2012, 12, 25),
                    TotalPriceWithoutTax = 20.0,
                    ExciseDutyAmount = 1.0,
                    ValueAddedTaxAmount = 1.0,
                    CustomTaxAmount = 1.0,
                    TotalPriceWithTax = 1.0,
                    CashierRegisterId = new {CashierId = 1, RegisterId = 1}
                },
                new
                {
                    Id = 47,
                    Guid = Guid.NewGuid(),
                    IssueDate = new DateTime(2012, 12, 25),
                    TotalPriceWithoutTax = 20.0,
                    ExciseDutyAmount = 1.0,
                    ValueAddedTaxAmount = 1.0,
                    CustomTaxAmount = 1.0,
                    TotalPriceWithTax = 1.0,
                    CashierRegisterId = new {CashierId = 1, RegisterId = 1}
                },
                new
                {
                    Id = 48,
                    Guid = Guid.NewGuid(),
                    IssueDate = new DateTime(2012, 12, 25),
                    TotalPriceWithoutTax = 20.0,
                    ExciseDutyAmount = 1.0,
                    ValueAddedTaxAmount = 1.0,
                    CustomTaxAmount = 1.0,
                    TotalPriceWithTax = 1.0,
                    CashierRegisterId = new {CashierId = 1, RegisterId = 1}
                },
                new
                {
                    Id = 49,
                    Guid = Guid.NewGuid(),
                    IssueDate = new DateTime(2012, 12, 25),
                    TotalPriceWithoutTax = 20.0,
                    ExciseDutyAmount = 1.0,
                    ValueAddedTaxAmount = 1.0,
                    CustomTaxAmount = 1.0,
                    TotalPriceWithTax = 1.0,
                    CashierRegisterId = new {CashierId = 1, RegisterId = 1}
                }
            );
        }
    }
}

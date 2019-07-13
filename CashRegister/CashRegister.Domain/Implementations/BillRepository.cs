using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CashRegister.Data.Entities;
using CashRegister.Data.Entities.Models;
using CashRegister.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CashRegister.Domain.Implementations
{
    public class BillRepository : IBillRepository
    {
        private readonly CashRegisterContext _context;

        public BillRepository(CashRegisterContext context)
        {
            _context = context;
        }

        public List<Bill> GetTenBills(int startPosition)
        {
            return _context.Bills.Include("CashierRegister").Include("CashierRegister.Cashier").Include("BillProducts")
                .Include("BillProducts.Product")
                .OrderByDescending(bill => bill.IssueDate).Skip(startPosition).Take(10).ToList();
        }

        public List<Bill> GetSearchedBills(string dateInput)
        {
            return _context.Bills.Include("CashierRegister").Include("CashierRegister.Cashier").Include("BillProducts")
                .Include("BillProducts.Product")
                .Where(bill => bill.IssueDate.ToString("O").Contains(dateInput)).ToList();
        }

        public Bill GetLastCreatedBill()
        {
            return _context.Bills.Include("CashierRegister").Include("CashierRegister.Cashier").Include("BillProducts")
                .Include("BillProducts.Product")
                .OrderByDescending(bill => bill.IssueDate).First();
        }

        public bool AddBill(Bill billToAdd, List<BillProduct> productsToAddToBill)
        {
            billToAdd.Guid = Guid.NewGuid();
            billToAdd.IssueDate = DateTime.Now;
            billToAdd.BillProducts = new List<BillProduct>();
            var doesGuidExist = _context.Bills.Any(bill => bill.Guid.Equals(billToAdd.Guid));

            if (doesGuidExist)
                return false;

            var doesBillExist = _context.Bills.Any(bill => bill.Id.Equals(billToAdd.Id));

            if (doesBillExist)
                return false;

            var billProductRepository = new BillProductRepository(_context);
            var productRepository = new ProductRepository(_context);

            var cashierRegisterToAdd = _context.CashierRegisters.Where(cashierRegister =>
                cashierRegister.RegisterId.Equals(billToAdd.CashierRegister.RegisterId) &&
                cashierRegister.CashierId.Equals(billToAdd.CashierRegister.CashierId)).ToList();

            billToAdd.CashierRegister = cashierRegisterToAdd[0];

            _context.Bills.Add(billToAdd);


            foreach (var productToAdd in productsToAddToBill)
            {
                var newAmount = productToAdd.Product.Amount;

                productToAdd.Bill = billToAdd;
                productToAdd.Product = _context.Products.Find(productToAdd.ProductId);
                var wasAddSuccessful = billProductRepository.AddBillProduct(productToAdd);
                if (!wasAddSuccessful)
                    return false;

                var wasEditAmountSuccessful = productRepository.EditProductAmount(productToAdd.ProductId, newAmount);
                if (!wasEditAmountSuccessful)
                    return false;
            }


            return true;
        }
    }
}

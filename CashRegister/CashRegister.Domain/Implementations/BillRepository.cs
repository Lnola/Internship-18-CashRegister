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
            return _context.Bills.OrderByDescending(bill => bill.IssueDate).Skip(startPosition).Take(10).ToList();
        }

        public List<Bill> GetSearchedBills(string dateInput)
        {
            return _context.Bills.Where(bill => bill.IssueDate.ToString("O").Contains(dateInput)).ToList();
        }

        public bool AddBill(Bill billToAdd, List<BillProduct> productsToAddToBill)
        {
            billToAdd.Guid = Guid.NewGuid();
            billToAdd.IssueDate = DateTime.Now;
            var doesGuidExist = _context.Bills.Any(bill => bill.Guid.Equals(billToAdd.Guid));

            if (doesGuidExist)
                return false;

            var doesBillExist = _context.Bills.Any(bill => bill.Id.Equals(billToAdd.Id));

            if (doesBillExist)
                return false;

            var billProductRepository = new BillProductRepository(_context);
            var productRepository = new ProductRepository(_context);

            foreach (var productToAdd in productsToAddToBill)
            {
                var wasEditAmountSuccessful = productRepository.EditProductAmount(productToAdd.ProductId, productToAdd.Product.Amount);
                if (!wasEditAmountSuccessful)
                    return false;
            }

            _context.Bills.Add(billToAdd);
            _context.Entry<Bill>(billToAdd).State = EntityState.Detached;
            _context.SaveChanges();

            foreach (var productToAdd in productsToAddToBill)
            {
                var wasAddSuccessful = billProductRepository.AddBillProduct(productToAdd);
                if (!wasAddSuccessful)
                    return false;
            }

            return true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CashRegister.Data.Entities;
using CashRegister.Data.Entities.Models;
using CashRegister.Domain.Interfaces;

namespace CashRegister.Domain.Implementations
{
    public class BillProductRepository : IBillProductRepository
    {
        private readonly CashRegisterContext _context;

        public BillProductRepository(CashRegisterContext context)
        {
            _context = context;
        }


        public List<BillProduct> GetBillProductsByBillId(int id)
        {
            return _context.BillProducts.Where(billProduct => billProduct.BillId == id).ToList();
        }

        public bool AddBillProduct(BillProduct billProductToAdd)
        {
            var doesProductExist = _context.Products.Any(product => product.Id.Equals(billProductToAdd.ProductId));

            if (!doesProductExist)
                return false;

            _context.BillProducts.Add(billProductToAdd);
            //_context.SaveChanges();

            return true;
        }
    }
}

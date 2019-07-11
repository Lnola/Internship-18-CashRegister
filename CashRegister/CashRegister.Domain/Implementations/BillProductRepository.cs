using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CashRegister.Data.Entities;
using CashRegister.Data.Entities.Models;
using CashRegister.Domain.Interfaces;

namespace CashRegister.Domain.Implementations
{
    public class BillProductRepository:IBillProductRepository
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
            var doesBillExist = _context.Bills.Any(bill => bill.Id.Equals(billProductToAdd.Bill.Id));
            var doesProductExist = _context.Products.Any(product => product.Id.Equals(billProductToAdd.ProductId));

            if (!doesBillExist || !doesProductExist)
                return false;


            var newBillProduct = new BillProduct
            {
                Bill = billProductToAdd.Bill,
                Product = billProductToAdd.Product,
                //newBillProduct.BillId = billProductToAdd.BillId;
                //newBillProduct.ProductId = billProductToAdd.ProductId;
                PriceAtPurchase = billProductToAdd.PriceAtPurchase,
                TaxAtPurchase = billProductToAdd.TaxAtPurchase
            };


            _context.BillProducts.Add(newBillProduct);
            _context.SaveChanges();

            return true;
        }
    }
}

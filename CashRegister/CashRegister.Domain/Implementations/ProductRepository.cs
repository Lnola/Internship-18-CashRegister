using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using CashRegister.Data.Entities;
using CashRegister.Data.Entities.Models;
using CashRegister.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CashRegister.Domain.Implementations
{
    public class ProductRepository : IProductRepository
    {
        private readonly CashRegisterContext _context;

        public ProductRepository(CashRegisterContext context)
        {
            _context = context;
        }

        public List<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }

        public List<Product> GetProductsMatchingInput(string input)
        {
            return _context.Products.Where(product => product.Name.Contains(input)).ToList();
        }

        public bool AddProduct(Product productToAdd)
        {
            var doesProductExist = _context.Products.Any(product =>
                string.Equals(product.Name, productToAdd.Name, StringComparison.CurrentCultureIgnoreCase));

            if (doesProductExist || DoesBarcodeExist(productToAdd.Barcode))
                return false;

            _context.Products.Add(productToAdd);
            _context.SaveChanges();
            return true;
        }

        public bool EditProduct(Product editedProduct)
        {
            if (DoesBarcodeExist(editedProduct.Barcode))
                return false;

            var productToEdit = _context.Products.Find(editedProduct.Id);

            

            if (productToEdit == null)
                return false;

            var isProductUnchanged = string.Equals(editedProduct.Barcode, productToEdit.Barcode,
                                       StringComparison.CurrentCulture) &&
                                   Equals(editedProduct.Price, productToEdit.Price) &&
                                   Equals(editedProduct.Tax, productToEdit.Tax);

            if (isProductUnchanged || editedProduct.Barcode.Length < 13)
                return false;

            productToEdit.Price = editedProduct.Price;
            productToEdit.Tax = editedProduct.Tax;
            productToEdit.Barcode = editedProduct.Barcode;
            _context.SaveChanges();

            return true;
        }

        public bool EditProductAmount(int productId, int newAmount)
        {
            var productToEdit = _context.Products.Find(productId);

            if (productToEdit == null)
                return false;

            productToEdit.Amount = newAmount;
            _context.Entry<Product>(productToEdit).State = EntityState.Detached;
            _context.SaveChanges();

            return true;
        }

        public bool DeleteProduct(Product idOfProductToDelete)
        {
            var productToDelete = _context.Products.Find(idOfProductToDelete);

            if (productToDelete == null)
                return false;

            _context.Remove(productToDelete);
            _context.SaveChanges();

            return true;
        }

        private bool DoesBarcodeExist(string barcode)
        {
            var doesBarcodeExist = _context.Products.Any(product =>
                string.Equals(product.Barcode, barcode, StringComparison.CurrentCulture));

            return doesBarcodeExist;
        }
    }
}

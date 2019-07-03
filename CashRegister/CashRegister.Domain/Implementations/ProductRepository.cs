using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using CashRegister.Data.Entities;
using CashRegister.Data.Entities.Models;
using CashRegister.Domain.Interfaces;

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

        public bool AddProduct(Product productToAdd)
        {
            var doesProductExist = _context.Products.Any(product =>
                string.Equals(product.Name, productToAdd.Name, StringComparison.CurrentCultureIgnoreCase));

            if (doesProductExist)
                return false;

            _context.Products.Add(productToAdd);
            _context.SaveChanges();
            return true;
        }

        public bool EditProduct(Product editedProduct)
        {
            var didProductChange = !_context.Products.Any(product => product == editedProduct);

            if (!didProductChange)
                return false;

            var productToEdit = _context.Products.Find(editedProduct.Id);

            if (productToEdit == null)
                return false;

            productToEdit.Price = editedProduct.Price;
            productToEdit.Tax = editedProduct.Tax;
            productToEdit.Barcode = editedProduct.Barcode;
            productToEdit.Amount= editedProduct.Amount;
            _context.SaveChanges();

            return true;
        }

        public bool EditProductAmount(int productId, int newAmount)
        {
            var productToEdit = _context.Products.Find(productId);

            if (productToEdit == null)
                return false;

            productToEdit.Amount = newAmount;
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
    }
}

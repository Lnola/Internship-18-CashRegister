using System;
using System.Collections.Generic;
using System.Text;
using CashRegister.Data.Entities.Models;

namespace CashRegister.Domain.Interfaces
{
    public interface IProductRepository
    {
        List<Product> GetAllProducts();
        List<Product> GetProductsMatchingInput(string input);
        bool AddProduct(Product productToAdd);
        bool EditProduct(Product editedProduct);
        bool EditProductAmount(int productId, int newAmount);
        bool DeleteProduct(Product idOfProductToDelete);
    }
}

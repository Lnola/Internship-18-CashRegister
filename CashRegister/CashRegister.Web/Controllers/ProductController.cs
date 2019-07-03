using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CashRegister.Data.Entities.Models;
using CashRegister.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CashRegister.Web.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        private readonly IProductRepository _productRepository;

        [HttpGet("all")]
        public IActionResult GetAllProducts()
        {
            return Ok(_productRepository.GetAllProducts());
        }

        [HttpPost("add")]
        public IActionResult AddProduct(Product productToAdd)
        {
            var wasAddSuccessful = _productRepository.AddProduct(productToAdd);
            if (wasAddSuccessful)
                return Ok();
            return Forbid();
        }

        [HttpPost("edit")]
        public IActionResult EditProduct(Product editedProduct)
        {
            var wasEditSuccessful = _productRepository.EditProduct(editedProduct);
            if (wasEditSuccessful)
                return Ok();
            return NotFound();
        }

        [HttpPost("editAmount")]
        public IActionResult EditProductAmount(int id, int newAmount)
        {
            var wasEditSuccessful = _productRepository.EditProductAmount(id, newAmount);
            if (wasEditSuccessful)
                return Ok();
            return NotFound();
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteProduct(Product id)
        {
            var wasDeleteSuccessful = _productRepository.DeleteProduct(id);
            if (wasDeleteSuccessful)
                return Ok();
            return Forbid();
        }
    }
}
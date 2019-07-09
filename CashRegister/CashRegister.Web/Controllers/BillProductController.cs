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
    [Route("api/bill-products")]
    [ApiController]
    public class BillProductController : ControllerBase
    {
        public BillProductController(IBillProductRepository billProductRepository)
        {
            _billProductRepository = billProductRepository;
        }

        private readonly IBillProductRepository _billProductRepository;

        [HttpGet("all")]
        public IActionResult GetAllBillProductsByBillId(int billId)
        {
            return Ok(_billProductRepository.GetBillProductsByBillId(billId));
        }

        [HttpPost("add")]
        public IActionResult AddBillProduct(BillProduct billProductToAdd)
        {
            var wasAddSuccessful = _billProductRepository.AddBillProduct(billProductToAdd);
            if (wasAddSuccessful)
                return Ok();
            return Forbid();
        }
    }
}
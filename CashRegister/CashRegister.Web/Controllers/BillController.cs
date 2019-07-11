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
    [Route("api/bills")]
    [ApiController]
    public class BillController : ControllerBase
    {
        public BillController(IBillRepository billRepository)
        {
            _billRepository = billRepository;
        }

        private readonly IBillRepository _billRepository;

        [HttpGet("get-ten")]
        public IActionResult GetTenBills(int startingPosition)
        {
            return Ok(_billRepository.GetTenBills(startingPosition));
        }

        [HttpGet("get-similar")]
        public IActionResult GetSimilarBills(string dateInput)
        {
            return Ok(_billRepository.GetSearchedBills(dateInput));
        }

        [HttpPost("add")]
        public IActionResult AddBill(Bill billToAdd)
        {
            var wasAddSuccessful = _billRepository.AddBill(billToAdd, billToAdd.BillProducts.ToList());
            //var wasAddSuccessful = _billRepository.AddBill(billToAdd, null);
            if (wasAddSuccessful)
                return Ok();

            return Forbid();
        }
    }
}
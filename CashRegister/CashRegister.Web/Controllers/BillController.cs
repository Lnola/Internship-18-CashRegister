using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    }
}
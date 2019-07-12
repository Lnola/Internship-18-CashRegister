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
    [Route("api/cashier-register")]
    [ApiController]
    public class CashierRegisterController : ControllerBase
    {
        public CashierRegisterController(ICashierRegisterRepository cashierRegisterRepository)
        {
            _cashierRegisterRepository = cashierRegisterRepository;
        }

        private readonly ICashierRegisterRepository _cashierRegisterRepository;

        [HttpPost("add")]
        public IActionResult AddCashierRegister(CashierRegister cashierRegisterToAdd)
        {
            var wasAddSuccessful =
                _cashierRegisterRepository.AddCashierRegister(cashierRegisterToAdd.RegisterId,
                    cashierRegisterToAdd.CashierId);
            if (wasAddSuccessful)
                return Ok();
            return Forbid();
        }
    }
}
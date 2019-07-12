using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CashRegister.Data.Entities;
using CashRegister.Data.Entities.Models;
using CashRegister.Domain.Interfaces;

namespace CashRegister.Domain.Implementations
{
    public class CashierRegisterRepository : ICashierRegisterRepository
    {
        private readonly CashRegisterContext _context;

        public CashierRegisterRepository(CashRegisterContext context)
        {
            _context = context;
        }

        public bool AddCashierRegister(int registerId, int cashierId)
        {
            var doesRegisterExist = _context.Registers.Any(register => register.Id.Equals(registerId));
            var doesCashierExist = _context.Cashiers.Any(cashier => cashier.Id.Equals(cashierId));

            if (!doesRegisterExist || !doesCashierExist)
                return false;

            var newCashierRegister = new CashierRegister() { RegisterId = registerId, CashierId = cashierId };

            var doesCashierRegisterExist = _context.CashierRegisters.Any(cashierRegister =>
                cashierRegister.RegisterId.Equals(registerId) && cashierRegister.CashierId.Equals(cashierId));

            if (doesCashierRegisterExist) return true;

            _context.CashierRegisters.Add(newCashierRegister);
            _context.SaveChanges();

            return true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CashRegister.Data.Entities;
using CashRegister.Data.Entities.Models;
using CashRegister.Domain.Interfaces;

namespace CashRegister.Domain.Implementations
{
    public class BillRepository: IBillRepository
    {
        private readonly CashRegisterContext _context;

        public BillRepository(CashRegisterContext context)
        {
            _context = context;
        }

        public List<Bill> GetTenBills(int startPosition)
        {
            return _context.Bills.OrderByDescending(bill => bill.IssueDate).Skip(startPosition).Take(1).ToList();
        }
    }
}

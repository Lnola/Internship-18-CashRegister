using System;
using System.Collections.Generic;
using System.Text;
using CashRegister.Data.Entities.Models;

namespace CashRegister.Domain.Interfaces
{
    public interface IBillRepository
    {
        List<Bill> GetTenBills(int startPosition);
        List<Bill> GetSearchedBills(string dateInput);
        bool AddBill(Bill billToAdd, List<BillProduct> productsToAdd);
    }
}

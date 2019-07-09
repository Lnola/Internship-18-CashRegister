using System;
using System.Collections.Generic;
using System.Text;
using CashRegister.Data.Entities.Models;

namespace CashRegister.Domain.Interfaces
{
    public interface IBillProductRepository
    {
        List<BillProduct> GetBillProductsByBillId(int id);
        bool AddBillProduct(BillProduct billProductToAdd);
    }
}

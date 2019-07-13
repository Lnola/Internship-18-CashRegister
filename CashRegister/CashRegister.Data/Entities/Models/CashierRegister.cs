using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CashRegister.Data.Entities.Models
{
    public class CashierRegister
    {
        public int CashierId { get; set; }
        public Cashier Cashier { get; set; }
        public int RegisterId { get; set; }
        public Register Register { get; set; }
        public ICollection<Bill> Bills { get; set; }
    }
}

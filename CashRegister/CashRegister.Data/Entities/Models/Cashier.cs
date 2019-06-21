using System;
using System.Collections.Generic;
using System.Text;

namespace CashRegister.Data.Entities.Models
{
    public class Cashier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<CashierRegister> CashierRegisters { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CashRegister.Data.Entities.Models
{
    public class Bill
    {
        public int Id { get; set; }
        public Guid Guid = Guid.NewGuid();
        public DateTime IssueDate { get; set; }
        public double TotalPriceWithoutTax { get; set; }
        public double TotalPriceWithTax { get; set; }
        public CashierRegister CashierRegister { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}

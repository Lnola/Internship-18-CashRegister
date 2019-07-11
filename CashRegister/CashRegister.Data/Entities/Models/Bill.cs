using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CashRegister.Data.Entities.Models
{
    public class Bill
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public DateTime IssueDate { get; set; }
        public double TotalPriceWithoutTax { get; set; }
        public double ExciseDutyAmount { get; set; }
        public double ValueAddedTaxAmount { get; set; }
        public double CustomTaxAmount { get; set; }
        public double TotalPriceWithTax { get; set; }
        public CashierRegister CashierRegister { get; set; }
        public ICollection<BillProduct> BillProducts { get; set; }
    }
}

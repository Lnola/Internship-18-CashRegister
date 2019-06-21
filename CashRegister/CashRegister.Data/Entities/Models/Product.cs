using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CashRegister.Data.Entities.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Barcode { get; set; }
        public double Price { get; set; }
        public int ValueAddedTax { get; set; }
        public int ExciseDuty { get; set; }
        public int Amount { get; set; }
        public Bill Bill { get; set; }
    }
}

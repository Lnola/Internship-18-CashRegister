using System;
using System.Collections.Generic;
using System.Text;

namespace CashRegister.Data.Entities.Models
{
    public class BillProduct
    {
        public int BillId { get; set; }
        public Bill Bill { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public double PriceAtPurchase { get; set; }
        public int TaxAtPurchase { get; set; }
    }
}

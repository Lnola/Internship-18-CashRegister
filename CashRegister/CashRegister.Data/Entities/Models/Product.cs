using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CashRegister.Data.Entities.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Barcode { get; set; }
        public double Price { get; set; }
        public int Tax { get; set; } 
        public int Amount { get; set; }

        public ICollection<BillProduct> BillProducts { get; set; }
    }
}

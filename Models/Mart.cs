using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace FaiqTanveer.Models
{
    public class Mart
    {
            [Key]
            public int ProductID { get; set; }
            public string ItemName { get; set; }
            public DateTime ExpiryDate { get; set; }
            public decimal Amount { get; set; }
            public decimal Price { get; set; }
        }
        public class MartDBContext : DbContext
        {
            public DbSet<Mart> Marts { get; set; }
        }
}
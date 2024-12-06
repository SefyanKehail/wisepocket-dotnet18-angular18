using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Expense
    {
        public int Id { get; set; }
        public int? CategoryId { get; set; }
        public int? UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public Category? Category { get; set; }
        public User? User { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Budget
    {
        public int Id { get; set; }
        public int? UserId { get; set;}
        public DateTime MonthYear { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]        
        public decimal BudgetLimit { get; set; } 
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public User? User { get; set; }       
    }
}
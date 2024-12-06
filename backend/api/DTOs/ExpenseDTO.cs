using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs
{
    public class ExpenseDTO
    {
        public int Id { get; set; }                
        public string Name { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string CategoryName { get; set; } = string.Empty;
    }
}
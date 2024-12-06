using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs;

namespace api.Services
{
    public interface IExpenseService
    {
        Task AddAsync(CreateExpenseDTO createExpenseDTO);
        Task<ExpenseDTO?> GetByIdAsync(int id);
        Task<IEnumerable<ExpenseDTO>> GetAllAsync();
        Task DeleteAsync(int id);
        Task<decimal> GetCurrentMonthSpent();
        Task<IEnumerable<ExpenseDTO>> GetMostRecentAsync();
    }
}
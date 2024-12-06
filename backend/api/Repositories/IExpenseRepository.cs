using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Repositories
{
    public interface IExpenseRepository
    {
        Task AddAsync(Expense expense);
        Task<IEnumerable<Expense>> GetAllAsync();
        Task<Expense?> GetByIdAsync(int id);
        Task DeleteAsync(Expense expense);
        Task<decimal> GetCurrentMonthSpent();
        Task<IEnumerable<Expense>> GetMostRecentAsync();
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly ApplicationDBContext _dBContext;

        public ExpenseRepository(ApplicationDBContext dbContext)
        {
            _dBContext = dbContext;
        }

        public async Task AddAsync(Expense expense)
        {
            await _dBContext.Expense.AddAsync(expense);
            await _dBContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Expense expense)
        {
            _dBContext.Expense.Remove(expense);
            await _dBContext.SaveChangesAsync();
        }

        public async Task<Expense?> GetByIdAsync(int id)
        {
            return await _dBContext.Expense.FirstOrDefaultAsync(expense => expense.Id == id);
        }

        public async Task<IEnumerable<Expense>> GetAllAsync()
        {
            return await _dBContext.Expense
                .Include(expense => expense.Category)
                .ToListAsync();
        }

        public async Task<decimal> GetCurrentMonthSpent()
        {
            var currentMonth = DateTime.Now.Month;
            var currentYear = DateTime.Now.Year;

            return await _dBContext.Expense
                .Where(e => e.Date.Year == currentYear && e.Date.Month == currentMonth)
                .SumAsync(e => e.Amount);
        }

        public async Task<IEnumerable<Expense>> GetMostRecentAsync()
        {
            return await _dBContext.Expense
                .Include(expense => expense.Category)
                .OrderByDescending(e => e.Date)
                .Take(10)
                .ToListAsync();
        }
    }
}
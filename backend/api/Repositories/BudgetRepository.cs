using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class BudgetRepository : IBudgetRepository
    {
        private readonly ApplicationDBContext _dbContext;

        public BudgetRepository(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Budget?> GetByMonthYearAsync(DateTime monthYear)
        {
            return await _dbContext.Budget
                .FirstOrDefaultAsync(b => b.MonthYear.Year == monthYear.Year && b.MonthYear.Month == monthYear.Month);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs;

namespace api.Services
{
    public interface IBudgetService
    {
        Task<BudgetDTO?> GetByMonthYearAsync(DateTime monthYear);
    }
}
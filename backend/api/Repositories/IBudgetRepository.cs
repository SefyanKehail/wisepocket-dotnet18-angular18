using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Repositories
{
    public interface IBudgetRepository
    {
        Task<Budget?> GetByMonthYearAsync(DateTime monthYear);
    }
}
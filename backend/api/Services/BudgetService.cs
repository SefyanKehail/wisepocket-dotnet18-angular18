using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs;
using api.Exceptions;
using api.Models;
using api.Repositories;

namespace api.Services
{
    public class BudgetService : IBudgetService
    {
        private readonly IBudgetRepository _budgetRepository;
        public BudgetService(IBudgetRepository budgetRepository)
        {
            _budgetRepository = budgetRepository;
        }
        public async Task<BudgetDTO?> GetByMonthYearAsync(DateTime monthYear)
        {
            Budget? budget = await _budgetRepository.GetByMonthYearAsync(monthYear);

            if (budget == null)
            {
                throw new BudgetNotFoundException();
            }

            return new BudgetDTO
            {
                BudgetLimit = budget.BudgetLimit
            };
        }
    }
}
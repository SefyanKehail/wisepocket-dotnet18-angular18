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
    public class ExpenseService : IExpenseService
    {
        private readonly IExpenseRepository _expenseRepository;
        public ExpenseService(IExpenseRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }
        public async Task AddAsync(CreateExpenseDTO createExpenseDTO)
        {
            var expense = new Expense
            {
                Name = createExpenseDTO.Name,
                Amount = createExpenseDTO.Amount,
                Date = createExpenseDTO.Date,
                CategoryId = createExpenseDTO.CategoryId,
                UserId = createExpenseDTO.UserId
            };

            await _expenseRepository.AddAsync(expense);
        }

        public async Task DeleteAsync(int id)
        {
            Expense? expense = await _expenseRepository.GetByIdAsync(id);

            if (expense == null)
            {
                throw new ExpenseNotFoundException();
            }

            await _expenseRepository.DeleteAsync(expense);
        }

        public async Task<IEnumerable<ExpenseDTO>> GetAllAsync()
        {
            var expenses = await _expenseRepository.GetAllAsync();
            return expenses.Select(expense => new ExpenseDTO
            {
                Id = expense.Id,
                Name = expense.Name,
                Amount = expense.Amount,
                Date = expense.Date,
                CategoryName = expense.Category!.Name,
            }
            );
        }

        public async Task<ExpenseDTO?> GetByIdAsync(int id)
        {
            Expense? expense = await _expenseRepository.GetByIdAsync(id);

            if (expense == null)
            {
                throw new ExpenseNotFoundException();
            }

            return new ExpenseDTO
            {
                Name = expense.Name,
                Amount = expense.Amount,
                Date = expense.Date,
                CategoryName = expense.Category!.Name,
            };
        }

        public async Task<decimal> GetCurrentMonthSpent()
        {
            return await _expenseRepository.GetCurrentMonthSpent();
        }

        public async Task<IEnumerable<ExpenseDTO>> GetMostRecentAsync()
        {
            var expenses = await _expenseRepository.GetMostRecentAsync();
            return expenses.Select(expense => new ExpenseDTO
            {
                Id = expense.Id,
                Name = expense.Name,
                Amount = expense.Amount,
                Date = expense.Date,
                CategoryName = expense.Category!.Name,
            }
            );
        }
    }
}
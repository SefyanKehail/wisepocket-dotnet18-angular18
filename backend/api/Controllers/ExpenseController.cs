using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs;
using api.Exceptions;
using api.Models;
using api.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/expense")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        private readonly IExpenseService _expenseService;

        public ExpenseController(IExpenseService expenseService)
        {
            _expenseService = expenseService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateExpenseDTO createExpenseDTO)
        {
            await _expenseService.AddAsync(createExpenseDTO);
            return Ok(createExpenseDTO);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<ExpenseDTO> expenses = await _expenseService.GetAllAsync();
            return Ok(expenses);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _expenseService.DeleteAsync(id);
                return Ok();
            }
            catch (ExpenseNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                ExpenseDTO? expenseDTO = await _expenseService.GetByIdAsync(id);
                return Ok(expenseDTO);
            }
            catch (ExpenseNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpGet("currentMonthSpent")]
        public async Task<IActionResult> GetCurrentMonthSpent()
        {
            decimal currentMonthSpent = await _expenseService.GetCurrentMonthSpent();
            return Ok(currentMonthSpent);
        }

        [HttpGet("getMostRecent")]
        public async Task<IActionResult> GetMostRecentAsync()
        {
            IEnumerable<ExpenseDTO> expenses = await _expenseService.GetMostRecentAsync();
            return Ok(expenses);
        }
    }
}
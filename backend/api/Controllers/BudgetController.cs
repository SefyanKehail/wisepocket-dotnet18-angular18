using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs;
using api.Exceptions;
using api.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/budget")]
    [ApiController]
    public class BudgetController : ControllerBase
    {
        private readonly IBudgetService _budgetService;
        public BudgetController(IBudgetService budgetService)
        {
            _budgetService = budgetService;
        }

        [HttpGet]
        public async Task<IActionResult> GetByMonthYear([FromQuery] DateTime monthYear)
        {
            try
            {
                // if (!DateTime.TryParse(monthYear, out var parsedDate))
                // {
                //     return BadRequest("invalid date format");
                // }

                BudgetDTO? budgetDTO = await _budgetService.GetByMonthYearAsync(monthYear);
                return Ok(budgetDTO);
            }
            catch (BudgetNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
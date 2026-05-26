using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBConnection.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DBConnection.Controllers
{
    [Route("api/Expense")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        private PropertyContext _propertyDbContext;

        public ExpenseController(PropertyContext propertyDbContext)
        {
            _propertyDbContext = propertyDbContext;
        }
        [HttpGet("GetExpensesForProperty")]
        public async Task<List<PropertyExpense>> GetPropertyExpenses(Guid propertyId)
        {
            return await _propertyDbContext.PropertyExpense
                .Where(x => x.PropertyId == propertyId)
                .ToListAsync();
        }
        [HttpGet("GetCompanyExpenses")]
        public async Task<List<CompanyExpense>> GetCompanyExpenses(Guid propertyId)
        {
            return await _propertyDbContext.CompanyExpense
                .ToListAsync();
        }

    }
}

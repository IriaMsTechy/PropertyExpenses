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
            return await _propertyDbContext.PropertyExpenses
                .Where(x => x.PropertyId == propertyId)
                .ToListAsync();
        }
        [HttpGet("GetCompanyExpenses")]
        public async Task<List<CompanyExpense>> GetCompanyExpenses()
        {
            return await _propertyDbContext.CompanyExpenses
                .ToListAsync();
        }
        [HttpPost("PostNewPropertyExpense")]
        public async Task<PropertyExpense> PostNewPropertyExpense(PropertyExpense newPropertyExpense)
        {
            var propertyExpenseSaved = await _propertyDbContext.PropertyExpenses.AddAsync(newPropertyExpense);
            await _propertyDbContext.SaveChangesAsync();
            return propertyExpenseSaved.Entity;
        }
        [HttpPost("PostNewCompanyExpense")]
        public async Task<CompanyExpense> PostNewCompanyExpense(CompanyExpense newCompanyExpense)
        {
            var companyExpenseSaved = await _propertyDbContext.CompanyExpenses.AddAsync(newCompanyExpense);
            await _propertyDbContext.SaveChangesAsync();
            return companyExpenseSaved.Entity;
        }
        [HttpPut("UpdatePropertyExpense")]
        public async Task<PropertyExpense> UpdatePropertyExpense(PropertyExpense updatedPropertyExpense)
        {
            _propertyDbContext.PropertyExpenses.Update(updatedPropertyExpense);
            await _propertyDbContext.SaveChangesAsync();
            return updatedPropertyExpense;
        }
        [HttpPut("UpdateCompanyExpense")]
        public async Task<CompanyExpense> UpdateCompanyExpense(CompanyExpense updatedCompanyExpense)
        {
            _propertyDbContext.CompanyExpenses.Update(updatedCompanyExpense);
            await _propertyDbContext.SaveChangesAsync();
            return updatedCompanyExpense;
        }

        [HttpDelete("DeletePropertyExpense")]
        public async Task DeletePropertyExpense(Guid id)
        {
            await _propertyDbContext.PropertyExpenses
                .Where(x => x.Id == id)
                .ExecuteDeleteAsync();
        }

        [HttpDelete("DeleteCompanyExpense")]
        public async Task DeleteCompanyExpense(Guid id)
        {
            await _propertyDbContext.CompanyExpenses
                .Where(x => x.Id == id)
                .ExecuteDeleteAsync();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBConnection.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace DBConnection.Controllers
{
    [Route("api/Income")]
    [ApiController]
    public class IncomeController : ControllerBase
    {
        private PropertyContext _propertyDbContext;
        public IncomeController(PropertyContext propertyDbContext)
        {
            _propertyDbContext = propertyDbContext;
        }
        [HttpGet("GetIncomeForProperty")]
        public async Task<List<Income>> GetPropertyIncomes(Guid propertyId)
        {
            return await _propertyDbContext.PropertyIncome
                .Where(x => x.PropertyId == propertyId)
                .ToListAsync();
        }

        [HttpPost("PostNewIncome")]
        public async Task<Income> PostNewIncome(Income newIncome)
        {
            var incomeSaved = await _propertyDbContext.PropertyIncome.AddAsync(newIncome);
            await _propertyDbContext.SaveChangesAsync();
            return incomeSaved.Entity;
        }

        [HttpPut("UpdateIncome")]
        public async Task<Income> UpdateIncome(Income updatedIncome)
        {
            _propertyDbContext.PropertyIncome.Update(updatedIncome);
            await _propertyDbContext.SaveChangesAsync();
            return updatedIncome;
        }

        [HttpDelete("DeleteIncome")]    
        public async Task DeleteIncome(Guid id)
        {
            await _propertyDbContext.PropertyIncome
                .Where(x => x.Id == id)
                .ExecuteDeleteAsync();
        }
    }
}

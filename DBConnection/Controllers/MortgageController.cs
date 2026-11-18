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
    [Route("api/Mortgage")]
    [ApiController]
    public class MortgageController : ControllerBase
    {
        private PropertyContext _propertyDbContext;
        public MortgageController(PropertyContext propertyDbContext)
        {
            _propertyDbContext = propertyDbContext;
        }

        [HttpGet("GetMortgageList")]
        public async Task<IActionResult> GetMortgageList()
        {
            var mortgages = await _propertyDbContext.Mortgages.ToListAsync();
            return Ok(mortgages);
        }

        [HttpGet("GetMortgageListForProperty/{propertyId}")]
        public async Task<IActionResult> GetMortgageListForProperty(Guid propertyId)
        {
            var mortgages = await _propertyDbContext.Mortgages
                .Where(m => m.PropertyId == propertyId)
                .ToListAsync();
            return Ok(mortgages);
        }

        [HttpPost("AddMortgage")]
        public async Task<IActionResult> AddMortgage([FromBody] Mortgage mortgage)
        {
            if (mortgage == null)
            {
                return BadRequest();
            }

            await _propertyDbContext.Mortgages.AddAsync(mortgage);
            await _propertyDbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMortgageListForProperty), new { propertyId = mortgage.PropertyId }, mortgage);
        }

        [HttpPut("UpdateMortgage/{id}")]
        public async Task<IActionResult> UpdateMortgage(Guid id, [FromBody] Mortgage mortgage)
        {
            if (mortgage == null)
            {
                return BadRequest();
            }

            var existingMortgage = await _propertyDbContext.Mortgages.FindAsync(id);
            if (existingMortgage == null)
            {
                return NotFound();
            }

            existingMortgage.PropertyId = mortgage.PropertyId;
            existingMortgage.PrincipalAmount = mortgage.PrincipalAmount;
            existingMortgage.AnnualPromotionalInterestRate = mortgage.AnnualPromotionalInterestRate;
            existingMortgage.StartDate = mortgage.StartDate;
            existingMortgage.EndDate = mortgage.EndDate;

            await _propertyDbContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("DeleteMortgage/{id}")]
        public async Task<IActionResult> DeleteMortgage(Guid id)
        {
            var existingMortgage = await _propertyDbContext.Mortgages.FindAsync(id);
            if (existingMortgage == null)
            {
                return NotFound();
            }

            _propertyDbContext.Mortgages.Remove(existingMortgage);
            await _propertyDbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}

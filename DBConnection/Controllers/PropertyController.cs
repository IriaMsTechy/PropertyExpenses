using Microsoft.AspNetCore.Mvc;
using DBConnection.Models;
using Microsoft.EntityFrameworkCore;

namespace DBConnection.Controllers
{
    [ApiController]
    [Route("api/Property")]
    [Produces("application/json")]
    public class PropertyController : ControllerBase
    {
        private PropertyContext _propertyDbContext;
        public PropertyController(PropertyContext propertyDbContext) 
        {
            _propertyDbContext = propertyDbContext;
        }
        [HttpGet("GetProperty")]
        public async Task<PropertyModel?> GetProperty(Guid id)
        {
            return await _propertyDbContext.PropertyModels
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }
        [HttpGet("GetPropertyList")]
        [ProducesResponseType<List<PropertyModel>>(StatusCodes.Status200OK)]
        public async Task <IEnumerable<PropertyModel>> GetAllProperties()
        {
            return await _propertyDbContext
                .PropertyModels
                .ToListAsync();
        }
        [HttpGet("GetOwnedPropertyList")]
        [ProducesResponseType<List<PropertyModel>>(StatusCodes.Status200OK)]
        public async Task<IEnumerable<PropertyModel>> GetOwnedProperties()
        {
            return await _propertyDbContext
                .PropertyModels
                .Where(p => p.Owned)
                .ToListAsync();
        }

        [HttpPost("PostNewProperty")]
        public async Task<PropertyModel> PostProperty(PropertyModel newProperty)
        {
            var propertySaved = await _propertyDbContext
                .PropertyModels
                .AddAsync(newProperty);
            await _propertyDbContext.SaveChangesAsync();
            return propertySaved.Entity;
        }
        [HttpPut("update")]
        public async Task<PropertyModel> UpdatePropertyModel (PropertyModel updatedPropertyModel)
        {
            _propertyDbContext.PropertyModels.Update(updatedPropertyModel);
             await _propertyDbContext.SaveChangesAsync();
             return updatedPropertyModel;
        }
        [HttpDelete("DeleteProperty")]
        public async Task DeleteProperty(Guid id)
        {
            await _propertyDbContext
                .PropertyModels
                .Where(x => x.Id == id)
                .ExecuteDeleteAsync();

            await _propertyDbContext.SaveChangesAsync();
            return;
        }
    }
}

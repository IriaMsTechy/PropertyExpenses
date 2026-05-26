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
            return await _propertyDbContext.PropertyModel
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }
        [HttpGet("GetPropertyList")]
        [ProducesResponseType<List<PropertyModel>>(StatusCodes.Status200OK)]
        public async Task <IEnumerable<PropertyModel>> GetAllProperties()
        {
            return await _propertyDbContext
                .PropertyModel
                .ToListAsync();
        }

        [HttpPost("PostNewProperty")]
        public async Task<PropertyModel> PostProperty(PropertyModel newProperty)
        {
            var propertySaved = await _propertyDbContext
                .PropertyModel
                .AddAsync(newProperty);
            await _propertyDbContext.SaveChangesAsync();
            return propertySaved.Entity;
        }
        [HttpPut("update")]
        public async Task<PropertyModel> UpdatePropertyModel (PropertyModel updatedPropertyModel)
        {
            _propertyDbContext.PropertyModel.Update(updatedPropertyModel);
             await _propertyDbContext.SaveChangesAsync();
             return updatedPropertyModel;
        }
        [HttpDelete("DeleteProperty")]
        public async Task DeleteProperty(Guid id)
        {
            await _propertyDbContext
                .PropertyModel
                .Where(x => x.Id == id)
                .ExecuteDeleteAsync();

            await _propertyDbContext.SaveChangesAsync();
            return;
        }
    }
}

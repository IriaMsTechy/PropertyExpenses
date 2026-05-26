using PropertyExpensesUI.Models;

namespace PropertyExpensesUI.Services
{
    public interface IPropertyService
    {
        Task<IList<PropertyModel>> GetAllProperties();
        Task<PropertyModel> AddProperty(PropertyModel property);

        Task<PropertyModel> RemoveProperty(PropertyModel property);
        Task<PropertyModel> UpdateProperty(PropertyModel property);
    }
}

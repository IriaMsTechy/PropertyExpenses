using PropertyExpensesUI.Models;
using System.Net.Http.Json;

namespace PropertyExpensesUI.Services
{
    public class PropertyService: IPropertyService
    {

        private readonly IHttpClientFactory _httpClientFactory; 
        private readonly HttpClient _httpClient;

        public PropertyService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _httpClient = _httpClientFactory.CreateClient("ApiHttpClient");
        }
        public async Task<IList<PropertyModel>> GetAllProperties()
        {
            var requestedUri = $"Property/GetPropertyList";

            using HttpResponseMessage response = await _httpClient.GetAsync(requestedUri);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<IList<PropertyModel>>()?? new List<PropertyModel>();
        }

        public async Task<PropertyModel> AddProperty(PropertyModel property)
        {
            var requestedUri = $"Property/PostNewProperty";

            using HttpResponseMessage response = await _httpClient.PostAsJsonAsync(requestedUri, property);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<PropertyModel>() ?? property;
        }

        public async Task<PropertyModel> RemoveProperty(PropertyModel property)
        {
            var requestedUri = $"Property/DeleteProperty?id={property.Id}";
            using HttpResponseMessage response = await _httpClient.DeleteAsync(requestedUri);
            response.EnsureSuccessStatusCode();
            return property;
        }

        public async Task<PropertyModel> UpdateProperty(PropertyModel property)
        {
            var requestedUri = $"Property/update";
            using HttpResponseMessage response = await _httpClient.PutAsJsonAsync(requestedUri, property);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<PropertyModel>() ?? property;
        }
    }
}
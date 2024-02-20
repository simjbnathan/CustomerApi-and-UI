using CustomerApp.Interfaces;
using CustomerApp.Models;

namespace CustomerApp.Services
{
    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _httpClient.BaseAddress = new Uri("https://localhost:7064");
        }

        public async Task<IEnumerable<CustomerViewModel>> GetCustomersAsync()
        {
            var response = await _httpClient.GetAsync("api/customers");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<IEnumerable<CustomerViewModel>>();
        }

        public async Task<CustomerViewModel> GetCustomerAsync(int id)
        {
            var response = await _httpClient.GetAsync($"api/customers/{id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<CustomerViewModel>();
        }

        public async Task CreateCustomerAsync(CustomerViewModel customer)
        {
            var response = await _httpClient.PostAsJsonAsync("api/customers", customer);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateCustomerAsync(int id, CustomerViewModel customer)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/customers/{id}", customer);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteCustomerAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/customers/{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<CustomerViewModel> GetPremiumCustomersAsync(int id)
        {
            var response = await _httpClient.GetAsync($"api/customers/premium/{id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<PremiumCustomer>();
        }


    }
}


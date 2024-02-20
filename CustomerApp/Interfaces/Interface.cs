using CustomerApp.Models;

namespace CustomerApp.Interfaces
{
    // IApiService.cs
    public interface IApiService
    {
        
        Task<CustomerViewModel> GetCustomerAsync(int id);
        Task CreateCustomerAsync(CustomerViewModel customer);
        Task UpdateCustomerAsync(int id, CustomerViewModel customer);
        Task DeleteCustomerAsync(int id);
        Task<IEnumerable<CustomerViewModel>> GetCustomersAsync();

        Task<CustomerViewModel> GetPremiumCustomersAsync(int id);
    }

}

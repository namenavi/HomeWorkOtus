using Work16Lesson47.Models;

namespace Work16Lesson47.Data
{
    public interface ICustomerData
    {
        Task DeleteCustomer(int id);
        Task<Customer> GetCustomer(int id);
        Task<IEnumerable<Customer>> GetCustomersByFilter(string filter);
        Task<IEnumerable<Customer>> GetCustomers();
        Task InsertCustomer(Customer customer);
        Task UpdateCustomer(Customer customer);
    }
}
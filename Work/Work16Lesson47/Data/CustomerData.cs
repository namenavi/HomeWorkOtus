using Work16Lesson47.DataAccess;
using Work16Lesson47.Models;

namespace Work16Lesson47.Data
{
    public class CustomerData : ICustomerData
    {
        private readonly ISqlDataAccess _db;
        public CustomerData(ISqlDataAccess db)
        {
            _db = db;
        }

        public Task<IEnumerable<Customer>> GetCustomers() =>
            _db.LoadWithQuery<Customer, dynamic>("SELECT Id, FirstName, LastName, Age FROM Customers", new { });

        public Task<IEnumerable<Customer>> GetCustomersByFilter(string filter) =>
            _db.LoadWithQuery<Customer, dynamic>($"SELECT Id, FirstName, LastName FROM Customers WHERE FirstName LIKE '%{filter}%' OR LastName LIKE '%{filter}%'", new { });//default,

        public async Task<Customer?> GetCustomer(int id)
        {
            var result = await _db.LoadWithQuery<Customer, dynamic>($"SELECT Id, FirstName, LastName FROM Customers WHERE Id ={id}", new { });
            return result.FirstOrDefault();
        }

        public async Task InsertCustomer(Customer customer) =>
            await _db.SaveData($"INSERT INTO Customers ( firstname, lastname, age) VALUES ( @FirstName, @LastName, {customer.Age});"
                , new { customer.FirstName, customer.LastName });

        public async Task UpdateCustomer(Customer customer) =>
            await _db.SaveData("dbo.spCustomer_Update", customer);

        public async Task DeleteCustomer(int id) =>
            await _db.SaveData("dbo.spCustomer_Delete", new { Id = id });

    }
}

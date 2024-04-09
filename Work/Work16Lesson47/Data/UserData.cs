using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        //public Task<IEnumerable<Customer>> GetCustomers() =>
        //    _db.LoadData<Customer, dynamic>("dbo.spCustomer_GetAll", new { });

        public Task<IEnumerable<Customer>> GetCustomers() =>
            _db.LoadWithQuery<Customer, dynamic>("SELECT Id, FirstName, LastName FROM [dbo].[Customer]", new { });

        public Task<IEnumerable<Customer>> GetCustomersByFilter(string filter) =>
            _db.LoadData<Customer, dynamic>("dbo.spCustomer_GetByFilter", new { Filter = filter });

        public async Task<Customer?> GetCustomer(int id)
        {
            var results = await _db.LoadData<Customer, dynamic>("dbo.spCustomer_Get", new { Id = id });
            return results.FirstOrDefault();
            //return await GetCustomerWithRelations(id);
            //throw new NotImplementedException();
        }

        //public async Task<Customer?> GetCustomerWithRelations(int id)
        //{
        //    var results = await _db.LoadWithJoin<Customer, RelationModel, dynamic>(
        //        "SELECT u.Id, FirstName, LastName, RelationShip, r.Id, FullName FROM [Customer] u LEFT OUTER JOIN Relative r ON r.CustomerId = u.Id WHERE u.Id = @Id",
        //        new { Id = id },
        //        (u, r) => { u.Relations.Add(r); return u; }, "RelationShip");
        //    return results.FirstOrDefault();
        //}

        public async Task InsertCustomer(Customer customer) =>
            await _db.SaveData("dbo.spCustomer_Insert", new { customer.FirstName, customer.LastName });

        public async Task UpdateCustomer(Customer customer) =>
            await _db.SaveData("dbo.spCustomer_Update", customer);

        public async Task DeleteCustomer(int id) =>
            await _db.SaveData("dbo.spCustomer_Delete", new { Id = id });

    }
}

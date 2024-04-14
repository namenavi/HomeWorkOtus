using Work16Lesson47.DataAccess;
using Work16Lesson47.Models;

namespace Work16Lesson47.Data
{
    public class OrderData
    {
        private readonly ISqlDataAccess _db;
        public OrderData(ISqlDataAccess db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Order>> GetOrdersWithCustomers()
        {
            var results = await _db.LoadWithJoin<Order, Customer, dynamic>(
                "SELECT o.Id, o.CustomerId, o.ProductId,o.Quantity, c.FirstName, c.Id, c.LastName, c.Age  FROM orders o LEFT OUTER JOIN Customers c ON c.Id = o.CustomerId",
                new { },
                (o, c) => { o.Customer = c; return o; }, "FirstName");
            return results;
        }
    }
}

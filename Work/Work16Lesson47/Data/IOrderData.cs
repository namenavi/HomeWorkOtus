using Work16Lesson47.Models;

namespace Work16Lesson47.Data
{
    public interface IOrderData
    {
        Task<IEnumerable<Order>> GetOrdersWithCustomers();
    }
}
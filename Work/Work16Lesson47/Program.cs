using Work16Lesson47.Data;
using Work16Lesson47.DataAccess;
using Work16Lesson47.Models;

namespace Work16Lesson47
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var db = new SqlDataAccess("Host=localhost;Port=5432;Database=Shop;Username=postgres;Password=pass");
            CustomersData(db);
            OrdersData(db);
            Console.ReadLine();

        }

        private static async void CustomersData(SqlDataAccess db)
        {
            var data = new CustomerData(db);
            var list = await data.GetCustomers();
            var list1 = await data.GetCustomersByFilter("Em");
            var list2 = await data.GetCustomer(2);
            await data.InsertCustomer(new Customer() { FirstName ="Петр", LastName="Абрамович", Age=22 });
        }
        private static async void OrdersData(SqlDataAccess db)
        {
            var data = new OrderData(db);
            var list = await data.GetOrdersWithCustomers();
        }
    }
}

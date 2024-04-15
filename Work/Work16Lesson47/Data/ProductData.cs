using Work16Lesson47.DataAccess;
using Work16Lesson47.Models;

namespace Work16Lesson47.Data
{
    public class ProductData : IProductData
    {
        private readonly ISqlDataAccess _db;
        public ProductData(ISqlDataAccess db)
        {
            _db = db;
        }

        public Task<IEnumerable<Product>> GetProducts() =>
            _db.LoadWithQuery<Product, dynamic>("SELECT id, name, description, stockquantity, price FROM Products", new { });

        public Task<IEnumerable<Product>> GetProductsByFilter(string filter) =>
            _db.LoadWithQuery<Product, dynamic>($"SELECT id, name, description, stockquantity, price FROM Products WHERE name LIKE '%{filter}%' OR description LIKE '%{filter}%'", new { });//default,

        public async Task<Product?> GetProduct(int id)
        {
            var result = await _db.LoadWithQuery<Product, dynamic>($"SELECT id, name, description, stockquantity, price FROM Products WHERE Id ={id}", new { });
            return result.FirstOrDefault();
        }

    }
}

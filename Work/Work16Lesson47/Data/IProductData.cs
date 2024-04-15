using Work16Lesson47.Models;

namespace Work16Lesson47.Data
{
    public interface IProductData
    {
        Task<Product?> GetProduct(int id);
        Task<IEnumerable<Product>> GetProducts();
        Task<IEnumerable<Product>> GetProductsByFilter(string filter);
    }
}
using CrudUsingMigration.Models;

namespace CrudUsingMigration.Data
{
    public interface IProductDetail
    {
        public Task<List<Products>> GetProductDetail();
        public Task<bool> PostProductDetail(ProductDetailsClass productdetailsclass);
        Task<bool> Update(int id, Products products);
        Task<bool> Delete(int id);
        IEnumerable<Products> GetById(int id);
    }
}

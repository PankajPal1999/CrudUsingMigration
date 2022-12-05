using CrudUsingMigration.Models;

namespace CrudUsingMigration.Data
{
    public interface ICategories
    {
        public Task<List<Categorie>> GetCategories();
        public Task<bool> PostCategories(Categorie categories);
        Task<bool> Update(int id, Categorie categorie);
        Task<bool> Delete(int id);
        IEnumerable<Categorie> GetById(int id);


    }
}

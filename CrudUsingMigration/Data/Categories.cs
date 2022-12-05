using CrudUsingMigration.Context;
using CrudUsingMigration.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudUsingMigration.Data
{
    public class Categories:ICategories
    {
        private readonly MainContext _mainContext;

        public Categories(MainContext context)
        {
            _mainContext = context;
        }
        public async Task<bool> PostCategories(Categorie categories)
        {
            if (categories == null)
            {
                throw new ArgumentNullException(nameof(categories));
            }
            await _mainContext.Categories.AddAsync(categories);
            await _mainContext.SaveChangesAsync();
            return true;
        }
        public async Task<List<Categorie>> GetCategories()
        {
            var categories = await _mainContext.Categories.ToListAsync();
         return categories;
        }
        public IEnumerable<Categorie> GetById(int id)
        {

            var Categorie = _mainContext.Categories.Find(id);
            yield return Categorie;
        }
        public async Task<bool> Update(int id, Categorie categorie)
        {
            if (categorie == null)
            {
                throw new ArgumentNullException(nameof(categorie));
            }
            else
            {
                Categorie entity = _mainContext.Categories.FirstOrDefault(e => e.CategoryId == id);
                if (entity != null)
                {
                    entity.CategoryName = categorie.CategoryName;
                    entity.BrandName = categorie.BrandName;
                    entity.Sequence = categorie.Sequence;
                    _mainContext.Attach(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                    await _mainContext.SaveChangesAsync();
                }
                return true;


            }
        }
        public async Task<bool> Delete(int id)
        {

            var categorie = await _mainContext.Categories.FindAsync(id);

            _mainContext.Categories.Remove(categorie);
            await _mainContext.SaveChangesAsync();

            return true;

        }
    }
}

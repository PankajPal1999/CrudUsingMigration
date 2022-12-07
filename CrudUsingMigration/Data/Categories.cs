using CrudUsingMigration.Context;
using CrudUsingMigration.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
           var categorie= await _mainContext.Categories.FindAsync(categories.Sequence);

            if (categories == null)
            {
                throw new ArgumentNullException(nameof(categories));
            }
         var entity = _mainContext.Categories.FirstOrDefault(e => e.Sequence == categories.Sequence);
            if (entity == null)
            {
                await _mainContext.Categories.AddAsync(categories);
                await _mainContext.SaveChangesAsync();
                 return true;
            }
              return false; 
        }
        public async Task<List<Categorie>> GetCategories(int page)
        {
            var pageResults = 6f;
            var pageCount = Math.Ceiling(_mainContext.Categories.Count() / pageResults);
            var categories = await _mainContext.Categories
                .Skip((page - 1) * (int)pageResults).Take((int)pageResults).ToListAsync();
           // var categories = await _mainContext.Categories.ToListAsync();
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
                var entity = _mainContext.Categories.FirstOrDefault(e => e.CategoryId == id);
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

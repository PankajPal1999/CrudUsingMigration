using AutoMapper;
using CrudUsingMigration.Context;
using CrudUsingMigration.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudUsingMigration.Data
{
    public class ProductDetail:IProductDetail
    {
        private readonly MainContext _mainContext;
        private readonly IMapper _mapper;

        public ProductDetail(MainContext context,IMapper mapper)
        {
            _mainContext = context;
            _mapper = mapper;   
        }
        public async Task<bool> PostProductDetail(ProductDetailsClass productdetailsclass)
        {
            if (productdetailsclass == null)
            {
                throw new ArgumentNullException(nameof(productdetailsclass));
            }

            var map = _mapper.Map<Products>(productdetailsclass);

            await _mainContext.Products.AddAsync(map);
            await _mainContext.SaveChangesAsync();
            return true;
        }
        public async Task<List<Products>> GetProductDetail()
        {
            var productdetail = await _mainContext.Products.ToListAsync();
            return productdetail;
        }
        public IEnumerable<Products> GetById(int id)
        {

            var product = _mainContext.Products.Find(id);
            yield return product;
        }
        public async Task<bool> Update(int id, Products products)
        {
            if (products == null)
            {
                throw new ArgumentNullException(nameof(products));
            }
            else
            {
                Products entity = _mainContext.Products.FirstOrDefault(e => e.ProductId == id);
                if (entity != null)
                {
                    entity.ProductTitle = products.ProductTitle;
                    entity.ProductDescription = products.ProductDescription;
                    entity.Price = products.Price;
                    entity.SellingPrice = products.SellingPrice;
                    entity.CategoryId = products.CategoryId;
                   // entity.CategoriesCategoryId = products.CategoriesCategoryId;
                    _mainContext.Attach(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                    await _mainContext.SaveChangesAsync();
                }
                return true;


            }
        }
        public async Task<bool> Delete(int id)
        {

            var product = await _mainContext.Products.FindAsync(id);

            _mainContext.Products.Remove(product);
            await _mainContext.SaveChangesAsync();

            return true;

        }
    }
}

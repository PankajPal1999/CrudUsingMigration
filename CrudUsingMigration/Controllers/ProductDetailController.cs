using CrudUsingMigration.Context;
using CrudUsingMigration.Data;
using CrudUsingMigration.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudUsingMigration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailController : ControllerBase
    {
        private readonly MainContext _mainContext;

        private IProductDetail productDetail;

        public ProductDetailController(IProductDetail _productDetail, MainContext context)
        {
            productDetail = _productDetail;
            _mainContext = context;
        }
        [HttpPost]
        [Route("PostProduct")]
        public async Task<ActionResult> PostCategories([FromBody] ProductDetailsClass productdetailsclass)
        {
            if (productdetailsclass == null)
            {
                return NotFound();
            }
            try
            {
                await productDetail.PostProductDetail(productdetailsclass);
                return Ok(productdetailsclass);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        [HttpGet]
        [Route("GetProduct")]

        public async Task<ActionResult<List<Products>>> GetProduct()
        {
            var ProductList = await productDetail.GetProductDetail();
            if (ProductList == null)
            {
                throw new ArgumentNullException(nameof(ProductList));
            }
            return Ok(ProductList);
        }
        [HttpGet]
        [Route("GetById")]

        public ActionResult GetById(int id)
        {
            try
            {
                var PRODUCT = productDetail.GetById(id);
                return Ok(PRODUCT);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        [HttpPut]
        [Route("Update")]

        public async Task<ActionResult> Update(int id, Products products)
        {
            try
            {
                var cproduct_Upd = await productDetail.Update(id, products);
                return Ok(cproduct_Upd);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpDelete]
        [Route("DeleteProduct")]

        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                return Ok(await productDetail.Delete(id));
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}

using CrudUsingMigration.Context;
using CrudUsingMigration.Data;
using CrudUsingMigration.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudUsingMigration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategorieController : ControllerBase
    {
       private readonly MainContext _mainContext;

        private ICategories CategoriesRepository;

        public CategorieController(ICategories _CategoriesRepository, MainContext context)
        {
            CategoriesRepository = _CategoriesRepository;
            _mainContext = context;
        }
        [HttpPost]
        [Route("PostCategories")]
        public async Task<ActionResult> PostCategories([FromBody] Categorie categorie)
        {
            if (categorie == null)
            {
                return NotFound();
            }
            try
            {
                await CategoriesRepository.PostCategories(categorie);
                return Ok(categorie);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        [HttpGet]
        [Route("GetCategories")]

        public async Task<ActionResult<List<Categorie>>> GetCategories()
        {
            var CategorieList = await CategoriesRepository.GetCategories();
            if (CategorieList == null)
            {
                throw new ArgumentNullException(nameof(CategorieList));
            }
            return Ok(CategorieList);
        }
        [HttpGet]
        [Route("GetById")]

        public ActionResult GetById(int id)
        {
            try
            {
                var categories = CategoriesRepository.GetById(id);
                return Ok(categories);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        [HttpPut]
        [Route("Update")]

        public async Task<ActionResult> Update(int id, Categorie categorie)
        {
            try
            {
                var categories_Upd = await CategoriesRepository.Update(id, categorie);
                return Ok(categories_Upd);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpDelete]
        [Route("DeletePerson")]

        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                return Ok(await CategoriesRepository.Delete(id));
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}

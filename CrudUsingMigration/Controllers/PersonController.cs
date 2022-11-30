using CrudUsingMigration.Context;
using CrudUsingMigration.Data;
using CrudUsingMigration.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace CrudUsingMigration.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly MainContext _mainContext;
    
    private IPersonRepository _personRepository;

        public PersonController(IPersonRepository personRepository, MainContext context)
        {
            _personRepository = personRepository;
            _mainContext = context;

        }


        // GET: api/[controller]
        [HttpGet]
        [Route("PersonsList")]
       
        public async Task< ActionResult<List<Person>>> GetValues(int pages)
        {
            try
            {
                var Persons =await _personRepository.Get(pages);
                var response = new PaginationClass
                {
                    Persons = Persons,
                    Pages = (int)Math.Ceiling(_mainContext.Persons.Count()/6f),
                    CurrentPages = pages,
                    TotalPerson = _mainContext.Persons.Count()
                };
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }[HttpGet]
        [Route("GetByIdPerson")]
       
        public ActionResult GetById(int id)
        {
            try
            {
                var Persons =_personRepository.GetById(id);
                return Ok(Persons);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        // POST: api/[controller]
        [HttpPost]
        [Route("AddPerson")]
       
        public async Task<ActionResult> Post([FromBody] Person person)
        {
            if (person == null)
            {
                return NotFound();
            }
            try
            {
               await _personRepository.Post(person);
                return Ok(person);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        [HttpPut]
        [Route("Update")]
      
        public async Task<ActionResult> Update(int id, Person person)
        {
            try
            {
                var Person_Upd=await _personRepository.Update(id, person);
                return Ok(person);
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
                return Ok(await _personRepository.Delete(id));
            }
            catch
            {
                return BadRequest();
            }
        }
        

       
    }
}

using CrudUsingMigration.Context;
using CrudUsingMigration.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CrudUsingMigration.Data
{
    public class PersonRepository : IPersonRepository
    {
        private readonly MainContext _mainContext;
        public PersonRepository(MainContext context)
        {
            _mainContext = context;
        }

        public async Task<List<Person>> Get(int page)
        {
            var pageResults = 6f;
            var pageCount = Math.Ceiling(_mainContext.Persons.Count() / pageResults);
            var person = await _mainContext.Persons
                .Skip((page - 1) * (int)pageResults).Take((int)pageResults).ToListAsync();
          /*  var response = new PaginationClass
            {
                Persons = person,
                CurrentPages = page,
                Pages = (int)pageCount,
                TotalPages = _mainContext.Persons.Count()
            };*/
             return person;
        }
        public IEnumerable<Person> GetById(int id)
        {

            var Persons = _mainContext.Persons.Find(id);
            yield return Persons;
        }

        public async Task<bool> Post(Person person)
        {
            if (person == null)
            {
                throw new ArgumentNullException(nameof(person));
            }

            await _mainContext.Persons.AddAsync(person);
            await _mainContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(int id, Person person)
        {
            if (person == null)
            {
                throw new ArgumentNullException(nameof(person));
            }
            else
            {
                Person entity = _mainContext.Persons.FirstOrDefault(e => e.Personid == id);
                if (entity != null)
                {
                    entity.personname = person.personname;
                    entity.personaddress = person.personaddress;
                    _mainContext.Attach(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                    await _mainContext.SaveChangesAsync();
                }
                return true;


            }
        }
        public async Task<bool> Delete(int id)
        {

            var Person = await _mainContext.Persons.FindAsync(id);

            _mainContext.Persons.Remove(Person);
            await _mainContext.SaveChangesAsync();

            return true;

        }
        
    }
}

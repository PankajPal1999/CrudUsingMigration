using CrudUsingMigration.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CrudUsingMigration.Data
{
    public interface IPersonRepository
    {
        Task<List<Person>> Get(int page);
        IEnumerable<Person> GetById(int id);
        Task<bool> Post(Person person);
        Task<bool> Update(int id,Person person);
        Task<bool> Delete(int id);

    }
}

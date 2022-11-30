namespace CrudUsingMigration.Models
{
    public class PaginationClass
    { 
        public List<Person> Persons { get; set; } = new List<Person>();

        public int Pages { get; set; }

        public int CurrentPages { get; set; }
        public int TotalPerson { get; set; }
    } 
}

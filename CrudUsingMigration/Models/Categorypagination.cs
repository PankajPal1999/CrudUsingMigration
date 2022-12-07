namespace CrudUsingMigration.Models
{
    public class Categorypagination
    {
        public List<Categorie> categories { get; set; } = new List<Categorie>();
        public int Pages { get; set; }

        public int CurrentPages { get; set; }
        public int TotalPerson { get; set; }
    }
}

namespace CrudUsingMigration.Models
{
    public class Person
    {
        public int Personid { get; set; }
        public string personname { get; set; }
        public string personaddress { get; set; }
        public User users { get; set; }

    }
}

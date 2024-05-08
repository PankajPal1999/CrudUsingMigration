using System.ComponentModel.DataAnnotations.Schema;

namespace CrudUsingMigration.Models
{
    public class User
    {
        public int Userid { get; set; }
        [ForeignKey("Person")]
        public int Personid { get; set; }
        public Person Person { get; set; }
        public string UserName { get; set; }
      //  public string Email { get; set; }
        public string Password { get; set; }
    }
}

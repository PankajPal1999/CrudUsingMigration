using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace CrudUsingMigration.Models
{
    [Index(nameof(Sequence), IsUnique = true, Name = "Sequence")]

    public class Categorie
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string BrandName { get; set; }
       
        public int Sequence { get; set; }

    }
}

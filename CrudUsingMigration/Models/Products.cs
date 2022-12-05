using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudUsingMigration.Models
{
    public class Products
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductTitle { get; set; }
        public string ProductDescription { get; set; }
        public string Price { get; set; }
        public string SellingPrice { get; set; }
        [Display(Name = "Category")]
        public virtual int CategoryId { get; set; }  

        [ForeignKey("CategoryId")]
        public virtual Categorie Categories { get; set; }
        
      
    }
}

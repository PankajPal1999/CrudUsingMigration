using System.Text.Json.Serialization;

namespace CrudUsingMigration.Models
{
    public class ProductDetailsClass
    {
       
        public int ProductId { get; set; }
        public string ProductDescription { get; set; }
        public string Price { get; set; }
        public string ProductTitle { get; set; }
        public string SellingPrice { get; set; }
        public int CategoryId { get; set; }

    }
}

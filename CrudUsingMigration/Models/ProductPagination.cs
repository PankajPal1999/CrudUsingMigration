namespace CrudUsingMigration.Models
{
    public class ProductPagination
    {
        public List<Products> productDetails { get; set; } = new List<Products>();
        public int Pages { get; set; }

        public int CurrentPages { get; set; }
        public int TotalPerson { get; set; }
    }
}

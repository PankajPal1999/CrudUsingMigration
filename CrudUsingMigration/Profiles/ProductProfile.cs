using AutoMapper;
using CrudUsingMigration.Models;

namespace CrudUsingMigration.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Products, ProductDetailsClass>().ReverseMap();
        }
    }
}

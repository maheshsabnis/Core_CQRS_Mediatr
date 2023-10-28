using AutoMapper;
using Core_CQRS_Mediatr.Models;
using Core_CQRS_Mediatr.ViewModels;

namespace Core_CQRS_Mediatr.Mapper
{
    public class ProductInfoProfile : Profile
    {
        public ProductInfoProfile()
        {
            CreateMap<ProductInfo, ProductInfoViewModel>().ReverseMap();
        }
    }
}

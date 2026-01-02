using AutoMapper;
using Product.MicroService.Domain.UseCases.ProductOperation.Base;
using Product.MicroService.Storage.Entities;

namespace Product.MicroService.Storage.Mapper;

public class ProductMetricsProfile : Profile
{
    public ProductMetricsProfile()
    {
        CreateMap<ProductMetrics, ProductMetricsModel>();
    }
}

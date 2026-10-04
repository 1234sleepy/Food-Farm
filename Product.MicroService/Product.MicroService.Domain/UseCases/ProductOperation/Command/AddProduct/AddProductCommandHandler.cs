using AutoMapper;
using FluentValidation;
using MediatR;
using Product.MicroService.Domain.Entities;
using Product.MicroService.Domain.UseCases.ProductOperation.Base;

namespace Product.MicroService.Domain.UseCases.ProductOperation.Command.AddProduct;

public class AddProductCommandHandler(IAddProductStorage productStorage, IMapper mapper) : IRequestHandler<AddProductCommand, ProductEntity>
{

    private readonly IAddProductStorage _productStorage = productStorage;
    private readonly IMapper _mapper = mapper;

    public async Task<ProductEntity> Handle(AddProductCommand request, CancellationToken cancellationToken)
    {
        var pr = _mapper.Map<ProductEntity>(request);

        return await _productStorage.AddProduct(pr, cancellationToken);
    }
}

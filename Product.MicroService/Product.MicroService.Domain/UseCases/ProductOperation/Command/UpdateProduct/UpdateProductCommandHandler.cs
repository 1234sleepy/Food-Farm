using AutoMapper;
using FluentValidation;
using MediatR;
using Product.MicroService.Domain.Entities;
using Product.MicroService.Domain.UseCases.ProductOperation.Base;
using Product.MicroService.Domain.UseCases.ProductOperation.Queris.GetProduct;

namespace Product.MicroService.Domain.UseCases.ProductOperation.Command.UpdateProduct;

public class UpdateProductCommandHandler(IUpdateProductStorage updateProduct, IMapper mapper) : IRequestHandler<UpdateProductCommand, ProductEntity>
{
    private readonly IMapper _mapper = mapper;
    private readonly IUpdateProductStorage _updateProduct = updateProduct;

    public async Task<ProductEntity> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var pr = _mapper.Map<ProductEntity>(request);

        return await _updateProduct.UpdateProduct(
                pr,
                cancellationToken);


    }
}

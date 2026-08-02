using AutoMapper;
using Cart.MicroService.Domain.UseCases.Base;
using Cart.MicroService.Domain.UseCases.UpdateCart;
using Cart.MicroService.Storage.Entities;


namespace Cart.MicroService.Storage.Storages;

public class UpdateCartStorage(DataContext dataContext, IMapper mapper) : IUpdateCartStorage
{
    private readonly DataContext _dataContext = dataContext;
    private readonly IMapper _mapper = mapper;

    public async Task<CartModel> UpdateCart(Guid UserId, Guid ProductId, int Quantity, CancellationToken cancellationToken)
    {
        CartEntity cart = new()
        {
            userId = UserId,
            productId = ProductId,
            quantity = Quantity
        };
        await _dataContext.Cart.AddAsync(cart);
        await _dataContext.SaveChangesAsync(cancellationToken);

        return _mapper.Map<CartModel>(cart);
    }
}

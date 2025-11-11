using MediatR;
using Product.MicroService.Domain.UseCases.ProductOperation.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.MicroService.Domain.UseCases.ProductOperation.Queris.GetProduct
{
    public class GetProductQueryHandler(IGetProductStorage getProductStorage) : IRequestHandler<GetProductQuery, ProductModel>
    {
        private readonly IGetProductStorage _getProductStorage = getProductStorage;

        public async Task<ProductModel> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            Console.WriteLine("GEETPRODUCTISWORKING");
            return await _getProductStorage.GetProduct(request.Id, cancellationToken);
        }
    }
}

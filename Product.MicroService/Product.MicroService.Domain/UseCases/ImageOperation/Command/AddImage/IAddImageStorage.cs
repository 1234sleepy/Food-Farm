using Product.MicroService.Domain.UseCases.ProductOperation.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.MicroService.Domain.UseCases.ImageOperation.Command.AddImage
{
    public interface IAddImageStorage
    {
        public Task<ImageModel> AddImage(Guid productId, string FileName, CancellationToken cancellationToken);
    }
}

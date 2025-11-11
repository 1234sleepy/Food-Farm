using Product.MicroService.Domain.UseCases.ProductOperation.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.MicroService.Domain.UseCases.Label.Base
{
    public class ProductLableModel
    {
        public Guid ProductId { get; set; }
        public ProductModel? Product { get; set; }
        public Guid LabelId { get; set; }
        public LabelModel? Label { get; set; }
    }
}

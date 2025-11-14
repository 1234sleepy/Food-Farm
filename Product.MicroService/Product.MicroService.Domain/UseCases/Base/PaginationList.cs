using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.MicroService.Domain.UseCases.Base;

public class PaginationList<T>
{
    public required List<T> List { get; set; }

    public int TotalCount { get; set; }
}

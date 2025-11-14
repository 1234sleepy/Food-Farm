using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.MicroService.Domain.UseCases.Base;

public record class PaginationQuery()
{

    public int Page { get; set; }
    public int ItemPerPage { get; set; }
}

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale
{
    public sealed record UpdateSaleItemCommand(string ProductName, int Quantity, decimal UnitPrice);
    public sealed record UpdateSaleCommand(
        Guid Id,
        DateTime SaleDate,
        string CustomerName,
        string Branch,
        IReadOnlyCollection<UpdateSaleItemCommand> Items
    ) : IRequest<SaleDto>;
}

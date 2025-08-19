using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale
{
    public sealed record UpdateSaleItemRequest(string ProductName, int Quantity, decimal UnitPrice);
    public sealed record UpdateSaleRequest(
        DateTime SaleDate,
        string CustomerName,
        string Branch,
        IReadOnlyCollection<UpdateSaleItemRequest> Items);
}

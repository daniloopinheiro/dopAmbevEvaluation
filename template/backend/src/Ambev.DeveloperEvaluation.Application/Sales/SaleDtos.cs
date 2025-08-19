using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Sales
{
    public sealed record SaleItemDto(
    Guid Id,
    string ProductName,
    int Quantity,
    decimal UnitPrice,
    decimal Discount,
    decimal Total);

    public sealed record SaleDto(
        Guid Id,
        string SaleNumber,
        DateTime SaleDate,
        string CustomerName,
        string Branch,
        decimal TotalAmount,
        int Status,
        IReadOnlyCollection<SaleItemDto> Items);
}

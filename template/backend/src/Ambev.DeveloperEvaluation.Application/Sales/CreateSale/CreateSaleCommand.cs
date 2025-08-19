using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    public sealed record CreateSaleItemCommand(string ProductName, int Quantity, decimal UnitPrice);
    public sealed record CreateSaleCommand(
        string SaleNumber,
        DateTime SaleDate,
        string CustomerName,
        string Branch,
        IReadOnlyCollection<CreateSaleItemCommand> Items
    ) : IRequest<SaleDto>;
}

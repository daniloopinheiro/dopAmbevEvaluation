namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{
    public sealed record CreateSaleItemRequest(string ProductName, int Quantity, decimal UnitPrice);
    public sealed record CreateSaleRequest(
        string SaleNumber,
        DateTime SaleDate,
        string CustomerName,
        string Branch,
        IReadOnlyCollection<CreateSaleItemRequest> Items);
}

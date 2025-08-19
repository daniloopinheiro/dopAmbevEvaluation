namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale
{
    public sealed record UpdateSaleItemRequest(string ProductName, int Quantity, decimal UnitPrice);
    public sealed record UpdateSaleRequest(
        DateTime SaleDate,
        string CustomerName,
        string Branch,
        IReadOnlyCollection<UpdateSaleItemRequest> Items);
}

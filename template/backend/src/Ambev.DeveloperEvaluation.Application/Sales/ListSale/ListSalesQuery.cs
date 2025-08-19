using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.ListSale
{
    public sealed record ListSalesQuery(
    int Page = 1,
    int PageSize = 20,
    string? SaleNumber = null,
    string? CustomerName = null,
    string? Branch = null,
    int? Status = null,
    DateTime? From = null,
    DateTime? To = null
) : IRequest<(IReadOnlyCollection<SaleDto> Data, int Total)>;
}

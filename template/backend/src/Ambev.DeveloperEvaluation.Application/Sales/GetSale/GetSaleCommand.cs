using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.Get
{
    public sealed record GetSaleCommand(Guid Id) : IRequest<SaleDto>;
}

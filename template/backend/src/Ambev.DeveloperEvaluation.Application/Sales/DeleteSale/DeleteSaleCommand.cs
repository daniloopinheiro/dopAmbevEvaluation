﻿using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.DeleteSale
{
    public sealed record DeleteSaleCommand(Guid Id) : IRequest<bool>;
}

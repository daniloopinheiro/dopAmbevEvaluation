using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    public class CreateSaleHandler : IRequestHandler<CreateSaleCommand, SaleDto>
    {
        private readonly ISaleRepository _repo;
        private readonly IMapper _mapper;

        public CreateSaleHandler(ISaleRepository repo, IMapper mapper)
        {
            _repo = repo; _mapper = mapper;
        }

        public async Task<SaleDto> Handle(CreateSaleCommand request, CancellationToken ct)
        {
            var exists = await _repo.GetByNumberAsync(request.SaleNumber, ct);
            if (exists is not null)
                throw new InvalidOperationException("Já existe uma venda com esse número.");

            var sale = new Sale(request.SaleNumber, request.SaleDate, request.CustomerName, request.Branch);

            foreach (var it in request.Items)
                sale.AddItem(it.ProductName, it.Quantity, it.UnitPrice); // regra de desconto aplicada dentro do Domain

            await _repo.AddAsync(sale, ct);
            return _mapper.Map<SaleDto>(sale);
        }
    }
}

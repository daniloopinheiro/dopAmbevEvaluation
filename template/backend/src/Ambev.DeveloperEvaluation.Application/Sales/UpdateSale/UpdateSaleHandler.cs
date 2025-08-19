using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale
{
    public class UpdateSaleHandler : IRequestHandler<UpdateSaleCommand, SaleDto>
    {
        private readonly ISaleRepository _repo;
        private readonly IMapper _mapper;
        public UpdateSaleHandler(ISaleRepository repo, IMapper mapper)
        {
            _repo = repo; _mapper = mapper;
        }

        public async Task<SaleDto> Handle(UpdateSaleCommand request, CancellationToken ct)
        {
            var sale = await _repo.GetByIdAsync(request.Id, ct)
                       ?? throw new KeyNotFoundException("Venda não encontrada.");

            sale.UpdateHeader(request.CustomerName, request.Branch, request.SaleDate);

            var rebuilt = request.Items.Select(i => new SaleItem(i.ProductName, i.Quantity, i.UnitPrice)).ToList();
            sale.ReplaceItems(rebuilt);

            await _repo.UpdateAsync(sale, ct);
            return _mapper.Map<SaleDto>(sale);
        }
    }
}

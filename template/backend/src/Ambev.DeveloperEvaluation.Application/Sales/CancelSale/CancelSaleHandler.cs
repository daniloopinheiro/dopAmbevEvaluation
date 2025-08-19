using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CancelSale
{
    public class CancelSaleHandler : IRequestHandler<CancelSaleCommand, SaleDto>
    {
        private readonly ISaleRepository _repo; private readonly IMapper _mapper;
        public CancelSaleHandler(ISaleRepository repo, IMapper mapper) { _repo = repo; _mapper = mapper; }

        public async Task<SaleDto> Handle(CancelSaleCommand request, CancellationToken ct)
        {
            var sale = await _repo.GetByIdAsync(request.Id, ct)
                       ?? throw new KeyNotFoundException("Venda não encontrada.");
            sale.Cancel();
            await _repo.UpdateAsync(sale, ct);
            return _mapper.Map<SaleDto>(sale);
        }
    }
}

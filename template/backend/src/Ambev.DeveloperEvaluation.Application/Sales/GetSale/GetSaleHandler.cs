using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.Get
{
    public class GetSaleHandler : IRequestHandler<GetSaleCommand, SaleDto>
    {
        private readonly ISaleRepository _repo; private readonly IMapper _mapper;
        public GetSaleHandler(ISaleRepository repo, IMapper mapper) { _repo = repo; _mapper = mapper; }

        public async Task<SaleDto> Handle(GetSaleCommand request, CancellationToken ct)
        {
            var sale = await _repo.GetByIdAsync(request.Id, ct)
                       ?? throw new KeyNotFoundException("Venda não encontrada.");
            return _mapper.Map<SaleDto>(sale);
        }
    }
}

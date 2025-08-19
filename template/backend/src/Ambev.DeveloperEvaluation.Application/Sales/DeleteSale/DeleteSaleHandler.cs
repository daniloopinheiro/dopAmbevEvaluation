using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.DeleteSale
{
    public class DeleteSaleHandler : IRequestHandler<DeleteSaleCommand, bool>
    {
        private readonly ISaleRepository _repo;
        public DeleteSaleHandler(ISaleRepository repo) => _repo = repo;

        public async Task<bool> Handle(DeleteSaleCommand request, CancellationToken ct)
        {
            var sale = await _repo.GetByIdAsync(request.Id, ct)
                       ?? throw new KeyNotFoundException("Venda não encontrada.");
            await _repo.DeleteAsync(sale, ct);
            return true;
        }
    }
}

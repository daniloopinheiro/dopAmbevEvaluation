using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface ISaleRepository
    {
        Task<Sale?> GetByIdAsync(Guid id, CancellationToken ct);
        Task<Sale?> GetByNumberAsync(string saleNumber, CancellationToken ct);
        Task AddAsync(Sale sale, CancellationToken ct);
        Task UpdateAsync(Sale sale, CancellationToken ct);
        Task DeleteAsync(Sale sale, CancellationToken ct);
        IQueryable<Sale> Query();
    }
}

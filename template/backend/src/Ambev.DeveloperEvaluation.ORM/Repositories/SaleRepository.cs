using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        private readonly DefaultContext _ctx;
        public SaleRepository(DefaultContext ctx) => _ctx = ctx;

        public Task<Sale?> GetByIdAsync(Guid id, CancellationToken ct) =>
            _ctx.Sales.Include("_items").FirstOrDefaultAsync(x => x.Id == id, ct);

        public Task<Sale?> GetByNumberAsync(string saleNumber, CancellationToken ct) =>
            _ctx.Sales.Include("_items").FirstOrDefaultAsync(x => x.SaleNumber == saleNumber, ct);

        public async Task AddAsync(Sale sale, CancellationToken ct)
        {
            _ctx.Sales.Add(sale);
            await _ctx.SaveChangesAsync(ct);
        }

        public async Task UpdateAsync(Sale sale, CancellationToken ct)
        {
            _ctx.Sales.Update(sale);
            await _ctx.SaveChangesAsync(ct);
        }

        public async Task DeleteAsync(Sale sale, CancellationToken ct)
        {
            _ctx.Sales.Remove(sale);
            await _ctx.SaveChangesAsync(ct);
        }

        public IQueryable<Sale> Query() => _ctx.Sales.Include("_items").AsNoTracking();
    }
}

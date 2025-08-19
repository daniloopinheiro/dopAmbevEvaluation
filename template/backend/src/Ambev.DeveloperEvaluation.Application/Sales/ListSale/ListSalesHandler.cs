using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.Application.Sales.ListSale
{
    public class ListSalesHandler : IRequestHandler<ListSalesQuery, (IReadOnlyCollection<SaleDto>, int)>
    {
        private readonly ISaleRepository _repo; private readonly IMapper _mapper;
        public ListSalesHandler(ISaleRepository repo, IMapper mapper) { _repo = repo; _mapper = mapper; }

        public async Task<(IReadOnlyCollection<SaleDto>, int)> Handle(ListSalesQuery q, CancellationToken ct)
        {
            var query = _repo.Query();

            if (!string.IsNullOrWhiteSpace(q.SaleNumber)) query = query.Where(x => x.SaleNumber == q.SaleNumber);
            if (!string.IsNullOrWhiteSpace(q.CustomerName))
                query = query.Where(x => EF.Functions.Like(x.CustomerName, $"%{q.CustomerName}%"));
            if (!string.IsNullOrWhiteSpace(q.Branch)) query = query.Where(x => x.Branch == q.Branch);
            if (q.Status.HasValue) query = query.Where(x => (int)x.Status == q.Status.Value);
            if (q.From.HasValue) query = query.Where(x => x.SaleDate >= q.From.Value);
            if (q.To.HasValue) query = query.Where(x => x.SaleDate <= q.To.Value);

            var total = await query.CountAsync(ct);
            var data = await query.OrderByDescending(x => x.SaleDate)
                .Skip((q.Page - 1) * q.PageSize).Take(q.PageSize)
                .ProjectTo<SaleDto>(_mapper.ConfigurationProvider)
                .ToListAsync(ct);

            return (data, total);
        }
    }
}

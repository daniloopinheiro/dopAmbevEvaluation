using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sales
{
    public class SaleProfiles : Profile
    {
        public SaleProfiles()
        {
            CreateMap<SaleItem, SaleItemDto>();
            CreateMap<Sale, SaleDto>()
                .ForMember(d => d.Items, cfg => cfg.MapFrom(s => s.Items))
                .ForMember(d => d.Status, cfg => cfg.MapFrom(s => (int)s.Status));
        }
    }
}

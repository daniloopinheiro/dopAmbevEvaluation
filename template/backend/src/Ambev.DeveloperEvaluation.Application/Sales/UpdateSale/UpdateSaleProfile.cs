using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale
{
    public class UpdateSaleProfile : Profile
    {
        public UpdateSaleProfile()
        {
            CreateMap<UpdateSaleItemRequest, UpdateSaleItemCommand>();
            CreateMap<UpdateSaleRequest, UpdateSaleCommand>();
        }
    }
}

using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale
{
    public class UpdateSaleValidator : AbstractValidator<UpdateSaleCommand>
    {
        public UpdateSaleValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.SaleDate).LessThanOrEqualTo(DateTime.UtcNow.AddDays(1));
            RuleFor(x => x.CustomerName).NotEmpty().MaximumLength(200);
            RuleFor(x => x.Branch).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Items).NotEmpty();

            RuleForEach(x => x.Items).ChildRules(i =>
            {
                i.RuleFor(s => s.ProductName).NotEmpty().MaximumLength(200);
                i.RuleFor(s => s.Quantity).GreaterThan(0).LessThanOrEqualTo(20);
                i.RuleFor(s => s.UnitPrice).GreaterThanOrEqualTo(0);
            });
        }
    }
}

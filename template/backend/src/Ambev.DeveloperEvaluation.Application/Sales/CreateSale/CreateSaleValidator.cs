using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    public class CreateSaleValidator : AbstractValidator<CreateSaleCommand>
    {
        public CreateSaleValidator()
        {
            RuleFor(x => x.SaleNumber).NotEmpty().MaximumLength(40);
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

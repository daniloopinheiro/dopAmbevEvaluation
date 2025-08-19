using Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;
using FluentValidation.TestHelper;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application.Validators
{
    public class UpdateSaleValidatorTests
    {
        private readonly UpdateSaleValidator _validator = new();

        [Fact]
        public void Deve_Passar_Validacao_Quando_Comando_Valido()
        {
            var cmd = new UpdateSaleCommand(
                Guid.NewGuid(),
                DateTime.UtcNow,
                "Cliente A",
                "Filial X",
                new List<UpdateSaleItemCommand> { new("Produto A", 5, 10m) }
            );

            var result = _validator.TestValidate(cmd);
            result.ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public void Deve_Falhar_Quando_IdVazio()
        {
            var cmd = new UpdateSaleCommand(
                Guid.Empty,
                DateTime.UtcNow,
                "Cliente A",
                "Filial X",
                new List<UpdateSaleItemCommand> { new("Produto A", 5, 10m) }
            );

            var result = _validator.TestValidate(cmd);
            result.ShouldHaveValidationErrorFor(x => x.Id);
        }

        [Fact]
        public void Deve_Falhar_Quando_ClienteVazio()
        {
            var cmd = new UpdateSaleCommand(
                Guid.NewGuid(),
                DateTime.UtcNow,
                "",
                "Filial X",
                new List<UpdateSaleItemCommand> { new("Produto A", 5, 10m) }
            );

            var result = _validator.TestValidate(cmd);
            result.ShouldHaveValidationErrorFor(x => x.CustomerName);
        }

        [Fact]
        public void Deve_Falhar_Quando_ItemComPrecoNegativo()
        {
            var cmd = new UpdateSaleCommand(
                Guid.NewGuid(),
                DateTime.UtcNow,
                "Cliente A",
                "Filial X",
                new List<UpdateSaleItemCommand> { new("Produto A", 5, -10m) }
            );

            var result = _validator.TestValidate(cmd);
            result.ShouldHaveValidationErrorFor("Items[0].UnitPrice");
        }
    }
}

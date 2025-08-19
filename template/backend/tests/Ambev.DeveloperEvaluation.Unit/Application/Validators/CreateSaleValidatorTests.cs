using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using FluentValidation.TestHelper;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application.Validators
{
    public class CreateSaleValidatorTests
    {
        private readonly CreateSaleValidator _validator = new();

        [Fact]
        public void Deve_Passar_Validacao_Quando_Comando_Valido()
        {
            var cmd = new CreateSaleCommand(
                "V001",
                DateTime.UtcNow,
                "Cliente A",
                "Filial X",
                new List<CreateSaleItemCommand> { new("Produto A", 5, 10m) }
            );

            var result = _validator.TestValidate(cmd);
            result.ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public void Deve_Falhar_Quando_NumeroVendaVazio()
        {
            var cmd = new CreateSaleCommand(
                "",
                DateTime.UtcNow,
                "Cliente A",
                "Filial X",
                new List<CreateSaleItemCommand> { new("Produto A", 5, 10m) }
            );

            var result = _validator.TestValidate(cmd);
            result.ShouldHaveValidationErrorFor(x => x.SaleNumber);
        }

        [Fact]
        public void Deve_Falhar_Quando_ItemSemNome()
        {
            var cmd = new CreateSaleCommand(
                "V001",
                DateTime.UtcNow,
                "Cliente A",
                "Filial X",
                new List<CreateSaleItemCommand> { new("", 5, 10m) }
            );

            var result = _validator.TestValidate(cmd);
            result.ShouldHaveAnyValidationError();
        }

        [Fact]
        public void Deve_Falhar_Quando_ItemComQuantidadeZero()
        {
            var cmd = new CreateSaleCommand(
                "V001",
                DateTime.UtcNow,
                "Cliente A",
                "Filial X",
                new List<CreateSaleItemCommand> { new("Produto A", 0, 10m) }
            );

            var result = _validator.TestValidate(cmd);
            result.ShouldHaveValidationErrorFor("Items[0].Quantity");
        }
    }
}

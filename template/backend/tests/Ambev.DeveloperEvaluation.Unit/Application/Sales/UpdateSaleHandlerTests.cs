using Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using FluentAssertions;
using Moq;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application.Sales
{
    //public class UpdateSaleHandlerTests
    //{
    //    private readonly Mock<ISaleRepository> _saleRepositoryMock;
    //    private readonly UpdateSaleHandler _handler;

    //    public UpdateSaleHandlerTests()
    //    {
    //        _saleRepositoryMock = new Mock<ISaleRepository>();
    //        _handler = new UpdateSaleHandler(_saleRepositoryMock.Object);
    //    }

    //    [Fact(DisplayName = "Deve atualizar uma venda existente")]
    //    public async Task Handle_ShouldUpdateSale_WhenSaleExists()
    //    {
    //        // Arrange
    //        var saleId = Guid.NewGuid();
    //        var sale = new Sale(saleId, "Cliente Antigo", "Filial Antiga", DateTime.UtcNow);

    //        _saleRepositoryMock.Setup(r => r.GetByIdAsync(saleId))
    //                           .ReturnsAsync(sale);

    //        _saleRepositoryMock.Setup(r => r.UpdateAsync(sale))
    //                           .ReturnsAsync(sale);

    //        var command = new UpdateSaleCommand(
    //            saleId,
    //            "Cliente Atualizado",
    //            "Filial Nova",
    //            DateTime.UtcNow
    //        );

    //        // Act
    //        var result = await _handler.Handle(command, CancellationToken.None);

    //        // Assert
    //        result.Should().NotBeNull();
    //        result.Client.Should().Be("Cliente Atualizado");
    //        result.Branch.Should().Be("Filial Nova");

    //        _saleRepositoryMock.Verify(r => r.UpdateAsync(sale), Times.Once);
    //    }

    //    [Fact(DisplayName = "Não deve atualizar venda inexistente")]
    //    public async Task Handle_ShouldThrow_WhenSaleDoesNotExist()
    //    {
    //        // Arrange
    //        var saleId = Guid.NewGuid();

    //        _saleRepositoryMock.Setup(r => r.GetByIdAsync(saleId))
    //                           .ReturnsAsync((Sale)null);

    //        var command = new UpdateSaleCommand(
    //            saleId,
    //            "Cliente Atualizado",
    //            "Filial Nova",
    //            DateTime.UtcNow
    //        );

    //        // Act
    //        Func<Task> act = async () => await _handler.Handle(command, CancellationToken.None);

    //        // Assert
    //        await act.Should().ThrowAsync<ArgumentException>()
    //            .WithMessage("Venda não encontrada*");

    //        _saleRepositoryMock.Verify(r => r.UpdateAsync(It.IsAny<Sale>()), Times.Never);
    //    }
    //}
}

using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Moq;

namespace Ambev.DeveloperEvaluation.Unit.Application.Sales
{
    //public class CreateSaleHandlerTests
    //{
    //    private readonly Mock<ISaleRepository> _saleRepositoryMock;
    //    private readonly CreateSaleHandler _handler;

    //    public CreateSaleHandlerTests()
    //    {
    //        _saleRepositoryMock = new Mock<ISaleRepository>();
    //        _handler = new CreateSaleHandler(_saleRepositoryMock.Object);
    //    }

    //    [Fact(DisplayName = "Deve criar uma venda com sucesso")]
    //    public async Task Handle_ShouldCreateSale_WhenCommandIsValid()
    //    {
    //        // Arrange
    //        var command = new CreateSaleCommand(
    //            client: "Cliente Teste",
    //            branch: "Filial Centro",
    //            saleDate: DateTime.UtcNow,
    //            items: new[]
    //            {
    //                new CreateSaleItemDto("Produto A", 2, 10.0m, 0),
    //                new CreateSaleItemDto("Produto B", 1, 20.0m, 5.0m)
    //            }
    //        );

    //        _saleRepositoryMock
    //            .Setup(r => r.AddAsync(It.IsAny<Sale>()))
    //            .ReturnsAsync((Sale sale) => sale);

    //        // Act
    //        var result = await _handler.Handle(command, CancellationToken.None);

    //        // Assert
    //        result.Should().NotBeNull();
    //        result.Client.Should().Be("Cliente Teste");
    //        result.Items.Should().HaveCount(2);
    //        result.TotalValue.Should().Be(35.0m);

    //        _saleRepositoryMock.Verify(r => r.AddAsync(It.IsAny<Sale>()), Times.Once);
    //    }

    //    [Fact(DisplayName = "Não deve criar venda quando não houver itens")]
    //    public async Task Handle_ShouldThrow_WhenNoItems()
    //    {
    //        // Arrange
    //        var command = new CreateSaleCommand(
    //            client: "Cliente Teste",
    //            branch: "Filial Centro",
    //            saleDate: DateTime.UtcNow,
    //            items: Array.Empty<CreateSaleItemDto>()
    //        );

    //        // Act
    //        Func<Task> act = async () => await _handler.Handle(command, CancellationToken.None);

    //        // Assert
    //        await act.Should().ThrowAsync<ArgumentException>()
    //            .WithMessage("Uma venda deve conter pelo menos um item*");

    //        _saleRepositoryMock.Verify(r => r.AddAsync(It.IsAny<Sale>()), Times.Never);
    //    }
    //}
}

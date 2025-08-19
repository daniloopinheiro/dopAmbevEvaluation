using Ambev.DeveloperEvaluation.Application.Sales.Get;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using FluentAssertions;
using Moq;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application.Sales
{
    //public class GetSaleHandlerTests
    //{
    //    private readonly Mock<ISaleRepository> _saleRepositoryMock;
    //    private readonly GetSaleHandler _handler;

    //    public GetSaleHandlerTests()
    //    {
    //        _saleRepositoryMock = new Mock<ISaleRepository>();
    //        _handler = new GetSaleHandler(_saleRepositoryMock.Object);
    //    }

    //    [Fact(DisplayName = "Deve retornar uma venda existente")]
    //    public async Task Handle_ShouldReturnSale_WhenSaleExists()
    //    {
    //        // Arrange
    //        var saleId = Guid.NewGuid();
    //        var sale = new Sale(saleId, "Cliente Teste", "Filial X", DateTime.UtcNow);

    //        _saleRepositoryMock.Setup(r => r.GetByIdAsync(saleId))
    //                           .ReturnsAsync(sale);

    //        var query = new GetSaleQuery(saleId);

    //        // Act
    //        var result = await _handler.Handle(query, CancellationToken.None);

    //        // Assert
    //        result.Should().NotBeNull();
    //        result.Id.Should().Be(saleId);
    //        result.Client.Should().Be("Cliente Teste");
    //    }

    //    [Fact(DisplayName = "Não deve retornar venda inexistente")]
    //    public async Task Handle_ShouldThrow_WhenSaleDoesNotExist()
    //    {
    //        // Arrange
    //        var saleId = Guid.NewGuid();

    //        _saleRepositoryMock.Setup(r => r.GetByIdAsync(saleId))
    //                           .ReturnsAsync((Sale)null);

    //        var query = new GetSaleQuery(saleId);

    //        // Act
    //        Func<Task> act = async () => await _handler.Handle(query, CancellationToken.None);

    //        // Assert
    //        await act.Should().ThrowAsync<ArgumentException>()
    //            .WithMessage("Venda não encontrada*");
    //    }
    //}
}

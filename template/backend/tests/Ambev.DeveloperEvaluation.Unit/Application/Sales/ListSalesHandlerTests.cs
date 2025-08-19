using Ambev.DeveloperEvaluation.Application.Sales.ListSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application.Sales
{
    //public class ListSalesHandlerTests
    //{
    //    private readonly Mock<ISaleRepository> _saleRepositoryMock;
    //    private readonly ListSalesHandler _handler;

    //    public ListSalesHandlerTests()
    //    {
    //        _saleRepositoryMock = new Mock<ISaleRepository>();
    //        _handler = new ListSalesHandler(_saleRepositoryMock.Object);
    //    }

    //    [Fact(DisplayName = "Deve listar vendas existentes")]
    //    public async Task Handle_ShouldReturnSales_WhenSalesExist()
    //    {
    //        // Arrange
    //        var sales = new List<Sale>
    //        {
    //            new Sale(Guid.NewGuid(), "Cliente A", "Filial 1", DateTime.UtcNow),
    //            new Sale(Guid.NewGuid(), "Cliente B", "Filial 2", DateTime.UtcNow)
    //        };

    //        _saleRepositoryMock.Setup(r => r.GetAllAsync())
    //                           .ReturnsAsync(sales);

    //        var query = new ListSalesQuery();

    //        // Act
    //        var result = await _handler.Handle(query, CancellationToken.None);

    //        // Assert
    //        result.Should().NotBeNull();
    //        result.Should().HaveCount(2);
    //    }

    //    [Fact(DisplayName = "Deve retornar lista vazia quando não houver vendas")]
    //    public async Task Handle_ShouldReturnEmptyList_WhenNoSalesExist()
    //    {
    //        // Arrange
    //        _saleRepositoryMock.Setup(r => r.GetAllAsync())
    //                           .ReturnsAsync(new List<Sale>());

    //        var query = new ListSalesQuery();

    //        // Act
    //        var result = await _handler.Handle(query, CancellationToken.None);

    //        // Assert
    //        result.Should().BeEmpty();
    //    }
    //}
}

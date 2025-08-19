using Ambev.DeveloperEvaluation.Application.Sales;
using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using Moq;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application.Sales
{
    public class CreateSaleHandlerTests
    {
        private readonly Mock<ISaleRepository> _repoMock;
        private readonly IMapper _mapper;

        public CreateSaleHandlerTests()
        {
            _repoMock = new Mock<ISaleRepository>();

            var config = new MapperConfiguration(cfg => cfg.AddProfile<SaleProfiles>());
            _mapper = config.CreateMapper();
        }

        [Fact]
        public async Task CriarVenda_ComSucesso()
        {
            // Arrange
            var handler = new CreateSaleHandler(_repoMock.Object, _mapper);

            var command = new CreateSaleCommand(
                "V001", DateTime.UtcNow, "Cliente A", "Filial X",
                new List<CreateSaleItemCommand> { new("Produto A", 5, 10m) }
            );

            _repoMock.Setup(r => r.GetByNumberAsync("V001", It.IsAny<CancellationToken>()))
                     .ReturnsAsync((Sale?)null);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.Equal("V001", result.SaleNumber);
            Assert.Single(result.Items);
            Assert.Equal(45m, result.TotalAmount); // 5 * 10 - 10%
            _repoMock.Verify(r => r.AddAsync(It.IsAny<Sale>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task CriarVenda_ComNumeroDuplicado_DisparaExcecao()
        {
            var handler = new CreateSaleHandler(_repoMock.Object, _mapper);

            var command = new CreateSaleCommand(
                "V001", DateTime.UtcNow, "Cliente A", "Filial X",
                new List<CreateSaleItemCommand> { new("Produto A", 5, 10m) }
            );

            _repoMock.Setup(r => r.GetByNumberAsync("V001", It.IsAny<CancellationToken>()))
                     .ReturnsAsync(new Sale("V001", DateTime.UtcNow, "Cliente A", "Filial X"));

            await Assert.ThrowsAsync<InvalidOperationException>(() => handler.Handle(command, CancellationToken.None));
        }
    }
}

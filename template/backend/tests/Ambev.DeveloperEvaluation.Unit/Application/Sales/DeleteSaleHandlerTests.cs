using Ambev.DeveloperEvaluation.Application.Sales.DeleteSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using FluentAssertions;
using Moq;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application.Sales
{
    public class DeleteSaleHandlerTests
    {
        private readonly Mock<ISaleRepository> _saleRepositoryMock;
        private readonly DeleteSaleHandler _handler;

        public DeleteSaleHandlerTests()
        {
            _saleRepositoryMock = new Mock<ISaleRepository>();
            _handler = new DeleteSaleHandler(_saleRepositoryMock.Object);
        }

        [Fact(DisplayName = "Deve deletar uma venda existente")]
        public async Task Handle_ShouldDeleteSale_WhenSaleExists()
        {
            // Arrange
            var saleId = Guid.NewGuid();
            var sale = new Sale(saleId, "Cliente", "Filial", DateTime.UtcNow);

            _saleRepositoryMock.Setup(r => r.GetByIdAsync(saleId))
                               .ReturnsAsync(sale);

            _saleRepositoryMock.Setup(r => r.DeleteAsync(sale))
                               .Returns(Task.CompletedTask);

            var command = new DeleteSaleCommand(saleId);

            // Act
            await _handler.Handle(command, CancellationToken.None);

            // Assert
            _saleRepositoryMock.Verify(r => r.DeleteAsync(sale), Times.Once);
        }

        [Fact(DisplayName = "Não deve deletar venda inexistente")]
        public async Task Handle_ShouldThrow_WhenSaleDoesNotExist()
        {
            // Arrange
            var saleId = Guid.NewGuid();

            _saleRepositoryMock.Setup(r => r.GetByIdAsync(saleId))
                               .ReturnsAsync((Sale)null);

            var command = new DeleteSaleCommand(saleId);

            // Act
            Func<Task> act = async () => await _handler.Handle(command, CancellationToken.None);

            // Assert
            await act.Should().ThrowAsync<ArgumentException>()
                .WithMessage("Venda não encontrada*");

            _saleRepositoryMock.Verify(r => r.DeleteAsync(It.IsAny<Sale>()), Times.Never);
        }
    }
}

using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities
{
    public class SaleTests
    {
        [Fact]
        public void CreateSale_WithValidData_ShouldSucceed()
        {
            var sale = new Sale("S123", DateTime.Today, "Cliente Teste", "Filial A");

            Assert.Equal("S123", sale.SaleNumber);
            Assert.Equal("Cliente Teste", sale.CustomerName);
            Assert.Equal("Filial A", sale.Branch);
            Assert.Equal(SaleStatus.NotCancelled, sale.Status);
            Assert.Empty(sale.Items);
        }

        [Fact]
        public void AddItem_ShouldUpdateTotalAmount()
        {
            var sale = new Sale("S123", DateTime.Today, "Cliente Teste", "Filial A");
            sale.AddItem("Produto 1", 10, 10m); // aplica 20% de desconto

            Assert.Single(sale.Items);
            Assert.Equal(80m, sale.TotalAmount); // 100 - 20% = 80
        }

        [Fact]
        public void CancelSale_ShouldSetStatusToCancelled()
        {
            var sale = new Sale("S123", DateTime.Today, "Cliente Teste", "Filial A");
            sale.Cancel();

            Assert.Equal(SaleStatus.Cancelled, sale.Status);
        }

        [Fact]
        public void ReplaceItems_ShouldClearAndAddNewItems()
        {
            var sale = new Sale("S123", DateTime.Today, "Cliente Teste", "Filial A");
            var item1 = new SaleItem("Produto 1", 5, 10m);
            var item2 = new SaleItem("Produto 2", 2, 20m);

            sale.ReplaceItems(new[] { item1, item2 });

            Assert.Equal(2, sale.Items.Count);
            Assert.Equal(sale.TotalAmount, item1.Total + item2.Total);
        }
    }
}

using Ambev.DeveloperEvaluation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities
{
    public class SaleItemTests
    {
        [Fact]
        public void CreateSaleItem_ShouldCalculateDiscountsCorrectly()
        {
            var item = new SaleItem("Produto 1", 10, 10m); // 20% de desconto
            Assert.Equal(20m, item.Discount); // 100 * 0.2
            Assert.Equal(80m, item.Total);
        }

        [Fact]
        public void CreateSaleItem_WithQuantityAboveLimit_ShouldThrowException()
        {
            Assert.Throws<DomainException>(() => new SaleItem("Produto", 25, 10m));
        }

        [Fact]
        public void CreateSaleItem_WithNegativePrice_ShouldThrowException()
        {
            Assert.Throws<DomainException>(() => new SaleItem("Produto", 5, -1m));
        }

        [Fact]
        public void Update_ShouldApplyChangesCorrectly()
        {
            var item = new SaleItem("Produto", 5, 10m);
            item.Update("Novo Produto", 4, 20m);

            Assert.Equal("Novo Produto", item.ProductName);
            Assert.Equal(4, item.Quantity);
            Assert.Equal(20m, item.UnitPrice);
        }
    }
}

using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class SaleItem : BaseEntity
    {
        public Guid SaleId { get; private set; }
        public string ProductName { get; private set; } = default!;
        public int Quantity { get; private set; }
        public decimal UnitPrice { get; private set; }
        public decimal Discount { get; private set; }
        public decimal Total { get; private set; }

        private const int MaxPerProduct = 20;

        private SaleItem() { }

        public SaleItem(string productName, int quantity, decimal unitPrice)
        {
            Set(productName, quantity, unitPrice);
        }

        private void Set(string productName, int quantity, decimal unitPrice)
        {
            if (string.IsNullOrWhiteSpace(productName))
                throw new DomainException("Nome do produto é obrigatório.");

            if (quantity <= 0)
                throw new DomainException("Quantidade deve ser maior que zero.");

            if (quantity > MaxPerProduct)
                throw new DomainException("Limite máximo por produto é 20 itens.");

            if (unitPrice < 0)
                throw new DomainException("Preço unitário inválido.");

            ProductName = productName.Trim();
            Quantity = quantity;
            UnitPrice = unitPrice;

            ApplyDiscountRules();
            RecalcTotals();
        }

        public void Update(string productName, int quantity, decimal unitPrice) =>
        Set(productName, quantity, unitPrice);

        private void ApplyDiscountRules()
        {
            // 🎯 Regras:
            // <4 itens => 0%
            // 4..9 itens => 10%
            // 10..20 itens => 20%
            decimal percent =
                Quantity >= 10 ? 0.20m :
                Quantity >= 4 ? 0.10m : 0m;

            Discount = Quantity * UnitPrice * percent;
        }

        private void RecalcTotals()
        {
            var gross = Quantity * UnitPrice;
            var net = gross - Discount;
            Total = net < 0 ? 0 : decimal.Round(net, 2, MidpointRounding.AwayFromZero);
        }
    }
}

using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Sale : BaseEntity
    {
        private readonly List<SaleItem> _items = new();
        public string SaleNumber { get; private set; } = default!;
        public DateTime SaleDate { get; private set; }
        public string CustomerName { get; private set; } = default!;
        public string Branch { get; private set; } = default!;
        public decimal TotalAmount { get; private set; } // soma dos itens
        public SaleStatus Status { get; private set; } = SaleStatus.NotCancelled;

        public IReadOnlyCollection<SaleItem> Items => _items.AsReadOnly();

        private Sale() { }

        public Sale(string saleNumber, DateTime saleDate, string customerName, string branch)
        {
            SaleNumber = saleNumber;
            SaleDate = saleDate;
            CustomerName = customerName;
            Branch = branch;
            TotalAmount = 0m;
            Status = SaleStatus.NotCancelled;
        }

        public SaleItem AddItem(string productName, int quantity, decimal unitPrice)
        {
            var item = new SaleItem(productName, quantity, unitPrice);
            _items.Add(item);
            RecalcTotal();
            return item;
        }

        private void RecalcTotal()
        {
            decimal total = 0m;
            foreach (var i in _items) total += i.Total;
            TotalAmount = total;
        }

        public void ReplaceItems(IEnumerable<SaleItem> items)
        {
            _items.Clear();
            _items.AddRange(items);
            RecalcTotal();
        }

        public void UpdateHeader(string customerName, string branch, DateTime saleDate)
        {
            CustomerName = customerName;
            Branch = branch;
            SaleDate = saleDate;
        }

        public void Cancel() => Status = SaleStatus.Cancelled;
    }
}

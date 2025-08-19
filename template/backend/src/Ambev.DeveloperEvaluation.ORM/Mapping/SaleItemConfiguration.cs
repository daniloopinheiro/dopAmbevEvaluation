using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
    public class SaleItemConfiguration : IEntityTypeConfiguration<SaleItem>
    {
        public void Configure(EntityTypeBuilder<SaleItem> b)
        {
            b.ToTable("sale_items");
            b.HasKey(x => x.Id);

            b.Property(x => x.ProductName).IsRequired().HasMaxLength(200);
            b.Property(x => x.Quantity).IsRequired();
            b.Property(x => x.UnitPrice).IsRequired().HasColumnType("numeric(18,2)");
            b.Property(x => x.Discount).IsRequired().HasColumnType("numeric(18,2)");
            b.Property(x => x.Total).IsRequired().HasColumnType("numeric(18,2)");
        }
    }
}

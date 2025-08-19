using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
    public class SaleConfiguration : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> b)
        {
            b.ToTable("sales");

            b.HasKey(x => x.Id);

            b.Property(x => x.SaleNumber)
                .IsRequired()
                .HasMaxLength(40);

            b.HasIndex(x => x.SaleNumber).IsUnique();

            b.Property(x => x.SaleDate).IsRequired();

            b.Property(x => x.CustomerName)
                .IsRequired()
                .HasMaxLength(200);

            b.Property(x => x.Branch)
                .IsRequired()
                .HasMaxLength(100);

            b.Property(x => x.TotalAmount)
                .HasColumnType("numeric(18,2)")
                .IsRequired();

            b.Property(x => x.Status)
                .HasConversion<int>()
                .HasDefaultValue(SaleStatus.NotCancelled);

            // Mapeamento com backing field
            b.Metadata
                .FindNavigation(nameof(Sale.Items))!
                .SetPropertyAccessMode(PropertyAccessMode.Field);

            b.HasMany(x => x.Items)
                .WithOne()
                .HasForeignKey(i => i.SaleId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

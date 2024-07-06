using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductManagement.Entities;

namespace ProductManagement.Data
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.ProductId).IsRequired();
            builder.Property(p => p.Description).IsRequired();
            builder.Property(p => p.Price);
            builder.Property(p => p.Stock);

            builder.HasOne(b => b.order).WithMany()
                    .HasForeignKey(p => p.OrderId);

        }
    }
}

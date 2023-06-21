using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using sistemaServer.Models;

namespace sistemaServer.Context.Map
{
    public class ProductMap : IEntityTypeConfiguration<ProductModel>
    {
        public void Configure(EntityTypeBuilder<ProductModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Code).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Gender).IsRequired().HasMaxLength(15);
            builder.Property(x => x.Range).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Color).IsRequired().HasMaxLength(11);
            builder.Property(x => x.Size).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Value).IsRequired();
            builder.Property(x => x.waistMeasure).IsRequired();
            builder.Property(x => x.barMeasure).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(1000);
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.dateCad);
            builder.Property(x => x.TypeId);
            builder.HasOne(x => x.Type);
        }
    }
}

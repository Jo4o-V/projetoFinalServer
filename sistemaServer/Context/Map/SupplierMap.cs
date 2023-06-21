using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using sistemaServer.Models;

namespace sistemaServer.Context.Map
{
    public class SupplierMap : IEntityTypeConfiguration<SupplierModel>
    {
        public void Configure(EntityTypeBuilder<SupplierModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Cnpj).IsRequired().HasMaxLength(15);
            builder.Property(x => x.Supply).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Contact).IsRequired().HasMaxLength(11);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Description).HasMaxLength(1000);
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.dateCad);
            builder.Property(x => x.CityId);
            builder.HasOne(x => x.City);
        }
    }
}

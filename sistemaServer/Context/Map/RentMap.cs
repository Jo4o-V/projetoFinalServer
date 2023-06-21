using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using sistemaServer.Models;

namespace sistemaServer.Context.Map
{
    public class RentMap : IEntityTypeConfiguration<RentModel>
    {
        public void Configure(EntityTypeBuilder<RentModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.rentCode).IsRequired().HasMaxLength(4);
            builder.Property(x => x.customerName).IsRequired().HasMaxLength(15);
            builder.Property(x => x.prodCode2);
            builder.Property(x => x.prodCode3);
            builder.Property(x => x.prodCode4);
            builder.Property(x => x.prodCode5);
            builder.Property(x => x.Amount).IsRequired();
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(1000);
            builder.Property(x => x.dateEvent);
            builder.Property(x => x.dateExped);
            builder.Property(x => x.dateReturn);
            builder.Property(x => x.dateCad);

            builder.Property(x => x.customerCodeId);
            builder.HasOne(x => x.customerCode);
            builder.Property(x => x.CodeId);
            builder.HasOne(x => x.Code);
        }
    }
}
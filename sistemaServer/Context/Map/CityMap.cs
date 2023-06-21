using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using sistemaServer.Models;

namespace sistemaServer.Context.Map
{
    public class CityMap : IEntityTypeConfiguration<CityModel>
    {
        public void Configure(EntityTypeBuilder<CityModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(45);
            builder.Property(x => x.Description).HasMaxLength(1000);
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.dateCad);
            builder.Property(x => x.StateId);
            builder.HasOne(x => x.State);
        }
    }
}

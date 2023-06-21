using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using sistemaServer.Models;

namespace sistemaServer.Context.Map
{
    public class CountryMap : IEntityTypeConfiguration<CountryModel>
    {
        public void Configure(EntityTypeBuilder<CountryModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(45);
            builder.Property(x => x.Acronym).IsRequired().HasMaxLength(5);
            builder.Property(x => x.Continent).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Description).HasMaxLength(1000);
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.dateCad);
        }
    }
}

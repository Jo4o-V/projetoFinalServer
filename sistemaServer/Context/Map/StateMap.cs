using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using sistemaServer.Models;

namespace sistemaServer.Context.Map
{
    public class StateMap : IEntityTypeConfiguration<StateModel>
    {
        public void Configure(EntityTypeBuilder<StateModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Acronym).IsRequired().HasMaxLength(5);
            builder.Property(x => x.Description).HasMaxLength(1000);
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.dateCad);
            builder.Property(x => x.CountryId);
            builder.HasOne(x => x.Country);
        }
    }
}

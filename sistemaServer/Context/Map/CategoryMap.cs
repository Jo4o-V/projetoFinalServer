using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using sistemaServer.Models;

namespace sistemaServer.Context.Map
{
    public class CategoryMap : IEntityTypeConfiguration<CategoryModel>
    {
        public void Configure(EntityTypeBuilder<CategoryModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Code).IsRequired().HasMaxLength(3);
            builder.Property(x => x.Category).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Type).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Description).HasMaxLength(1000);
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.dateCad);
        }
    }
}

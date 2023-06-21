using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using sistemaServer.Models;

namespace sistemaServer.Context.Map
{
    public class UserMap : IEntityTypeConfiguration<UserModel>
    {
        public void Configure(EntityTypeBuilder<UserModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.UserName).IsRequired().HasMaxLength(10);
            builder.Property(x => x.Cpf).IsRequired().HasMaxLength(11);
            builder.Property(x => x.Contact).IsRequired().HasMaxLength(11);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(150);
            builder.Property(x => x.dateCad);
            builder.Property(x => x.Role).IsRequired();
            builder.Property(x => x.Wage).IsRequired();
            builder.Property(x => x.Password).IsRequired();
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.Token);
            builder.Property(x => x.RefreshToken);
            builder.Property(x => x.RefreshTokenExpiryTime);
        }
    }
}

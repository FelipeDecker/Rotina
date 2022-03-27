using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rotina.Domain.Entities;

namespace Rotina.Repository.Maps
{
    public class UserMap : MapBase<UserEntity>
    {
        public UserMap() : base("User")
        {

        }

        public override void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.Property(x => x.Name).HasColumnName("Name").HasMaxLength(150).IsRequired();
            builder.Property(x => x.Email).HasColumnName("Email").HasMaxLength(100).IsRequired();
            builder.Property(x => x.Password).HasColumnName("Password").IsRequired();
            builder.Property(x => x.Active).HasColumnName("Active").HasMaxLength(1).IsRequired();

            base.Configure(builder);
        }
    }
}

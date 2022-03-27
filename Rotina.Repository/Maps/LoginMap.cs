using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rotina.Domain.Entities;

namespace Rotina.Repository.Maps
{
    public class LoginMap : MapBase<LoginEntity>
    {
        public LoginMap() : base ("Login")
        {

        }

        public override void Configure(EntityTypeBuilder<LoginEntity> builder)
        {
            builder.HasKey(x => x.IdUser);

            builder.Property(x => x.IdUser).HasColumnName("IdUser").IsRequired();
            builder.Property(x => x.Ip).HasColumnName("Ip").HasMaxLength(25);
            builder.Property(x => x.Date).HasColumnName("Date").IsRequired();

            base.Configure(builder);
        }
    }
}

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rotina.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rotina.Repository.Maps
{
    public class EmailMap : MapBase<EmailEntity>
    {
        public EmailMap() : base("Email")
        {

        }

        public override void Configure(EntityTypeBuilder<EmailEntity> builder)
        {
            //builder.HasKey(x => x.IdUser);

            //builder.Property(x => x.IdUser).HasColumnName("IdUser").IsRequired();
            //builder.Property(x => x.Ip).HasColumnName("Ip").HasMaxLength(25);
            //builder.Property(x => x.Date).HasColumnName("Date").IsRequired();

            base.Configure(builder);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rotina.Domain.Entities;

namespace Rotina.Repository.Maps
{
    public class MapBase<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : EntityBase
    {
        private readonly string TableName;

        public MapBase(string tableName)
        {
            TableName = tableName;
        }

        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.ToTable(TableName);

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("Id");
        }
    }
}

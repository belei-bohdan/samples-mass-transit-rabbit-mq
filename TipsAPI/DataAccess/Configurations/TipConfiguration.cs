using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TipsAPI.DataAccess.Entities;

namespace TipsAPI.DataAccess.Configurations
{
    internal class TipConfiguration : IEntityTypeConfiguration<Tip>
    {
        public void Configure(EntityTypeBuilder<Tip> builder)
        {
            builder.ToTable("Tips")
                .HasKey(x => x.Id);

            builder.Property(t => t.Title)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(t => t.Source)
                .HasMaxLength(500)
                .IsRequired();
        }
    }
}

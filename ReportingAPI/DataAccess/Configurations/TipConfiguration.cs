using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReportingAPI.DataAccess.Entities;

namespace ReportingAPI.DataAccess.Configurations
{
    internal class TipConfiguration : IEntityTypeConfiguration<Tip>
    {
        public void Configure(EntityTypeBuilder<Tip> builder)
        {
            builder.ToTable("Tips")
                .HasKey(x => x.Id);
        }
    }
}

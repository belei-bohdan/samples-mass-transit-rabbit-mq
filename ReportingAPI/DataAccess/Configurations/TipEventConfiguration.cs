using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReportingAPI.DataAccess.Entities;

namespace ReportingAPI.DataAccess.Configurations
{
    internal class TipEventConfiguration : IEntityTypeConfiguration<TipEvent>
    {
        public void Configure(EntityTypeBuilder<TipEvent> builder)
        {
            builder.ToTable("TipEvents")
                .HasKey(x => x.Id);
        }
    }
}

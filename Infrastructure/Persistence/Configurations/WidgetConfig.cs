using HicomInterview.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HicomInterview.Infrastructure.Persistence.Configurations
{
    /// <summary>
    /// EF configuration for the Widget entity.
    /// </summary>
    public class WidgetConfiguration : IEntityTypeConfiguration<Widget>
    {
        public void Configure(EntityTypeBuilder<Widget> builder)
        {
            builder.ToTable(nameof(Widget));
            builder.HasOne(d => d.NewAddress).WithMany(p => p.WidgetNewAddress).HasConstraintName("FK_Widget_NewAddress");
            builder.HasOne(d => d.OldAddress).WithMany(p => p.WidgetOldAddress).HasConstraintName("FK_Widget_OldAddress");
        }
    }
}

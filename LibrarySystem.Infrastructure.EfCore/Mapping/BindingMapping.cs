
using LibrarySystem.Domain.BindingAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibrarySystem.Infrastructure.EfCore.Mapping;

public class BindingMapping : IEntityTypeConfiguration<Binding>
{
    public void Configure(EntityTypeBuilder<Binding> builder)
    {
        builder.ToTable("Bindings", "Library");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
   
        builder.Property(x => x.CreationDate).IsRequired();
        builder.Property(x => x.IsDeleted).IsRequired();

        builder.HasMany(x => x.Books).WithOne(x => x.Binding).HasForeignKey(x => x.BindingId);
    }
}

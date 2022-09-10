using LibrarySystem.Domain.BookAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibrarySystem.Infrastructure.EfCore.Mapping;

public class BookMapping : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.ToTable("Books", "Library");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Title).HasMaxLength(100).IsRequired();
        builder.Property(x=>x.Language).HasMaxLength(100).IsRequired();
        builder.Property(x=>x.PublicationYear).IsRequired();
        
        builder.Property(x => x.CreationDate).IsRequired();
        builder.Property(x => x.IsDeleted).IsRequired();

        builder.HasOne(x => x.Binding).WithMany(x => x.Books).HasForeignKey(x => x.BindingId);
        builder.HasOne(x => x.Category).WithMany(x => x.Books).HasForeignKey(x => x.CategoryId);
    }
}

using LibrarySystem.Domain.CategoryAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Infrastructure.EfCore.Mapping;

public class CategoryMapping : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Categories", "Library");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Title).HasMaxLength(100).IsRequired();

        builder.Property(x => x.CreationDate).IsRequired();
        builder.Property(x => x.IsDeleted).IsRequired();

        builder.HasMany(x => x.Books).WithOne(x => x.Category).HasForeignKey(x => x.CategoryId);

    }
}


using LibrarySystem.Domain.BindingAgg;
using LibrarySystem.Domain.BookAgg;
using LibrarySystem.Domain.CategoryAgg;
using LibrarySystem.Infrastructure.EfCore.Mapping;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Infrastructure.EfCore;

public class LibraryDbContext : DbContext
{
  
    public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
    {

    }

    public DbSet<Book> Books { get; set; }
    public DbSet<Binding> Bindings { get; set; }
    public DbSet<Category> Categories { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        var assembly = typeof(BookMapping).Assembly;
        modelBuilder.ApplyConfigurationsFromAssembly(assembly);

        base.OnModelCreating(modelBuilder);
    }

}

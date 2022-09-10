using LibrarySystem.Application.Commands.CategoryCommands;
using LibrarySystem.Domain.BindingAgg;
using LibrarySystem.Domain.BindingAgg.BindingService;
using LibrarySystem.Domain.BindingAgg.CategoryService;
using LibrarySystem.Domain.BookAgg;
using LibrarySystem.Domain.CategoryAgg;
using LibrarySystem.Domain.CategoryAgg.CategoryService;
using LibrarySystem.DomainService.BindingService;
using LibrarySystem.DomainService.BookService;
using LibrarySystem.Framework.Infrastructure;
using LibrarySystem.Infrastructure.EfCore;
using LibrarySystem.Infrastructure.EfCore.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LibrarySystem.Infrastructure.Core;

public class AppConfiguration
{
    public static void Config(IServiceCollection services, string connectionString)
    {
        services.AddDbContext<LibraryDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });
        services.AddTransient<IUnitOfWork, UnitOfWorkEf>();
        #region RepositoryLiftime
        services.AddTransient<IBookRepository, BookRepository>();
        services.AddTransient<IBindingRepository, BindingRepository>();
        services.AddTransient<ICategoryRepository, CategoryRepository>();
        #endregion
        #region DomainService
        services.AddTransient<IBookValidatorService,BookValidatorService >();
        services.AddTransient<IBindingValidatorService,BindingValidatorService >();
        services.AddTransient<ICategoryValidatorService,CategoryValidatorService >();

        #endregion
        services.AddOptions();

        services.AddMediatR(typeof(CreateCategoryCommandHandler));
    }
}
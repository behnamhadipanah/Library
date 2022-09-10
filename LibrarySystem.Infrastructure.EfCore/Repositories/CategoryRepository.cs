using LibrarySystem.Domain.CategoryAgg;
using LibrarySystem.Framework.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Infrastructure.EfCore.Repositories;

public class CategoryRepository:Repository<Category>,ICategoryRepository
{
    private readonly LibraryDbContext _context;

    public CategoryRepository(LibraryDbContext context):base(context)
	{
		_context = context;
	}


}

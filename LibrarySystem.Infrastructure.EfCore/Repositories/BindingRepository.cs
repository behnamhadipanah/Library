using LibrarySystem.Domain.BindingAgg;
using LibrarySystem.Framework.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Infrastructure.EfCore.Repositories;

public class BindingRepository:Repository<Binding>,IBindingRepository
{
    private readonly LibraryDbContext _context;
	public BindingRepository(LibraryDbContext context):base(context) 
	{
		_context = context;
	}
}

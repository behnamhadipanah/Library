using LibrarySystem.Framework.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Infrastructure.EfCore;

public class UnitOfWorkEf : IUnitOfWork
{
    private readonly LibraryDbContext _context;
    public UnitOfWorkEf(LibraryDbContext context)
    {
        _context = context;
    }

    public void BeginTransaction()
    {
        _context.Database.BeginTransaction();
    }

    public bool CommitTransaction()
    {
        var result = _context.SaveChanges();
        _context.Database.CommitTransaction();
        return result > 0;
    }

    public void Rollback()
    {
        _context.Database.RollbackTransaction();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Framework.Infrastructure;

public interface IUnitOfWork
{
    void BeginTransaction();
    bool CommitTransaction();
    void Rollback();
}
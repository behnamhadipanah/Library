using LibrarySystem.Infrastructure.Contracts.Binding;
using LibrarySystem.Infrastructure.Contracts.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Infrastructure.Queries.BindingQuery;

public interface IBindingQuery
{
    Task<List<BindingViewModel>> GetBindings();
    Task<BindingViewModel?> GetBinding(long id);
}

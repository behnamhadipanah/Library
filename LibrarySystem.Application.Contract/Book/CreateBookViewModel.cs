using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Application.Contract.Book;

public class CreateBookViewModel
{
    public string Title { get;  set; }
    public string Language { get;  set; }
    public long PublicationYear { get;  set; }

    public long BindingId { get;  set; }
    public long CategoryId { get;  set; }
}

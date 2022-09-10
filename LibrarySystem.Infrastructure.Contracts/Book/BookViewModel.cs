using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Infrastructure.Contracts.Book;

public class BookViewModel
{
    public string Title { get; set; }
    public string Language { get; set; }
    public long PublicationYear { get; set; }
    public bool IsActive { get; set; }
    public string CreationDate { get; set; }

    public string Binding { get; set; }
    public string Category { get; set; }



}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Application.Contract.Book;

public class EditBookViewModel:CreateBookViewModel
{
    public long Id { get; set; }
}

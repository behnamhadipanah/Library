using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Infrastructure.Contracts.Category;

public class CategoryViewModel
{
    public long Id { get; set; }
    public string Title { get; set; }
    public bool IsActive { get; set; }
    public string CreationDate { get; set; }
}

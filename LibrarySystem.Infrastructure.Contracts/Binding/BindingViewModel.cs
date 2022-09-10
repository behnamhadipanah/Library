using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Infrastructure.Contracts.Binding;

public class BindingViewModel
{
    public long Id { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }
    public string CreationDate { get; set; }

}

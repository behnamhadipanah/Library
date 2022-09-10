using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Domain.BindingAgg.BindingService;

public interface IBindingValidatorService
{
    void CheckThatThisRecordAlreadyExists(string name);

}

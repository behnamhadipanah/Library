using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.DomainService.BookService;

public interface IBookValidatorService
{
    void CheckThatThisRecordAlreadyExists(string title, string language, long publicationYear, long bindingId, long categoryId);

}

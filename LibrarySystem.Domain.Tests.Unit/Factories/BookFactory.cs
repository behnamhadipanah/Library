using LibrarySystem.Domain.BookAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace LibrarySystem.Domain.Tests.Unit.Factories;

public class BookFactory


{
    public static Book Create()
    {
        return new Book("Bar Hasti","Persian", 1984,1,1);

    }
}

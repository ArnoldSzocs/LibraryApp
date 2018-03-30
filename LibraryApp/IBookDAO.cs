using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp
{
    interface IBookDAO:IDAO<Book>
    {
        Book SelectByBookName(String title);

        void InsertAll(List<Book> books);
    }
}

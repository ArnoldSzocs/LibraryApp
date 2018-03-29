using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp
{
  public class BookService : IBookService
    {
        private IBookDAO bookDAO=new BookDAO();

        public void AddBook(BookDto bookdto)
        {
            Book book = new Book();
            book.Title = bookdto.Title;
            book.Author = bookdto.Auhor;
            book.Category = bookdto.Category;

            bookDAO.Insert(book);
        }

        public List<BookDto> Load()
        {
            List<BookDto> bookdtos = new List<BookDto>();
            List<Book> books = bookDAO.SelectAll();
            foreach (var item in books)
            {
                bookdtos.Add(new BookDto(item.Id, item.Title, item.Author, item.Category));
            }
            return bookdtos;
        }
              

        public void Save(List<BookDto> created, List<BookDto> modified, List<BookDto> deleted)
        {
            //new books
            List<Book> newbooks = new List<Book>();
            foreach (var item in created)
            {
                Book book = new Book();
                book.Title = item.Title;
                book.Author = item.Auhor;
                book.Category = item.Category;
                newbooks.Add(book);
            }
            bookDAO.InsertAll(newbooks);

            // modified books
            
            foreach (var bookdto in modified)
            {
                Book book = bookDAO.SelectOne(bookdto.Id.GetValueOrDefault());
                book.Title = bookdto.Title;
                book.Author = bookdto.Auhor;
                book.Category = bookdto.Category;
                bookDAO.Update(book);
            }
            //delete book
            foreach (var bookdto in deleted)
            {
                Book book = bookDAO.SelectOne(bookdto.Id.GetValueOrDefault());
                bookDAO.Delete(book);
            }
        }
    }
}

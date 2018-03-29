using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.Connection;
using MySql.Data.MySqlClient;

namespace LibraryApp
{
    class BookDAO : IBookDAO
    {
        ConnectionManager connection = ConnectionManager.GetConnection();
        public void Delete(long id)
        {
            String query = "DELETE FROM Dictionary WHERE id=" + id;
            connection.ExecuteQuery(query);
        }

        public void Delete(Book t)
        {
            Delete(t.Id);
        }

        public void Insert(Book t)
        {
            String query="INSERT INTO Dictionary(BookTitle,Author,Category) VALUES('"+t.Title+"','"+t.Author+"','"+t.Category+"')";
            connection.ExecuteQuery(query);
        }
        public void InsertAll(List<Book> books)
        {
            foreach (var book in books)
            {
                Insert(book);
            }
        }

        public List<Book> SelectAll()
        {
            List<Book> books = new List<Book>();
            String query = "SELECT * FROM Dictionary";
            MySqlDataReader reader = connection.ReadQuery(query);
            while (reader.Read())
            {
                Book book = new Book();
                book.Title = reader.GetString(0);
                book.Author = reader.GetString(1);
                book.Category = reader.GetString(2);
                books.Add(book);
            }
            reader.Close();
            return books;
        }

        public Book SelectByBookName(string title)
        {
            String query = "SELECT * FROM Dictionary WHERE BookTitle=" + title;
            MySqlDataReader reader = connection.ReadQuery(query);
            if (reader.Read())
            {
                Book book = new Book();
                book.Title = reader.GetString(0);
                book.Author = reader.GetString(1);
                book.Category = reader.GetString(2);
                reader.Close();
                return book;
            }
            
            throw new EntityNotFoundException();
        }

        public Book SelectOne(long id)
        {
            String query = "SELECT * FROM Dictinary WHERE BookID=" + id;

            MySqlDataReader reader = connection.ReadQuery(query);
            if (reader.Read())
            {
                Book book = new Book();
                book.Title = reader.GetString(0);
                book.Author = reader.GetString(1);
                book.Category = reader.GetString(2);
                reader.Close();
                return book;
            }
            throw new EntityNotFoundException();
        }

        public void Update(Book t)
        {
            String query = "UPDATE Dictionary SET BookTitle=" + t.Title + ",Author=" + t.Author + ",Category=" + t.Category + "WHERE BookID=" + t.Id;
            connection.ExecuteQuery(query);
        }
    }
}

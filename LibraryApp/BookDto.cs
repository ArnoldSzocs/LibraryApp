using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp
{
   public class BookDto
    {
        private long? id;
        private string title;
        private string auhor;
        private string category;
        public BookDto(string title, string author, string category) : this(null, title, author, category)
        {

        }
        public BookDto(long? id, string title, string auhor, string category)
        {
            Id = id;
            Title = title;
            Auhor = auhor;
            Category = category;
        }

        public long? Id { get => id; set => id = value; }
        public string Title { get => title; set => title = value; }
        public string Auhor { get => auhor; set => auhor = value; }
        public string Category { get => category; set => category = value; }
    }
}

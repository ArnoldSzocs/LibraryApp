using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp
{
    class Book :Entity
    {
        private string title;
        private string author;
        private string category;

        public string Title { get => title; set => title = value; }
        public string Author { get => author; set => author = value; }
        public string Category { get => category; set => category = value; }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibraryApp;
using System.Collections.Generic;

namespace BookServiceUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        IBookService bookservice;
        [TestInitialize]

        public void SetUp()
        {
            bookservice = new BookService();
            List<BookDto> books = new List<BookDto>();
            books.Add(new BookDto("cim", "szerzo", "category"));
            books.Add(new BookDto("cim2", "szerzo2", "category2"));
            books.Add(new BookDto("cim3", "szerzo3", "category3"));
            bookservice.Save(books,new List<BookDto>(),new List<BookDto>());
        }

        [TestMethod]
        public void TestMethod1()
        {
            List<BookDto> books = bookservice.Load();
            Assert.AreEqual(3, books.Count);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCFRESTfulService
{
    public class BookRepository : IBookRepository
    {

        public BookRepository()
        {
            AddNewBook(new Book { Title = "Thinking in C#", ISBN = "65674523432423" });
            AddNewBook(new Book { Title = "Thinking in Java", ISBN = "34223434543423" });
            AddNewBook(new Book { Title = "Beginning WCF", ISBN = "35343532423" });
        }

        List<Book> books = new List<Book>();
        int count = 1;

        public List<Book> GetAllBooks()
        {
            return books;
        }

        public Book GetBookById(int bookId)
        {
            return books.Find(b => b.BookId == bookId);
        }

        public Book AddNewBook(Book newBook)
        {
            if (newBook == null)
                throw new ArgumentException("newBook");

            newBook.BookId = count++;
            books.Add(newBook);
            return newBook;
        }

        public bool DeleteABook(int bookId)
        {
            int idx = books.FindIndex(b => b.BookId == bookId);
            if (idx == -1)
                return false;

            books.RemoveAll(b => b.BookId == bookId);
            return true;
        }

        public bool UpdateABook(Book updatedBook)
        {
            if (updatedBook == null)
                throw new ArgumentNullException("updatedBook");

            int idx = books.FindIndex(b => b.BookId == updatedBook.BookId);
            if (idx == -1)
                return false;

            books.RemoveAt(idx);
            books.Add(updatedBook);
            return true;
        }
    }
}
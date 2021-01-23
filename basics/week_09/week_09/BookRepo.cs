using System.Collections.Generic;

namespace week_09
{
    class BookRepo
    {
        public List<Book> GetBooks()
        {
            List<Book> books = new List<Book>();

            books.Add(new Book("z", 1f));
            books.Add(new Book("y", 2f));
            books.Add(new Book("x", 3f));

            books.Add(new Book("a", 10f));
            books.Add(new Book("b", 11f));
            books.Add(new Book("c", 12f));

            return books;
        }
    }
}

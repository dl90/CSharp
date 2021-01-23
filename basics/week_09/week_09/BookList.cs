using System.Collections.Generic;

namespace week_09
{
    class BookList
    {
        private readonly List<Book> book;

        public BookList()
        {
            book = new List<Book>();
        }

        public void Add(Book arg)
        {
            book.Add(arg);
        }

        public Book Get(int idx)
        {
            return book[idx];
        }
    }
}

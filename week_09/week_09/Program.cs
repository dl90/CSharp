using System;
using System.Collections.Generic;
using System.Linq;

namespace week_09
{
    class Program
    {
        static void Main(string[] args)
        {
            var bookList = new BookList();
            bookList.Add(new Book("title", 9.99f));

            var objList = new ObjectList();
            objList.Add(1);
            objList.Add(new Book("title", 12f));

            // returns object, will need casting which may throw exceptions
            objList.Get(0);

            // generic list of Books
            var genericList = new GenericList<Book>();
            genericList.Add(new Book("unique title", 13f));

            var util = new Util<Book>();
            var maxBook = util.Max(new Book("a", 2f), new Book("b", 2.1f));
            Console.WriteLine(maxBook.Price);



            BookRepo repo = new BookRepo();
            List<Book> books = repo.GetBooks();


            var cheapBooks = books.Where(b => b.Price < 5).OrderBy(b => b.Title);
            foreach (Book b in cheapBooks) Console.WriteLine($"{b.Title} {b.Price}");


            var cb = from bo in books
                     where bo.Price < 5
                     orderby bo.Title
                     select bo;
            foreach (Book b in cb) Console.WriteLine($"{b.Title} {b.Price}");


            var first = books.First(b => b.Price < 5);
            var max = books.Max(b => b.Title);
            var min = books.Min(b => b.Title);

            Console.WriteLine(max);
            Console.WriteLine(min);
            Console.ReadKey();
        }
    }
}

using System;

namespace week_09
{
    class Book : IComparable
    {
        public Book(string title, float price)
        {
            Title = title;
            Price = price;
        }

        public int CompareTo(object other)
        {
            if (other == null) return 1;

            Book otherBook = other as Book;
            if (otherBook != null)
                return (int)(this.Price - otherBook.Price);
            else
                throw new ArgumentException("argument is not a Book");
        }

        public string Title { get; set; }
        public float Price { get; set; }
    }
}

# Generics & LINQ

## Generics

* compile time type safety
* can specify upper bound with where interface

```c#
// any object or children of object can be added
var list = new List<object>();

// all data types are children of object
// issue comes when one wants to upcast back to original data type, which can not be guaranteed
```

```c#
using System.Collections.Generic;

namespace week_09
{
    // type is specified during instantiation
    class GenericList<T>
    {
        private readonly List<T> list;

        public GenericList()
        {
            list = new List<T>();
        }

        public void Add(T arg)
        {
            list.Add(arg);
        }

        public T Get(int idx)
        {
            return list[idx];
        }
    }
}

var genericList = new GenericList<string>();
```

```c#
using System.Collections.Generic;

namespace week_09
{
    class GenericDictionary<TKey, TValue>
    {
        private readonly Dictionary<TKey, TValue> dictionary;

        public GenericDictionary()
        {
            dictionary = new Dictionary<TKey, TValue>();
        }

        public void Add(TKey key, TValue val)
        {
            dictionary.Add(key, val);
        }

        public dynamic Get(TKey key)
        {
            TValue val;
            bool result = dictionary.TryGetValue(key, out val);
            if (result) return val;
            else return null;
        }
    }
}

var genericDictionary = new GenericDictionary<string, Book>();
```

Generics upper limit (constraints on a typed param)

```c#
// T:IComparable constraint guarantees the generic type assigned has the CompareTo method
// the interface constraint ensures only classes that implemented the interface can be used
class Util<T> where T:IComparable
{
    public T Max(T a, T b)
    {
        return a.CompareTo(b) > 0 ? a : b;
    }
}

// these implements IComparable
util.Max(1, 2);
util.Max("a", "b");

// complier indicates an error for instances of classes that do not implement IComparable
```

```c#
class Book : IComparable
{
    public Book(string title, float price)
    {
        Title = title;
        Price = price;
    }

    // IComparable requires implementing CompareTo(object)
    public int CompareTo(object arg)
    {
        if (arg == null) return 1;

        Book otherBook = arg as Book;
        if (otherBook != null)
            return (int)(this.Price - otherBook.Price);
        else
            throw new ArgumentException("argument is not a Book");
    }

    public string Title { get; set; }
    public float Price { get; set; }
}
```

## LINQ

declarative, not imperative

```c#
// extension methods
var cheapBooks = books.Where(b => b.Price < 5).OrderBy(b => b.Title);

// query operators
var cb = from bo in books
         where bo.Price < 5
         orderby bo.Title
         select bo;

// aggregate functions
var first = books.First(b => b.Price < 5);
```

## String builder

* C# (and Java) optimizes memory by referencing the same string if the value of the string is the same on multiple args
* verbatim: `@"F:\folder\doc" vs "F:\\folder\\doc"`
* String.Equals(str1, str2)

string builder is more memory efficient in cases of frequent string manipulation

```c#
var buffer = new StringBuilder("initial string");
// can use .Length to truncate
// can use .EnsureCapacity to allocate more memory
buffer.Append(123);
buffer.Insert(0, "val");
```

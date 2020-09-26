# C# basics

namespace used to organize your code. It is a container for classes and other namespaces

```c#
/* simple types */
int num = 5;              // 32 bit signed
long numL = 2147483647L;  // 64 bit signed
float numF = 5.75F;       // 3.4e38 (approx)
double numD = 5.99D;      // 3.4e308 (approx)
decimal numDec = 1.234;   // 28~29 sig-figs (precise)

char myLetter = 'D';      // ASCII chars + [/n... etc]
string myText = "Hello";

bool myBool = true;

const int myNum = 15;
```

```c#
// implicit casting [char -> int -> long -> float -> double]
int myInt = 9;
double myDouble = myInt;    // int -> double

// explicit casting [double -> float -> long -> int -> char]
double myDouble = 9.78;
int myInt = (int) myDouble; // double -> int

/*
  Convert.ToBoolean
  Convert.ToDouble
  Convert.ToString
  Convert.ToInt32 (int)
  Convert.ToInt64 (long)
*/
```

---

```c#
using System;

namespace test
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Hello World!");
      string userName = Console.ReadLine().Trim();
      Console.WriteLine($"hi {username}");
      Method();
      MethodArg(1, "Test");

      // waits for key before exit
      Console.ReadKey();
    }

    // no return
    static void Method()
    {
      for(int i = 0; i < 10; i++) {
        Console.WriteLine(string i)
      }
    }

    static void MethodArg(int count, string arg = "Default")
    {
      Console.WriteLine($"{count}\n{arg}")
    }

    // int == return type int
    static int MyMethod(int x)s
    {
      return 5 + x;
    }

    // method overloading
    static int PlusMethod(int x, int y)
    {
      return x + y;
    }

    static double PlusMethod(double x, double y)
    {
      return x + y;
    }
  }
}
```

> .sln
>
> Solution: one solution can have multiple projects in any supported .NET language (C#, F#, etc)
>
> These are compiled together as a single solution (program)

- Abstraction/Encapsulation: { data/details }
- Inheritance: generalization
- Polymorphism: distinct objects can use distinct interfaces

Reference types: stored as references (Objects)

Primitives: stored as values (int, double, etc)

```c#
class test
{
  // auto implemented property
  public string Name { get; set; }
  private string test;

  public string Test
  {
    get
    {
      return test;
    }
    set
    {
      test = value;
    }
  }
}
```

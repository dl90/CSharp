# Types and syntax

namespace used to organize your code. It is a container for classes and other namespaces

```c#
/* value types */
sbyte numSB = -128;        // 8 bit signed
byte numB = 255;           // 8 bit unsigned immutable

short numS = -1;           // 16 bit signed
ushort unumS = 1;          // 16 bit unsigned

int num = 5;               // 32 bit signed
long numL = 2147483647L;   // 64 bit signed

float numF = 5.75F;        // 3.4e38 (approx)
double numD = 5.99D;       // 3.4e308 (approx)
decimal numDec = 1.234M;   // 28~29 sig-figs (precise)

char myLetter = 'D';       // ASCII chars + [/n... etc]
char letterB = (char) 66;  // B
string myText = "Hello";

bool myBool = true;
var x = 'x';
const int myNum = 15;

// nullable value types
int? test = null;
```

```c#
/*
  implicit casting [char -> int -> long -> float -> double]
  no loss of precision
*/
int myInt = 9;
double myDouble = myInt;    // int -> double

/*
  explicit casting [double -> float -> long -> int -> char]
  possible loss of precision, must specify cast
*/
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

      var val = Console.ReadKey().KeyChar;
      Console.WriteLine(val);

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

* Abstraction/Encapsulation: { data/details }
* Inheritance: generalization
* Polymorphism: distinct objects can use distinct interfaces

Reference types: stored as references (Objects)

Primitives: stored as values (int, double, etc)

```c#
class test
{
  // auto implemented property with private setter
  public string Name { get; private set; }
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

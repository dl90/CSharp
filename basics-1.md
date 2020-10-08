# C# basics-1

## Object Initializers

assign values to accessible fields/properties at object creation time without invoking the constructor

```c#
Cat cat = new Cat { Age = 10, Name = "Fluffy" };
Cat sameCat = new Cat("Fluffy"){ Age = 10 };
```

* state of an object: values of the objects fields/properties
* signature of a method: name of method && parameters

> clean code <= 3 parameters

## null reference exception

```c#
public static void methodX(Object obj)
{
    // defensive programming
    if(obj == null) throw new ArgumentNullException("got null")
}
```

## params

```c#
// variable number of arguments
public static int Add(params int[] numbers)
{
    int sum = 0;
    foreach (int number in numbers) sum += number;
    return sum;
}
```

## out

* arguments passed by reference, modifications to the argument is kept
* similar to **ref**, but requires the argument to be initialized first

```c#
public static void methodX(out int num)
{
    num = 42;
}
```

## Access Modifiers

* public: anywhere, in/out of package (namespaces)
* private: within class
* protected: within class && children classes
* internal: within package (namespaces)
* protected internal: accessible within package with children classes only

## Inheritance

is-a relationship: Student => BCITStudent => ComputingStudent => FSWDStudent

## Polymorphic behavior

* Employee class
  * PerHour() => calcIncome
  * Payroll() => calcIncome

Dynamic overloading: runtime will be able to identify which method based on object

```c#
// parent
public virtual void methodX()
{
  Console.WriteLine("a");
}

// child
public override void methodX()
{
  base.methodX(); // invokes parent method
  Console.WriteLine("b");
}
```

* all classes inherit from Object
* C# only has single inheritance (class b: a)
* child instantiation = runtime calls parent constructor

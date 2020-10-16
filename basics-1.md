# Objects

## Object Initializers

assign values to accessible fields/properties at object creation time without invoking the constructor

```c#
Cat cat = new Cat { Age = 10, Name = "Fluffy" };
Cat sameCat = new Cat("Fluffy"){ Age = 10 };
```

* state of an object: values of the objects fields/properties
* signature of a method: name of method && parameters

> clean code <= 3 parameters

### null reference exception

```c#
public static void methodX(Object obj) {
    // defensive programming
    if(obj == null) throw new ArgumentNullException("got null");
}
```

### params

```c#
// variable number of arguments
public static int Add(params int[] numbers) {
    int sum = 0;
    foreach (int number in numbers) sum += number;
    return sum;
}
```

### out

* arguments passed by reference, modifications to the argument is kept
* similar to **ref**, but requires the argument to be initialized first

```c#
public static void methodX(out int num) {
    num = 42;
}
```

### Access Modifiers

* public: anywhere, in/out of package (namespaces)
* private: within class
* protected: within class && children classes
* internal: within package (namespaces)
* protected internal: accessible within package with children classes only

### Boxing & Unboxing

* boxing: value to reference type
* unboxing: reference to value type

why? some collections/data structures only store objects

```c#
Object obj = 10;

```

---

## Inheritance

super/sub, parent/child, based/derived

is-a relationship: Student => BCITStudent => ComputingStudent => FSWDStudent

* all classes inherit from Object
* C# only has single inheritance (class b: a)
* child instantiation = runtime calls parent constructor

> child constructors must invoke one the parents constructor during instantiation

### method overriding

```c#
// parent
public virtual void methodX() {
  Console.WriteLine("a");
}

// child
public override void methodX() {
  base.methodX(); // invokes parent method
  Console.WriteLine("b");
}
```

```c#
class child : parent
{
  // invoke specific parent constructor. In this case, one that takes a string arg
  public child() : base("arg") { }
}
```

```c#
class self
{
  public self() {
    Console.WriteLine("Default");
  }

  // invoke another constructor, this() refers to default constructor with no args
  public self(string arg): this() {
    Console.WriteLine(arg);
  }
}
```

### Abstract class

* forces child classes to implement abstract methods
* abstract classes can not instantiate an object, class is incomplete

> abstract classes still needs constructors b/c child classes invokes parent constructors during instantiation

```c#
abstract class parent
{
  public abstract void MustImplement(string arg);
}

// all abstract methods implemented = complete class, aka 'concrete object'
class child : parent
{
  public override void MustImplement(string arg) {
    null;
  }
}
```

### Reference type casting

there must be inheritance between the two to convert reference type from one to another

* (implicit) Upcasting:      child => parent, always valid
* (explicit) Downcasting:    parent => child, complier shows no errors, may throw invalid cast exception at runtime

```c#
Parent shape;
Child circle;

shape = circle // no problem, circle with shape ref losses access to some circle methods
circle = (Child) shape // problem, not all shapes are circles
```

### Interface

classes can implement more than 1 interface but must define whats in the interfaces (contract)

```c#
interface IDrawable
{
  public void Draw();
}

interface IPrintable
{
  public void Print();
}

class Triangle : IDrawable, IPrintable
{
  public void Draw() {
    Console.WriteLine("Triangle Draw");
  }

  public void Print() {
    Console.WriteLine("Triangle Print");
  }
}
```

### Polymorphic behavior

> inheritance, abstract, interfaces => allows polymorphism

Dynamic overloading: runtime will be able to identify which method based on object

```c#
static void Poly(Shape shape) {
  // polymorphic method || dynamic overloading
  // Draw is an abstract method
  shape.Draw();

  // not SOLID, violates open closed principle
  Circle x = shape as Circle;
  if (x != null) x.CircleMethod();

  Rectangle y = shape as Rectangle;
  if (y != null) y.RectangleMethod();

  if (shape is Circle) {
    var circ = (Circle) shape;
    circ.CircleMethod();
  }

  if (shape is Rectangle) {
    var rect = (Rectangle) shape;
    rect.RectangleMethod();
  }
}

static void Draw(IDrawable arg) {
  arg.Draw()
}
```

---

## Exceptions

* thrown exception stops remaining code from running
* finally will run even if theres a return in try block

```c#
try {
  1 / 0;
  Console.WriteLine("never run");
  return 1;
} catch (DivideByZeroException e) {
  Console.WriteLine($"handler 1 {e}");
} catch (Exception e) {
  Console.WriteLine($"handler 2 {e}");
} finally {
  Console.WiteLine("final");
}
```

```c#
class MyException: Exception
{
  public MyException(string message): base (message) {
  }
}
```

try {} finally {}
try {} using {}

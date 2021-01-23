# Async

```c#
public async void Calc() {
  // Task to perform Fibonacci calculation in separate thread
  Task<long> task = Task.Run(() => Fib(40));

  await task;
  // do something with task
}

public long Fib(int i) {
  if (i == 0 || i == 1) {
    return i;
  }
  return Fib(i - 1) + Fib(i - 2);
}
```

## [Extension methods](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/extension-methods)

```c#
public static class StringExtensions {
  public static string Shorten(this string str, int numOfWords) {
    if (numOfWords == 0) return "";

    var words = str.Split(' ');
    if (words.Length < numOfWords) return str;

    return string.Join(" ", words.Take(numOfWords));
  }
}
```

## structs

simple type struts

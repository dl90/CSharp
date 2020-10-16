# Data Structures

* generic collections: type safe at compile time, better performance
* non generic collections: stores as objects, require casting

---

## Dictionary

```c#
Dictionary<int, string> dict = new Dictionary<int, string>();

dict.Add(1, 'John');
dict.Add(2, 'Doe');
dict.Remove(1);

string removedVal;
dict.Remove(1, removedVal);
dict.ContainsKey(3);

dict.EnsureCapacity(5);
dict.TrimExcess(); // frees excess capacity

dict[2] = 'Jane'; // indexer to reassign

try
{
  dict.Add(2, 'Jane'); // add throws exception if key already exists
  dict[3] = 'Err'; // indexer throws exception if key doesn't exist
}
catch(Exception e)
{
Console.WriteLine(e.message);
}

string val;
dict.TryGetValue(3, out val); // returns true && assigns val if 3 exists

foreach( KeyValuePair<int, string> pair in dict ) // note: using foreach only allows reading, not writing
{
  Console.WriteLine($"{pair.Key} | {pair.Value}");
}

Dictionary<int, string>.ValueCollection vals = dict.Values; // iterable vals only
foreach(string val in vals)
{
  Console.WriteLine(val);
}

Dictionary<int, string>.KeyCollection keys = dict.Keys; // iterable keys only
foreach(int key in keys)
{
  Console.WriteLine(key);
}
```

# Heap

Heap helps you manage all of your CLI options

## Contents

- [Heap](#heap)
  - [Contents](#contents)
  - [How to use Heap](#how-to-use-heap)

## How to use Heap

Heap intends to be a super simple, no thrills Command Line arguments parser. It's as easy to use as:

```csharp
void Main(string[] args)
{
    var options = Heap.Crush(args).Into<ConfigurationOptions>();

    // ...
}

private class ConfigurationOptions(bool enableFeatureA);
```

When users interact with the above program, all they would need to provide when running it in their command line arguments is:
`--enableFeatureA true`

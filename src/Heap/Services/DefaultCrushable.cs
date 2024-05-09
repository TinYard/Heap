using Heap.Interfaces;

namespace Heap.Services;

public class DefaultCrushable(string[]? input) : ICrushable
{
    private readonly string[]? _input = input ?? null;

    public T? Into<T>() where T : class
    {
        if(_input is null || _input.Length == 0)
            return null;

        if(_input.Length == 1 && _input[0] is T)
            return _input[0] as T;

        var output = Activator.CreateInstance<T>();
        Type crusherType = typeof(T);
        var crusherProperties = crusherType.GetProperties();
        for(int i = 0; i < _input.Length - 1; i++)
        {
            var property = crusherProperties.First(x => x.Name == _input[i].Replace("--", ""));
            property.SetValue(output, _input[i + 1]);
        }

        return output;
    }
}

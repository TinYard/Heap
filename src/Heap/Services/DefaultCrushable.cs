using Heap.Interfaces;
using System.ComponentModel;

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
        for(int i = 0; i < _input.Length - 1; i+= 2)
        {
            var propertyName = _input[i].Replace("--", "");
            var propertyValue = _input[i + 1];

            var property = crusherProperties.First(x => x.Name == propertyName);
            var propertyType = property.PropertyType;

            TypeConverter typeConverter = TypeDescriptor.GetConverter(propertyType);
            property.SetValue(output, typeConverter.ConvertFrom(propertyValue));
        }

        return output;
    }
}

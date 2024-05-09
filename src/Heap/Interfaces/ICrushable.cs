namespace Heap.Interfaces;

public interface ICrushable
{
    T? Into<T>() where T : class;
}

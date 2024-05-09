using Heap.Interfaces;
using Heap.Services;

namespace Heap;

public static class Heap
{
    public static ICrushable Crush(string[] args)
    {
        return new DefaultCrushable(args);
    }
}

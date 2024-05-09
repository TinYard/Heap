namespace Heap.Tests;

public class DefaultCrushableTests
{
    private readonly ICrushable _crushable = new DefaultCrushable([]);

    [Theory, AutoData]
    public void DefaultCrushable_Into_Parses_String(string input)
    { 
        var result = new DefaultCrushable([input]).Into<string>();
        result.Should().Be(input);
    }

    [Fact]
    public void DefaultCrushable_Into_Returns_Null_When_Input_Is_Empty()
    {
        var result = _crushable.Into<string>();
        result.Should().BeNull();
    }

    [Fact]
    public void DefaultCrushable_Handles_Null_With_Simple_Object()
    {
        var result = new DefaultCrushable([]).Into<SomeSimpleObject>();
        result.Should().BeNull();
    }

    [Fact]
    public void DefaultCrushable_Handles_With_Simple_Object()
    {
        var result = new DefaultCrushable(["--Header", "hello"]).Into<SomeSimpleObject>();
        result.Should().NotBeNull();
        result!.Header.Should().Be("hello");
    }
}

internal class SomeSimpleObject
{
    public string? Header { get; set; }
}
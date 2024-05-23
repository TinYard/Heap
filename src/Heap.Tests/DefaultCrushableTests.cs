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
        var result = new DefaultCrushable([
            "--Header", "hello",
            "--Ready", "true",
            "--DefinedValues", "2",
            "--Cost", "10.9234",
            "--Volume", "10.923489823432234234",
            "--Hex", "f"
            ]).Into<SomeSimpleObject>();
        result.Should().NotBeNull();
        result!.Header.Should().Be("hello");
        result!.Ready.Should().Be(true);
        result!.DefinedValues.Should().Be(2);
        result!.Cost.Should().Be(10.9234m);
        result!.Volume.Should().Be(10.923489823432234234);
        result!.Hex.Should().Be('f');
    }

    [Fact]
    public void DefaultCrushable_Does_Not_Throw_On_Bad_Parse()
    {
        var crushable = new DefaultCrushable([
            "--Header", "hello",
            "--Ready", "22",
            ]);

        Action act = () => crushable.Into<SomeSimpleObject>();
        act.Should().NotThrow<Exception>();
    }

    [Fact]
    public void DefaultCrushable_On_Bad_Parse_Value_Is_Default()
    {
        var crushable = new DefaultCrushable([
            "--Header", "hello",
            "--Ready", "22",
            ]);

        var result = crushable.Into<SomeSimpleObject>();
        result.Should().NotBeNull();
        result!.Ready.Should().Be(default);
    }
}

internal class SomeSimpleObject
{
    public string? Header { get; set; }
    public bool Ready { get; set; }
    public int DefinedValues { get; set; }
    public decimal Cost { get; set; }
    public double Volume { get; set; }
    public char Hex { get; set; }
}
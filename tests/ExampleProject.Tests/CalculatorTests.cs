using FluentAssertions;
using Xunit;

namespace ExampleProject.Tests;

public class CalculatorTests
{
    private readonly Calculator _calculator = new();

    [Theory]
    [InlineData(5, 5, 10)]
    public void Test_Add(int first, int second, int expected)
    {
        var result = _calculator.Add(first, second);

        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(5, 5, 0)]
    public void Test_Subtract(int first, int second, int expected)
    {
        var result = _calculator.Subtract(first, second);

        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(1, 1, 1)]
    public void Test_Multiply(int first, int second, int expected)
    {
        var result = _calculator.Multiply(first, second);

        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(1, 1, 1, 0)]
    public void Test_Divide(int first, int second, int expected, int remainder)
    {
        var result = _calculator.Divide(first, second);

        result.Result.Should().Be(expected);
        result.Reminder.Should().Be(remainder);
    }

    [Fact]
    public void Test_Divide_ByZero()
    {
        var result = () => _calculator.Divide(1, 0);

        result.Should().Throw<DivideByZeroException>();
    }
}

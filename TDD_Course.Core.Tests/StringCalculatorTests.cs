using System;
using Xunit;
using FluentAssertions;
using FluentAssertions.Common;

namespace TDD_Course.Core.Tests
{
    
    public class StringCalculatorTests
    {
        [Theory]
        [InlineData("2", 2)]
        [InlineData("2,3", 5)]
        [InlineData("3,1,5", 9)]
        public void Add_ValidNumbers_CorrectSum(string inputString, decimal expectedResult)
        {
            var sut = new StringCalculator();

            var result = sut.Add(inputString);

            result.Should().Be(expectedResult);
        }

        [Theory]
        [InlineData("a,b")]
        [InlineData("1+2,3")]
        [InlineData("3.5,1.5,5")]
        [InlineData("")]
        public void Add_NonNumber_ShouldThrowExeption(string inputString)
        {
            var sut = new StringCalculator();

            Action result= () => sut.Add(inputString);

            result.Should().Throw<ArgumentException>();
        }

        [Theory]
        [InlineData("2", 2)]
        [InlineData("3,2", 1)]
        [InlineData("2,3", -1)]
        [InlineData("10,1,5", 4)]
        [InlineData("-5,-10", 5)]
        public void Subtract_ValidNumbers_CorrectDifference(string inputString, decimal expectedResult)
        {
            var sut = new StringCalculator();

            var result = sut.Subtract(inputString);

            result.Should().Be(expectedResult);
        }

        [Theory]
        [InlineData("a,b")]
        [InlineData("1+2")]
        [InlineData("1-2,3")]
        [InlineData("3.5,1.5,5")]
        [InlineData("")]
        public void Subtract_NonNumber_ShouldThrowExeption(string inputString)
        {
            var sut = new StringCalculator();

            Action result = () => sut.Subtract(inputString);

            result.Should().Throw<ArgumentException>();
        }

        [Theory]
        [InlineData("2", 2)]
        [InlineData("3,2", -1)]
        [InlineData("2,3", 1)]
        [InlineData("10,1,5", -6)]
        [InlineData("-5,-10", -5)]
        public void SubtractR_ValidNumbers_CorrectDifference(string inputString, decimal expectedResult)
        {
            var sut = new StringCalculator();

            var result = sut.SubtractR(inputString);

            result.Should().Be(expectedResult);
        }

        [Theory]
        [InlineData("a,b")]
        [InlineData("1-2,3")]
        [InlineData("3.5,1.5,5")]
        [InlineData("")]
        public void SubtractR_NonNumber_ShouldThrowExeption(string inputString)
        {
            var sut = new StringCalculator();

            Action result = () => sut.SubtractR(inputString);

            result.Should().Throw<ArgumentException>();
        }

        [Theory]
        [InlineData("2", 2)]
        [InlineData("3,2", 6)]
        [InlineData("10,-1,5", -50)]
        [InlineData("-5,-10", 50)]
        public void Multiply_ValidNumbers_CorrectProduct(string inputString, decimal expectedResult)
        {
            var sut = new StringCalculator();

            var result = sut.Multiply(inputString);

            result.Should().Be(expectedResult);
        }

        [Theory]
        [InlineData("2", 2)]
        [InlineData("3,2", 1.5)]
        [InlineData("100,10,5", 2)]
        [InlineData("20,-10", -2)]
        public void Divide_ValidNumbers_CorrectPercentage(string inputString, decimal expectedResult)
        {
            var sut = new StringCalculator();

            var result = sut.Divide(inputString);

            result.Should().Be(expectedResult);
        }
    }
}

using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace TDD_GarbageParser
{
    public class GarbagePaserTest
    {
        [Fact]
        public void ShouldParseSingleWord()
        {
            Parse("VIENNA").Should().Contain("VIENNA");

            Parse("BOTTLE").Should().Contain("BOTTLE");
        }

        [Fact]
        public void ShouldTransformToUppercase()
        {
            Parse("bottle").Should().Contain("BOTTLE");
        }

        [Fact]
        public void ShouldRemovePlural()
        {
            Parse("bottles").Should().Contain("BOTTLE");
        }

        [Fact]
        public void ShouldParseMultipleWords()
        {
            Parse("bottles,Vienna").Should().Equal("BOTTLE", "VIENNA");
        }

        private IList<string> Parse(string inputValues)
        {
            var values = inputValues.Split(',');
            var parsedResults = new List<string>();
            foreach(var value in values)
            {
                inputValues = RemovePlural(inputValues);
                parsedResults.Add(inputValues.ToUpper());
            }


            return parsedResults;
        }

        private static string RemovePlural(string inputValues)
        {
            if (IsPlural(inputValues))
            {
                inputValues = inputValues.Remove(inputValues.Length - 1);
            }

            return inputValues;
        }

        private static bool IsPlural(string inputValues)
        {
            return inputValues.EndsWith('s');
        }
    }
}

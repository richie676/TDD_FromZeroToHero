using FluentAssertions;
using System;
using System.Text;
using Xunit;

namespace TDD_ROT13
{
    public class RotEncryptorTest
    {

        /*
            A -> N
            B -> O
            a -> N
            dEf -> QRS 
            xyz -> KLM
            Hello, World ->  URYYB, JBEYQ
            Großraumbüroklimagerätestörung -> TEBFFENHZOHREBXYVZNTRENRGRFGBREHAT
        */
        [Fact]
        public void ShouldShiftCharacters()
        {
            RotEncryptor("A").Should().Be("N");
            RotEncryptor("B").Should().Be("O");
        }

        [Fact]
        public void ShouldConvertToUpperCase ()
        {
            RotEncryptor("a").Should().Be("N");
        }

        [Fact]
        public void ShouldConvertWord()
        {
            RotEncryptor("dEf").Should().Be("QRS");
        }

        [Fact]
        public void ShouldWrapAroundAlphabet()
        {
            RotEncryptor("xyz").Should().Be("KLM");
        }

        [Fact]

        public void ShouldOnlyConvertLetters()
        {
            RotEncryptor("Hello, World").Should().Be("URYYB, JBEYQ");
        }

        [Fact]
        public void ShouldConvertUmlautCharactors()
        {
            RotEncryptor("Großraumbüroklimagerätestörung").Should().Be("TEBFFENHZOHREBXYVZNTRENRGRFGBREHAT");
        }

        [Fact]
        public void ShouldShiftBy2()
        {
            RotEncryptor("C", 2).Should().Be("E");
        }

        [Fact]
        public void ShouldShiftBy53()
        {
            RotEncryptor("A", 53).Should().Be("B");
        }

        [Fact]
        public void ShouldShiftDigits()
        {
            RotEncryptor("0", 2).Should().Be("2");
        }

        [Fact]
        public void ShouldShiftDigitsAroundDigitsEnd()
        {
            RotEncryptor("9", 14).Should().Be("3");
        }

        [Fact]
        public void ShouldShiftDigitsAndLetters()
        {
            RotEncryptor("A3", 2).Should().Be("C5");
        }

        private string RotEncryptor(string input, int shiftBy = 13)
        {
            return new RotEncryptor(shiftBy).Encrypt(input);
        }

    }
}

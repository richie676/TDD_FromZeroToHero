using FluentAssertions;
using System;
using System.Text;
using Xunit;

namespace TDD_ROT13
{
    public class Rot13Test
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
            Rot13Encryptor("A").Should().Be("N");
        }

        [Fact]
        public void ShouldShiftSingleCharacter()
        {
            Rot13Encryptor("B").Should().Be("O");
        }

        [Fact]
        public void ShouldConvertToUpperCase ()
        {
            Rot13Encryptor("a").Should().Be("N");
        }

        [Fact]
        public void ShouldConvertWord()
        {
            Rot13Encryptor("dEf").Should().Be("QRS");
        }

        [Fact]
        public void ShouldWrapAroundAlphabet()
        {
            Rot13Encryptor("xyz").Should().Be("KLM");
        }

        [Fact]
        public void ShouldOnlyConvertLetters()
        {
            Rot13Encryptor("Hello, World").Should().Be("URYYB, JBEYQ");
        }
        
        private string Rot13Encryptor(string input)
        {
            return new Rot13Encryptor().Encrypt(input);
        }


    }
}

using System;
using System.Text;

namespace TDD_ROT13
{
    internal class RotEncryptor
    {
        private int ShiftBy = 13;
        private const int LengthOfAlphabet = 26;
        private const char LastLetterOfAlphabet = 'Z';
        private const int LengthOfDigits = 10;
        private const char LastDigit = '9';

        public RotEncryptor()
        {
        }

        public RotEncryptor(int shiftBy)
        {
            ShiftBy = shiftBy;
        }

        internal string Encrypt(string input)
        {
            var characters = PrepareForEncryption(input).ToCharArray();
            StringBuilder encryptedValue = new StringBuilder();
            foreach (var character in characters)
            {
                encryptedValue.Append(EncrypCharacter(character));
            }

            return encryptedValue.ToString();
        }

        private string PrepareForEncryption(string input)
        {
            string uppercaseInput = input.ToUpper();
            uppercaseInput = uppercaseInput.Replace("Ä", "AE")
                                           .Replace("Ö", "OE")
                                           .Replace("Ü", "UE")
                                           .Replace("ß", "SS");
            return uppercaseInput;
        }

        private char EncrypCharacter(char character)
        {
            if (Char.IsLetter(character))
            {
                character = Shift(character, LengthOfAlphabet, LastLetterOfAlphabet);
            }
            else if (Char.IsDigit(character))
            {
                character = Shift(character, LengthOfDigits, LastDigit);
            }

            return character;
        }

        private char Shift(char character, int lengthLimit, char lastCharacter)
        {
            character = ShiftCharacter(character, ShiftBy % lengthLimit);

            if (character > lastCharacter)
            {
                character = ShiftCharacter(character, -lengthLimit);
            }

            return character;
        }

        private char ShiftCharacter(char character, int shiftBy)
        {
            return (char)(character + shiftBy);
        }
    }
}
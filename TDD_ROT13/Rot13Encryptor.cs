using System;
using System.Text;

namespace TDD_ROT13
{
    internal class Rot13Encryptor
    {
        public Rot13Encryptor()
        {
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

        private static char EncrypCharacter(char character)
        {
            //guard clause
            if (!Char.IsLetter(character))
                return character;

            character = ShiftCharacter(character, 13);
            if (character > 'Z')
            {
                character = ShiftCharacter(character, -26);
            }

            return character;
        }

        private static char ShiftCharacter(char character, int shiftBy)
        {
            return (char)(character + shiftBy);
        }
    }
}
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
            var characters = input.ToUpper().ToCharArray();
            StringBuilder encryptedValue = new StringBuilder();
            foreach (var character in characters)
            {
                encryptedValue.Append(EncrypCharacter(character));
            }

            return encryptedValue.ToString();
        }

        private static char EncrypCharacter(char character)
        {
            if (Char.IsLetter(character))
            {
                character = ShiftCharacter(character, 13);
                if (character > 'Z')
                {
                    character = ShiftCharacter(character, -26);
                }
            }

            return character;
        }

        private static char ShiftCharacter(char character, int shiftBy)
        {
            return (char)(character + shiftBy);
        }
    }
}
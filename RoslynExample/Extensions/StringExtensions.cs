using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static class StringExtensions
    {
        public static string LowerCaseFirstLetter(this string input)
        {
            if (string.IsNullOrEmpty(input))
                return string.Empty;

            char[] characterArray = input.ToCharArray();
            characterArray[0] = char.ToLower(characterArray[0]);
            return new string(characterArray);
        }
    }
}

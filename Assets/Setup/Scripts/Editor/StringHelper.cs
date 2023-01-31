using System;
using System.Collections.Generic;

namespace Setup.Scripts.Editor {
    public static class StringHelper {
        public static string ToPascalCase(string input) {
            char[] charArray = input.ToCharArray();
            List<char> results = new List<char>();

            // Loop over every space in the array
            for (int i = 0; i < charArray.Length; i++) {
                char currentChar = charArray[i];
                
                if (currentChar == ' ') continue;
                
                if (i == 0) {
                    results.Add(char.ToUpper(currentChar));
                    continue;
                }

                char previousChar = charArray[i - 1];
                if (previousChar == ' ') {
                    results.Add(char.ToUpper(currentChar));
                }
                else {
                    results.Add(currentChar);
                }
            }

            return String.Join("", results);
        }
    }
}
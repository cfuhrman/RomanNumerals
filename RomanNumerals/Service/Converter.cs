namespace RomanNumerals.Service
{
    internal class Converter
    {
        /// <summary>
        ///     Contains Roman Numeral to base10 Integer conversions
        /// </summary>
        private static Dictionary<string, int> conversionTable = new Dictionary<string, int>
        {
            {"I", 1},
            {"V", 5},
            {"X", 10},
            {"L", 50},
            {"C", 100},
            {"D", 500},
            {"M", 1000}
        };

        /// <summary>
        ///     Converts given input value string to either a Roman Numeral or Integer string based on given input.
        ///
        ///     Note it is the responsibility of the calling method to convert any strings representing a base10 integer value
        ///     to an integer data type.
        /// </summary>
        /// <param name="inputValue"></param>
        /// <returns>string</returns>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public static string convert(string inputValue)
        {
            int base10Integer;
            bool validInteger = int.TryParse(inputValue, out base10Integer);

            return validInteger ? convertToRoman(base10Integer) : convertToBase10(inputValue).ToString();
        }

        /// <summary>
        ///     Converts given base 10 integer to Roman Numeral equivalent
        /// </summary>
        /// <param name="base10Integer"></param>
        /// <returns>string</returns>
        protected static string convertToRoman(int base10Integer)
        {
            int quotient;
            int remainder;
            int divided = base10Integer;
            string romanNumber = "";
            string[] reversed = conversionTable.Keys.Reverse().ToArray();

            Dictionary<string, string> romanReplacements = new Dictionary<string, string>
            {
                {"CCCC", "CD"},
                {"DCD",  "CM"},
                {"XXXX", "XL"},
                {"LXL",  "XC"},
                {"IIII", "IV"},
                {"VIV",  "IX"}
            };

            // Build initial Roman Number
            foreach (var key in reversed)
            {
                quotient = Math.DivRem(divided, conversionTable[key], out remainder);

                for (int i = 0; i < quotient; i++)
                {
                    romanNumber += key;
                }

                divided = remainder;
            }

            // Sanitize Roman Number
            foreach (var item in romanReplacements)
            {
                romanNumber = romanNumber.Replace(item.Key, item.Value);
            }

            return romanNumber;
        }

        /// <summary>
        ///     Converts given Roman Number into base10 Integer equivalent.
        /// </summary>
        /// <param name="romanNumber"></param>
        /// <returns>int</returns>
        /// <exception cref="IndexOutOfRangeException"></exception>
        protected static int convertToBase10(string romanNumber)
        {
            int base10Number = 0;
            char currentChar;
            char previousChar = '\0';
            Stack<char> charStack = new Stack<char>(romanNumber.ToCharArray());

            while (charStack.Count > 0)
            {
                currentChar = charStack.Pop();

                if (!conversionTable.ContainsKey(currentChar.ToString()))
                    throw new IndexOutOfRangeException($"Character '{currentChar.ToString()}' is not a valid roman numeral");

                if (previousChar == '\0')
                {
                    base10Number = conversionTable[currentChar.ToString()];
                    previousChar = currentChar;
                }
                else if (conversionTable[currentChar.ToString()] < conversionTable[previousChar.ToString()])
                {
                    // Note that we do not set previousChar to currentChar since we need to handle values such as "IIV"
                    base10Number -= conversionTable[currentChar.ToString()];
                }
                else
                {
                    base10Number += conversionTable[currentChar.ToString()];
                    previousChar = currentChar;
                }
            }

            return base10Number;
        }
    }
}

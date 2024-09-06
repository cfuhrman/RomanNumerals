
internal class Program
{
    private static void Main(string[] args)
    {
        string inputValue;
        int base10Numeral;
        string outputValue;

        if (args.Length == 0)
        {
            Console.WriteLine("Error: First argument must be a string representing either an integer value or a roman numeral");
            return;
        }

        inputValue = args[0];

        if (int.TryParse(inputValue, out base10Numeral))
        {
            outputValue = RomanNumerals.BPA.Convert.convert(inputValue);
            Console.WriteLine($"Base 10 Integer {inputValue} converts to Roman Numeral \'{outputValue}\'");
        }
        else
        {
            outputValue = RomanNumerals.BPA.Convert.convert(inputValue);
            Console.WriteLine($"Roman Numeral \'{inputValue}\' converts to base 10 Integer {outputValue}");
        }
        // Console.WriteLine("Hello, World!");
    }
}
/**
 * Program.cs
 *
 * Copyright (c) 2024 Christopher M. Fuhrman
 * All rights reserved.
 *
 * This program is free software; you can redistribute it and/or
 * modify it under terms of the Simplified BSD License (also
 * known as the "2-Clause License" or "FreeBSD License".)
 *
 * Created on Tue Aug 12 22:44:57 2024 UTC
 */

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
            outputValue = RomanNumerals.Service.Converter.convert(inputValue);
            Console.WriteLine($"Base 10 Integer {inputValue} converts to Roman Numeral \'{outputValue}\'");
        }
        else
        {
            outputValue = RomanNumerals.Service.Converter.convert(inputValue);
            Console.WriteLine($"Roman Numeral \'{inputValue}\' converts to base 10 Integer {outputValue}");
        }
        // Console.WriteLine("Hello, World!");
    }
}

/* Program.cs ends here */

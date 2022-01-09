using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TextCopy;

namespace BinaryConverter
{
    internal class Program
    {
        static Clipboard cb = new Clipboard();
        static void Main(string[] args)
        {
            Console.Title = "Binary Converter";
            while (true)
            {
                string cbText = cb.GetText();
                if (cbText != null)
                {
                    if (shouldConvertToBinary(cbText) == true)
                    {
                        TextToBinary();
                    }
                    else
                    {
                        ConversionBetweenTextOrBinary(cbText);
                    }
                }
                else
                {
                    TextToBinary();
                }
                Console.ReadLine();
                Console.Clear();
            }
        }

        private static void ConversionBetweenTextOrBinary(string cbText)
        {
            Console.WriteLine("Binary data detected, should it be converted to text? Write y/yes to confirm: ");
            string input = Console.ReadLine();
            if (input == "y" || input == "yes")
            {
                Console.WriteLine(BinaryConverter.ToText(cbText));
            }
            else
            {
                Console.Clear();
                Console.WriteLine("You choosed no, type the input text which should be converted to binary.");
                Console.WriteLine();
                TextToBinary();
            }
        }

        private static void TextToBinary()
        {
            Console.WriteLine("Input: ");
            string text = Console.ReadLine();
            Console.WriteLine(BinaryConverter.ToBinary(text));
        }


        private static bool shouldConvertToBinary(string input)
        {
            foreach (var c in input)
            {
                if ((c.ToString() != "0") && (c.ToString() != "1"))
                {
                    return true;
                }
            }
            return false;
        }

     

      
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryConverter
{
    public class BinaryConverter
    {
        public static string ToText(string binary)
        {
            var text = GetBytesFromBinaryString(binary);
            return Encoding.ASCII.GetString(text);
        }

        public static string ToBinary(string input)
        {
            input = reverseString(input);
            BitArray bitArray = new BitArray(Encoding.UTF8.GetBytes(input));
            string bits = "";
            bits = writeBits(bits, bitArray);
            return reverseString(bits);
        }

        private static string writeBits(string bits, BitArray bitArray)
        {
            foreach (bool bit in bitArray)
            {
                if (bit == true)
                {
                    bits += "1";
                }
                else
                {
                    bits += "0";
                }
            }

            return bits;
        }

        private static Byte[] GetBytesFromBinaryString(String binary)
        {
            var list = new List<Byte>();

            for (int i = 0; i < binary.Length; i += 8)
            {
                String t = binary.Substring(i, 8);

                list.Add(Convert.ToByte(t, 2));
            }

            return list.ToArray();
        }

        private static string reverseString(string str)
        {
            string reversedString = "";
            foreach (char c in str)
            {
                reversedString = c + reversedString;
            }

            return reversedString;
        }
    }
}

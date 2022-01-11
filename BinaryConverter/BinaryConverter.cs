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
            binary = binary.Replace(" ", "");
            byte[] text = GetBytesFromBinaryString(binary);
            if (text != null)
            {
                return Encoding.ASCII.GetString(text);
            }
            else
            {
                return null;
            }
        }

        public static string ToBinary(string input)
        {
            input = ReverseString(input);
            BitArray bitArray = new BitArray(Encoding.UTF8.GetBytes(input));
            string bits = WriteBits(bitArray);
            return ReverseString(bits);
        }

        private static string WriteBits(BitArray bitArray)
        {
            string bits = string.Empty;
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

        private static byte[] GetBytesFromBinaryString(string binaryString)
        {
            if (binaryString.Length % 8 == 0)
            {
                byte[] byteArray = new byte[binaryString.Length / 8];
                for (int i = 0; i < binaryString.Length; i += 8)
                {
                    string t = binaryString.Substring(i, 8);
                    byteArray[i /8] = Convert.ToByte(t, 2);
                }
                return byteArray;
            }
            else
            {
                return null;
            }
        }

        private static string ReverseString(string str)
        {
            char[] chars = str.ToCharArray();
            Array.Reverse(chars);
            return new string(chars);
        }
    }
}

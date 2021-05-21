using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Following_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int? example = NextBiggerThan(124121133);
            Console.WriteLine(example);
        }
        public static int? NextBiggerThan(int number)
        {
            if (number < 0)
            {
#pragma warning disable CA2208 // Instantiate argument exceptions correctly
                throw new ArgumentException();
#pragma warning restore CA2208 // Instantiate argument exceptions correctly
            }

            if (number >= int.MaxValue || number <= int.MinValue)
            {
                return null;
            }

            int[] myArray = new int[number.ToString().Length];
            for (int i = myArray.Length - 1; i > -1; i--)
            {
                myArray[i] = number % 10;
                number /= 10;
            }

            int index = IndexSearching(myArray);

            if (index == -1)
            {
                return null;
            }

            int temp = 0;
            if (index < myArray.Length - 1)
            {
                temp = myArray[index];
                myArray[index] = myArray[index + 1];
                myArray[index + 1] = temp;
                Array.Sort(myArray, index + 1, myArray.Length - index - 1);
            }

            int result = 0;

            for (int i = 0; i < myArray.Length; i++)
            {
                result += (int)(myArray[i] * Math.Pow(10, myArray.Length - 1 - i));
            }

            return result;
        }

        private static int IndexSearching(int[] temp)
        {
            for (int i = temp.Length - 1; i > 0; i--)
            {
                if (temp[i] > temp[i - 1])
                {
                    return i - 1;
                }
            }

            return -1;
        }
    }
}

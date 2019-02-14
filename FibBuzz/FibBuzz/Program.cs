using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibBuzz
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Build list of desired lengths to build Fibonacci sequences against
            List<int> fibLengthList = new List<int>();
            fibLengthList.Add(3);
            fibLengthList.Add(4);
            fibLengthList.Add(5);
            fibLengthList.Add(20);

            foreach (int fibLength in fibLengthList)
            {
                string fibParseResult = BuildFibonnaciSequence(fibLength);
                Console.WriteLine($"Fibonnaci Parse Result: {fibParseResult}");
                Console.WriteLine();
            }

            Console.ReadLine();
        }

        /// <summary>
        /// Builds a Fibonnaci sequence to a given length
        /// </summary>
        /// <param name="length">The desired length</param>
        private static string BuildFibonnaciSequence(int length)
        {
            // Table built on the F(n) factorization to produce results as seen here: http://www.maths.surrey.ac.uk/hosted-sites/R.Knott/Fibonacci/fibtable.html

            Dictionary<int, int> sequence = new Dictionary<int, int>();

            for (int x = 0; x < length; x++)
            {
                int currentVal = 0;

                if (sequence.Count > 2)
                {
                    currentVal = sequence[x - 2] + sequence[x - 1];
                }
                else if (sequence.Count == 2)
                {
                    currentVal = 2;
                }
                else if (sequence.Count == 1)
                {
                    currentVal = 1;
                }
                else if (sequence.Count == 0)
                {
                    currentVal = 0;
                }
                sequence.Add(x, currentVal);
            }

            int fibNumber = sequence[length - 1];

            Console.WriteLine($"Desired Fibonacci Length: {length}");
            Console.WriteLine($"Fibonacci Number: {fibNumber}");
            return FibBuzz(fibNumber);
        }

        /// <summary>
        /// Returns a FizzBuzz string result based on a given number
        /// </summary>
        /// <param name="n">The number to process</param>
        /// <returns></returns>
        private static string FibBuzz(int n)
        {
            string result = "";

            if (n % 15 == 0)
            {
                result = "Fizz Buzz";
            }
            else if (n % 5 == 0)
            {
                result = "Buzz";
            }
            else if (n % 3 == 0)
            {
                result = "Fizz";
            }
            else
            {
                result = n.ToString();
            }

            return result;
        }
    }
}

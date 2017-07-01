using System;
using System.Collections;

namespace Logic
{
    public class FindingNumber
    {
        #region NextBiggerNumber (public)
        /// <summary>
        /// Method search the nearest greatest integer which consists of the
        /// digits of the input number.
        /// </summary>
        /// <param name="number">Initial number.</param>
        /// <returns>The nearest greatest integer (returns -1, if integer doesn't exist).</returns>
        public static int NextBiggerNumber(int number)
        {
            if (!CheckNumber(number))
            {
                return -1;
            }
            int[] numberArray = ToDigitArray(number);
            Array.Sort(numberArray);
            while (true)
            {
                number++;
                int[] newNumberArray = ToDigitArray(number);
                Array.Sort(newNumberArray);
                if (IsEquals(numberArray, newNumberArray))
                {
                    return number;
                }
            }
        }
        #endregion

        #region NextBiggerNumber Helpers (private)
        /// <summary>
        /// Method checks if int arrays are equal.
        /// </summary>
        /// <param name="first">First int array.</param>
        /// <param name="second">Second int array.</param>
        /// <returns>Returns true, if arrays are equal, and false otherwise.</returns>
        private static bool IsEquals(int[] first, int[] second)
        {
            IStructuralEquatable se = first;
            return se.Equals(second, StructuralComparisons.StructuralEqualityComparer);
        }

        /// <summary>
        /// Method checks, if for input number exists the nearest greatest integer 
        /// which consists of the digits of the input number.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private static bool CheckNumber(int number)
        {
            int[] numberArray = ToDigitArray(number);
            int[] newNumberArray = ToDigitArray(number);
            Array.Sort(newNumberArray);
            Array.Reverse(newNumberArray);
            return !IsEquals(numberArray, newNumberArray);
        }

        /// <summary>
        /// Method divides a number into an array of digits.
        /// </summary>
        /// <param name="number">Integer, which will be divided.</param>
        /// <returns>Array of digits of the number.</returns>
        private static int[] ToDigitArray(int number)
        {
            int[] result = new int[GetDigitArrayLength(number)];
            for (int i = result.Length - 1; i >= 0; i--)
            {
                result[i] = number % 10;
                number /= 10;
            }
            return result;
        }

        /// <summary>
        /// Method returns quantity of digits in the number.
        /// </summary>
        /// <param name="number">Method will count quantity of digits in this number.</param>
        /// <returns>Quantity of digits.</returns>
        private static int GetDigitArrayLength(int number)
        {
            int length = 0;
            if (number == 0) return 1;
            while (number > 0)
            {
                length++;
                number /= 10;
            }
            return length;
        }
        #endregion
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public static class NumberExtension
    {
        private static int maxInt = 0x7fffffff;
        private static int quantityOfBits = 31;

        #region Insertion
        /// <summary>
        /// Method inserts one int number into another.
        /// </summary>
        /// <param name="first">The int number, at which the second will be inserted.</param>
        /// <param name="second">The int number, which will be inserted.</param>
        /// <param name="startPosition">The index, from which method inserts the second number into the first.</param>
        /// <param name="finishPosition">The index, to which method inserts the second number into the first.</param>
        /// <returns></returns>
        public static int Insertion(int first, int second, int startPosition, int finishPosition)
        {
            CheckPosition(startPosition, finishPosition);

            #region with BitArray
            //BitArray arrFirst = new BitArray(new int[] { first });
            //BitArray arrSecond = new BitArray(new int[] { second });

            //for (int i = startPosition; i <= finishPosition; i++)
            //{
            //    arrFirst[i] = arrSecond[i - startPosition];
            //}

            //byte[] array = new byte[32];
            //arrFirst.CopyTo(array, 0);
            //return BitConverter.ToInt32(array, 0);
            #endregion

            #region with bitwise operations
            int maskSecondNumber = maxInt >> quantityOfBits - (finishPosition - startPosition + 1);
            maskSecondNumber &= second;
            maskSecondNumber <<= startPosition;

            int maskLeft = maxInt << (finishPosition + 1);
            maskLeft &= first;

            int maskRight = maxInt >> quantityOfBits - startPosition;
            maskRight &= first;

            return maskLeft ^ maskSecondNumber ^ maskRight;
            #endregion
        }

        /// <summary>
        /// Method checks input values of startPosition and finishPosition.
        /// </summary>
        /// <param name="startPosition">The index, from which method inserts the second number into the first.</param>
        /// <param name="finishPosition">The index, to which method inserts the second number into the first.</param>
        private static void CheckPosition(int startPosition, int finishPosition)
        {
            if (startPosition < 0 || startPosition > 31)
            {
                throw new ArgumentOutOfRangeException("Incorrect input start positions.");
            }
            if (finishPosition < 0 || finishPosition > 31)
            {
                throw new ArgumentOutOfRangeException("Incorrect input finish positions.");
            }
            if (finishPosition < startPosition)
            {
                throw new ArgumentException("Incorrect input positions.");
            }
        }
        #endregion

        #region NextBiggerNumber
        /// <summary>
        /// Method searches the nearest greatest integer which consists of digits of the input number.
        /// </summary>
        /// <param name="number">Initial number.</param>
        /// <returns>The nearest greatest integer (returns -1, if integer doesn't exist).</returns>
        public static int NextBiggerNumber(int number)
        {
            if (!CheckNumber(number))
            {
                return -1;
            }
            string numberString = number.ToString();
            char[] numberCharArray = numberString.ToCharArray();
            Array.Sort(numberCharArray);
            while (true)
            {
                number++;
                string newNumberString = number.ToString();
                char[] newNumberCharArray = newNumberString.ToCharArray();
                Array.Sort(newNumberCharArray);
                if (string.Concat(newNumberCharArray) == string.Concat(numberCharArray))
                {
                    return number;
                }
            }
        }

        /// <summary>
        /// Method checks if for input number exists the nearest greatest integer which consists of the digits of the input number.
        /// </summary>
        /// <param name="number">Integer, which will be checked.</param>
        /// <returns>True, if for input number exists the nearest greatest integer, and false otherwise.</returns>
        private static bool CheckNumber(int number)
        {
            string numberString = number.ToString();

            string newNumberString = number.ToString();
            char[] newNumberCharArray = newNumberString.ToCharArray();
            Array.Sort(newNumberCharArray);
            Array.Reverse(newNumberCharArray);

            return numberString != string.Concat(newNumberCharArray);
        }
        #endregion

        #region NewtonMethod
        /// <summary>
        /// Method for finding the root of n degree of a number with a given accuracy.
        /// </summary>
        /// <param name="number">Number for taking a root.</param>
        /// <param name="n">Degree.</param>
        /// <param name="accuracy">Calculation accuracy.</param>
        /// <returns></returns>
        public static double NewtonMethod(double number, double n, double accuracy = 0.0000001)
        {
            double x0 = number / n;
            double x1 = (1 / n) * ((n - 1) * x0 + (number / Math.Pow(x0, n - 1)));

            while(Math.Abs(x1 - x0) > accuracy)
            {
                x0 = x1;
                x1 = (1 / n) * ((n - 1) * x0 + (number / Math.Pow(x0, n - 1)));
            }

            return x1;
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class InsertionNumber
    {
        #region Insert (public)
        /// <summary>
        /// Method inserts one int number into another.
        /// </summary>
        /// <param name="first">The int number, at which the second will be inserted.</param>
        /// <param name="second">The int number, which will be inserted.</param>
        /// <param name="startPosition">The int number, from which it will be inserted the second number into the first.</param>
        /// <param name="finishPosition">The int number, to which it will be inserted the second number into the first.</param>
        /// <returns></returns>
        public static int Insert(int first, int second, int startPosition, int finishPosition)
        {
            CheckPosition(startPosition, finishPosition);
            int[] arrFirst = ToBitArray(first);
            int[] arrSecond = ToBitArray(second);

            for (int i = startPosition; i <= finishPosition; i++)
            {
                arrFirst[i] = arrSecond[i - startPosition];
            }
            Array.Reverse(arrFirst);
            return Convert.ToInt32(string.Join("", arrFirst), 2);
        }
        #endregion

        #region Insert Helpers (private)
        /// <summary>
        /// Method transform the number into array of bits.
        /// </summary>
        /// <param name="number">Int number to transform.</param>
        /// <returns>Array of number's bits.</returns>
        private static int[] ToBitArray(int number)
        {
            int[] result = new int[8 * sizeof(int)];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = number & 1;
                number >>= 1;
            }
            return result;
        }

        /// <summary>
        /// Method checks input values of startPosition and finishPosition.
        /// </summary>
        /// <param name="startPosition">The int number, from which it will be inserted the second number into the first.</param>
        /// <param name="finishPosition">The int number, from which it will be inserted the second number into the first.</param>
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
    }
}

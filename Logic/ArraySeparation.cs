using System;

namespace Logic
{
    public class ArraySeparation
    {
        #region FindSeparatorIndex (public)
        /// <summary>
        /// Method searches index of the element, for which the sum of right elements is equal of the sum of left elements.
        /// </summary>
        /// <param name="array">Array of int numbers.</param>
        /// <returns>Index of found element (returns -1, if element doesn't exist).</returns>
        public static int FindSeparatorIndex(int[] array)
        {
            CheckArray(array);
            for (int i = 1; i < array.Length - 1; i++)
            {
                if (FindSum(array, 0, i - 1) == FindSum(array, i + 1, array.Length - 1))
                {
                    return i;
                }
            }
            return -1;
        }
        #endregion

        #region FindSeparatorIndex Helpers (private)
        /// <summary>
        /// Method finds the sum of elements in int array from startPosition to finishPosition.
        /// </summary>
        /// <param name="array">Array of int numbers.</param>
        /// <param name="startPosition">Index in array, from which the method will calculate the sum.</param>
        /// <param name="finishPosition">Index in array, to which the method will calculate the sum.</param>
        /// <returns>Sum of elements in array.</returns>
        private static int FindSum(int[] array, int startPosition, int finishPosition)
        {
            int result = 0;
            for (int i = startPosition; i <= finishPosition; i++)
            {
                result += array[i];
            }
            return result;
        }

        /// <summary>
        /// Methos checks the input array. 
        /// </summary>
        /// <param name="array">Array of int elements.</param>
        private static void CheckArray(int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException("Array is null.");
            }
            if (array.Length == 0)
            {
                throw new ArgumentException("Array is empty.");
            }
            if (array.Length >= 1000)
            {
                throw new ArgumentException("Array is unsuitable.");
            }
        }
    }
    #endregion
}

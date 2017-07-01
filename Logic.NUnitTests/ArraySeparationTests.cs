using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic;

namespace Logic.NUnitTests
{
    [TestFixture]
    public class ArraySeparationTests
    {
        [TestCase(new int[] {1,2,3,4,3,2,1}, ExpectedResult = 3)]
        [TestCase(new int[] { 1, 2, 3, 4, 3, 2, 1, 0, 0 }, ExpectedResult = 3)]
        [TestCase(new int[] { 1, 100, 50, -51, 1, 1 }, ExpectedResult = 1)]
        [TestCase(new int[] { 1, 2, 3, 4, 3, 2 }, ExpectedResult = -1)]
        public int FindSeparatorIndex_CorrectInputValues_PositiveTest(int[] array)
        {
            return ArraySeparation.FindSeparatorIndex(array);
        }

        [TestCase(new int[] { })]
        public void FindSeparatorIndex_InputArrayIsEmpty_ThrowsArgumentException(int[] array)
        {
            Assert.Throws<ArgumentException>(() => ArraySeparation.FindSeparatorIndex(array));
        }

        [TestCase(null)]
        public void FindSeparatorIndex_InputArrayIsNull_ThrowsArgumentNullException(int[] array)
        {
            Assert.Throws<ArgumentNullException>(() => ArraySeparation.FindSeparatorIndex(array));
        }
    }
}

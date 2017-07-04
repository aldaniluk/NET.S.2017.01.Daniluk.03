using NUnit.Framework;
using System;

namespace Logic.NUnitTests
{
    [TestFixture]
    public class NumberExtensionTests
    {
        #region Insertion Tests
        [TestCase(8, 15, 0, 0, ExpectedResult = 9)]
        [TestCase(0, 15, 30, 30, ExpectedResult = 1073741824)]
        [TestCase(0, 15, 0, 30, ExpectedResult = 15)]
        [TestCase(int.MaxValue, int.MaxValue, 3, 5, ExpectedResult = int.MaxValue)]
        [TestCase(15, int.MaxValue, 3, 5, ExpectedResult = 63)]
        [TestCase(15, 15, 1, 3, ExpectedResult = 15)]
        [TestCase(15, 15, 1, 4, ExpectedResult = 31)]
        [TestCase(15, -15, 0, 4, ExpectedResult = 31)] //17
        [TestCase(15, -15, 1, 4, ExpectedResult = 15)] //3
        [TestCase(-8, -15, 1, 4, ExpectedResult = -6)] //-30
        public int Insertion_CorrectInputValues_PositiveTest(int first, int second, int startPosition, int finishPosition)
        {
            return NumberExtension.Insertion(first, second, startPosition, finishPosition);
        }

        [TestCase(8, 15, -1, 5)]
        [TestCase(8, 15, 5, -1)]
        [TestCase(8, 15, 32, 5)]
        [TestCase(8, 15, 5, 32)]
        public void Insertion_InputValuesGreater31OrLess0_ThrowsArgumentOutOfRangeException(int first, int second, int startPosition, int finishPosition)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => NumberExtension.Insertion(first, second, startPosition, finishPosition));
        }

        [TestCase(8, 15, 7, 5)]
        [TestCase(8, 15, 1, 0)]
        public void Insertion_InputValuesGreater31OrLess0_ThrowsArgumentException(int first, int second, int startPosition, int finishPosition)
        {
            Assert.Throws<ArgumentException>(() => NumberExtension.Insertion(first, second, startPosition, finishPosition));
        }
        #endregion

        #region NextBiggerNumber Tests
        [TestCase(12, ExpectedResult = 21)]
        [TestCase(513, ExpectedResult = 531)]
        [TestCase(2017, ExpectedResult = 2071)]
        [TestCase(414, ExpectedResult = 441)]
        [TestCase(144, ExpectedResult = 414)]
        [TestCase(1234321, ExpectedResult = 1241233)]
        [TestCase(1234126, ExpectedResult = 1234162)]
        [TestCase(3456432, ExpectedResult = 3462345)]
        [TestCase(10, ExpectedResult = -1)]
        [TestCase(20, ExpectedResult = -1)]
        public int NextBiggerNumber_CorrectInputValues_PositiveTest(int number)
        {
            return NumberExtension.NextBiggerNumber(number);
        }
        #endregion
    }
}

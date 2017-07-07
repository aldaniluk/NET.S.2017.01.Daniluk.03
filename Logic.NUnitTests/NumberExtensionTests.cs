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

        #region NewtonMethod Tests
        [TestCase(10, 3, 0.01, 2.15443532640779)]
        [TestCase(9, 0.5, 0.01, 81)]
        [TestCase(3, 12, 0.01, 1.09588034828661)]
        [TestCase(25, 2, 0.1, 5.00001295304868)]
        [TestCase(1.34, 3, 0.001, 1.10247461422151)]
        [TestCase(2.5, 0.5, 0.001, 6.249999998476)]
        [TestCase(-4, 3, 0.001, -1.58740105196984)]
        [TestCase(-1.5, 5, 0.001, -1.08447204695422)]
        public void NewtonMethod_CorrectInputValues_PositiveTest(double number, double n, double accuracy, double ExpectedResult)
        {
            double actual = NumberExtension.NewtonMethod(number, n, accuracy);
            double expected = ExpectedResult;
            Assert.AreEqual(actual, expected, 0.0000001);
        }

        [TestCase(10, 3, 2.15443469003188)]
        [TestCase(3, 12, 1.09587269113524)]
        [TestCase(9, 0.5, 81)]
        public void NewtonMethod_DefaultAccuracy_PositiveTest(double number, double n, double ExpectedResult)
        {
            double actual = NumberExtension.NewtonMethod(number, n);
            double expected = ExpectedResult;
            Assert.AreEqual(actual, expected, 0.0000001);
        }
        #endregion
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;

namespace Logic.Tests
{
    [TestClass]
    public class InsertionNumberTests
    {
        public TestContext TestContext { get; set; }

        [DataSource(
            "Microsoft.VisualStudio.TestTools.DataSource.XML",
            "|DataDirectory|\\Numbers.xml",
            "TestCase",
            DataAccessMethod.Sequential)]
        [DeploymentItem("Logic.Tests\\Numbers.xml")]

        [TestMethod]
        public void MSUnitTest_Insert_CorrectInputValues_PositiveTest()
        {
            int expected = Convert.ToInt32(TestContext.DataRow["ExpectedResult"]);

            int firstNumber = Convert.ToInt32(TestContext.DataRow["FirstNumber"]);
            int secondNumber = Convert.ToInt32(TestContext.DataRow["SecondNumber"]);
            int startPosition = Convert.ToInt32(TestContext.DataRow["StartPosition"]);
            int finishPosition = Convert.ToInt32(TestContext.DataRow["FinishPosition"]);
            int actual = InsertionNumber.Insert(firstNumber, secondNumber, startPosition, finishPosition);

            Assert.AreEqual(expected, actual);
        }
    }
}

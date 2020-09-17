using Mathml.Operations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Mathml.UnitTests
{
    [TestClass]
    public class AdditionOperatorTests
    {
        [TestMethod]
        public void FindOperation_StringParameterIsEmpty_ReturnsEmptyString()
        {
            var addition = new AdditionOperator();
            var result = addition.FindOperation(string.Empty);
            Assert.AreEqual(string.Empty, result);
        }

        [TestMethod]
        public void FindOperation_StringDoesNotContainStopCharacter_ReturnsEmtpyString()
        {
            var addition = new AdditionOperator();
            var result = addition.FindOperation("no semi-colon");
            Assert.AreEqual(string.Empty, result);
        }

        [TestMethod]
        public void FindOperation_StringStartsWithStopCharacter_ReturnsStringWithStringLength()
        {
            var addition = new AdditionOperator();
            var result = addition.FindOperation(";started with semi-colon");
            Assert.AreEqual("sta", result);
        }

        [TestMethod]
        public void FindOperation_StringLongerThanStringLengthAfterStopCharacter_ReturnsStringWithStringLength()
        {
            var addition = new AdditionOperator();
            var result = addition.FindOperation("JACK;SUMMARY;ThisShouldPass");
            Assert.AreEqual("SUM", result);
        }

        [TestMethod]
        public void FindOperation_StringShorterThanStringLengthAfterStopCharacter_ReturnsEmptyString()
        {
            var addition = new AdditionOperator();
            var result = addition.FindOperation("JIMMYBUTLER;MJ");
            Assert.AreEqual(string.Empty, result);
        }

        [TestMethod]
        public void CalculateOperation_OperatorTextIsCorrect_ReturnStringShowingOperation()
        {
            var addition = new AdditionOperator();
            var result = addition.CalculateOperation(1, 2, "SUM");
            Assert.AreEqual(string.Format("{0} + {1} = {2}", 1, 2, 1 + 2), result);
        }

        [TestMethod]
        public void CalculateOperation_OperatorTextIsNotCorrect_ReturnsEmptyString()
        {
            var addition = new AdditionOperator();
            var result = addition.CalculateOperation(1, 2, "GUM");
            Assert.AreEqual(string.Empty, result);
        }


    }
}

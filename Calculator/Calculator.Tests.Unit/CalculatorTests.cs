using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Tests.Unit
{
    public class CalculatorTests
    {
        [TestCase(4, 2, 2)]
        [TestCase(-4, 2, -2)]
        [TestCase(4, -2, -2)]
        [TestCase(0, 3, 0)]
        [TestCase(5, 2, 2.5)]
        public void Divide_DivideTwoNumbers_ReturnsProperlyCalculated(double x, double y, double expectedResult)
        {
            var calculator = new Calculator();

            var result = calculator.Divide(x, y);

            Assert.AreEqual(expectedResult, result);
        }
        
        [Test]
        public void Divide_DivideWhenResultIsRepeatingDecimal()
        {
            var calculator = new Calculator();
            var result = calculator.Divide(1, 3);
            Assert.AreEqual(0.33333333333333331d, result);
        }

        [TestCase(2, 4, 0.5, 0.00001)]
        [TestCase(1, 3, 0.333, 0.001)]
        [TestCase(2, 3, 0.66667, 0.00001)]
        public void Divide_DivideWhenResultIsRepeatingDecimalWithTolerance(double x, double y, double expectedResult, double tolerance)
        {
            var calculator = new Calculator();
            var result = x / y;
            Assert.AreEqual(expectedResult, result, delta: tolerance);
        }

        [Test]
        public void Divide_DivideByZero_ThrowsException()
        {
            var calculator = new Calculator();
            Assert.Throws<DivideByZeroException>(() => calculator.Divide(2, 0));
        }

        [Test]
        public void Divide_WhenDivisionIsCompletedThenAnEventIsCalled()
        {
            var calculator = new Calculator();
            bool hasEventBeenCalled = false;

            calculator.Calculated += (sender, result) => hasEventBeenCalled = true;
            calculator.Divide(4, 2);

            Assert.IsTrue(hasEventBeenCalled);
        }

        [Test]
        public void Divide_WhenDivisionIsCompletedThenAnEventIsCalledAndResultIsPassedToEventArgs()
        {
            var calculator = new Calculator();
            double? quotient = null;

            calculator.Calculated += (sender, result) => quotient = result;
            calculator.Divide(4, 2);

            Assert.NotNull(quotient);
            Assert.AreEqual(2, quotient.Value);
        }
    }
}

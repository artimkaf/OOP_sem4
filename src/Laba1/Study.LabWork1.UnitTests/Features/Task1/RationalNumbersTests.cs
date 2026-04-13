using System;
using System.Collections.Generic;
using System.Text;

using Study.LabWork1.Features.Task1;

namespace Study.LabWork1.UnitTests.Features.Task1
{
    [TestFixture]
    internal class RationalNumberTests
    {
        [Test]
        [TestCase(5, 3, "5/3")]
        [TestCase(10, 20, "1/2")]
        [TestCase(-9, 4, "-9/4")]
        [TestCase(8, 8, "1")]
        [TestCase(0, 7, "0")]
        public void ToString_NormalFormat(int numerator, int denomenator, string format)
        {
            var x = new RationalNumbers(numerator, denomenator);

            Assert.That(x.ToString(), Is.EqualTo(format), $"Проверка формата вывода");
        }

        [Test]
        public void Constructor_ValidParameters()
        {
            var x = new RationalNumbers(5, 8);

            Assert.Multiple(() =>
            {
                Assert.That(x.GetNumerator, Is.EqualTo(5));
                Assert.That(x.GetDenominator, Is.EqualTo(8));
            });
        }

        [Test]
        public void Constructor_ZeroDenomerator()
        {
            Assert.Throws<DivideByZeroException>(() => new RationalNumbers(7, 0));
        }

        [Test]
        [TestCase(2, 3, 1, 6, 5, 6)]
        [TestCase(3, 5, 2, 5, 1, 1)]
        [TestCase(1, 4, -1, 2, -1, 4)]
        [TestCase(0, 1, 3, 7, 3, 7)]
        public void OperatorPlus(int n1, int d1, int n2, int d2, int expectedNum, int expectedDen)
        {
            var x1 = new RationalNumbers(n1, d1);
            var x2 = new RationalNumbers(n2, d2);
            var result = x1 + x2;

            Assert.Multiple(() =>
            {
                Assert.That(result.GetNumerator, Is.EqualTo(expectedNum));
                Assert.That(result.GetDenominator, Is.EqualTo(expectedDen));
            });
        }

        [Test]
        [TestCase(5, 6, 1, 6, 2, 3)]
        [TestCase(7, 8, 3, 8, 1, 2)]
        [TestCase(1, 3, 2, 3, -1, 3)]
        [TestCase(-1, 5, 3, 5, -4, 5)]
        public void OperatorMinus(int n1, int d1, int n2, int d2, int expectedNum, int expectedDen)
        {
            var x1 = new RationalNumbers(n1, d1);
            var x2 = new RationalNumbers(n2, d2);
            var result = x1 - x2;

            Assert.Multiple(() =>
            {
                Assert.That(result.GetNumerator, Is.EqualTo(expectedNum));
                Assert.That(result.GetDenominator, Is.EqualTo(expectedDen));
            });
        }

        [Test]
        [TestCase(3, 4, 4, 7, 3, 7)]
        [TestCase(-1, 2, 5, 6, -5, 12)]
        [TestCase(0, 9, 8, 3, 0, 1)]
        [TestCase(2, 3, 9, 4, 3, 2)]
        public void OperatorMultiply(int n1, int d1, int n2, int d2, int expectedNum, int expectedDen)
        {
            var x1 = new RationalNumbers(n1, d1);
            var x2 = new RationalNumbers(n2, d2);
            var result = x1 * x2;

            Assert.Multiple(() =>
            {
                Assert.That(result.GetNumerator, Is.EqualTo(expectedNum));
                Assert.That(result.GetDenominator, Is.EqualTo(expectedDen));
            });
        }

        [Test]
        [TestCase(3, 5, 2, 7, 21, 10)]
        [TestCase(4, 9, 8, 3, 1, 6)]
        [TestCase(1, 2, 1, 2, 1, 1)]
        public void OperatorDivide(int n1, int d1, int n2, int d2, int expectedNum, int expectedDen)
        {
            var x1 = new RationalNumbers(n1, d1);
            var x2 = new RationalNumbers(n2, d2);
            var result = x1 / x2;

            Assert.Multiple(() =>
            {
                Assert.That(result.GetNumerator, Is.EqualTo(expectedNum));
                Assert.That(result.GetDenominator, Is.EqualTo(expectedDen));
            });
        }

        [Test]
        public void OperatorDivide_ByZero()
        {
            var x1 = new RationalNumbers(5, 6);
            var x2 = new RationalNumbers(0, 3);
            Assert.Throws<DivideByZeroException>(() => { var result = x1 / x2; });
        }

        [Test]
        [TestCase(5, 7, -5, 7)]
        [TestCase(-8, 11, 8, 11)]
        [TestCase(0, 5, 0, 1)]
        public void OperatorUnaryMinus(int n, int d, int expectedNum, int expectedDen)
        {
            var x = new RationalNumbers(n, d);
            var result = -x;

            Assert.Multiple(() =>
            {
                Assert.That(result.GetNumerator, Is.EqualTo(expectedNum));
                Assert.That(result.GetDenominator, Is.EqualTo(expectedDen));
            });
        }

        [Test]
        [TestCase(3, 5, 6, 10, true)]
        [TestCase(2, 3, 4, 5, false)]
        [TestCase(-1, 2, -2, 4, true)]
        public void OperatorEquals(int n1, int d1, int n2, int d2, bool expected)
        {
            var x1 = new RationalNumbers(n1, d1);
            var x2 = new RationalNumbers(n2, d2);
            Assert.That(x1 == x2, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(2, 5, 3, 5, true)]
        [TestCase(7, 8, 3, 4, false)]
        [TestCase(-1, 3, 0, 1, true)]
        public void OperatorLessThan(int n1, int d1, int n2, int d2, bool expected)
        {
            var x1 = new RationalNumbers(n1, d1);
            var x2 = new RationalNumbers(n2, d2);
            Console.WriteLine("hi");
            Assert.That(x1 < x2, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(1, 4, 1, 3, true)]
        [TestCase(2, 3, 4, 6, true)]
        [TestCase(5, 6, 2, 3, false)]
        public void OperatorLessOrEqualsThan(int n1, int d1, int n2, int d2, bool expected)
        {
            var x1 = new RationalNumbers(n1, d1);
            var x2 = new RationalNumbers(n2, d2);
            Assert.That(x1 <= x2, Is.EqualTo(expected));
        }
    }
}

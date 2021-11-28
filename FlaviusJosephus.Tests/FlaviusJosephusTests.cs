using NUnit.Framework;
using System;
using System.Collections.Generic;
using FlaviusJosephusTask;

namespace FlaviusJosephus.Tests
{
    public class FlaviusJosephusTests
    {
        [Test]
        public void FlaviusJosephusCalculate_CountLessThenOne_ThrowArgumentException() =>
            Assert.Throws<ArgumentException>(() => FlaviusJosephusCalculate.Calculate(0, 50));

        [Test]
        public void FlaviusJosephusCalculate_StepLessThenOne_ThrowArgumentException() =>
            Assert.Throws<ArgumentException>(() => FlaviusJosephusCalculate.Calculate(50, 0));

        [TestCase(1, 1, ExpectedResult = new[] { 1 })]
        [TestCase(1, 10, ExpectedResult = new[] { 1 })]
        [TestCase(5, 2, ExpectedResult = new[] { 2, 4, 1, 5, 3 })]
        [TestCase(3, 6, ExpectedResult = new[] { 3, 2, 1 })]
        [TestCase(7, 2, ExpectedResult = new[] { 2, 4, 6, 1, 5, 3, 7 })]
        [TestCase(7, 3, ExpectedResult = new[] { 3, 6, 2, 7, 5, 1, 4 })]
        [TestCase(10, 6, ExpectedResult = new[] { 6, 2, 9, 7, 5, 8, 1, 10, 4, 3 })]
        [TestCase(10, 10, ExpectedResult = new[] { 10, 1, 3, 6, 2, 9, 5, 7, 4, 8 })]
        public IEnumerable<int> FlaviusJosephusCalculate_Tests(int count, int step) => FlaviusJosephusCalculate.Calculate(count, step);
    }
}
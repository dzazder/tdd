using MixTests.Tests.Unit.TestsData;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MixTests.Tests.Unit
{
    public class FluentBuilderTests
    {
        [TestCaseSource(
            typeof(AdditionTestData),
            nameof(AdditionTestData.AdditionCases))]
        public void AdditionTestWithExternaleData(int a, int b, int expectedResult)
        {
            Assert.That(a + b, Is.EqualTo(expectedResult));
        }

        [TestCaseSource(typeof(AdditionTestDataEnumerable))]
        public void AdditionTest(int a, int b, int expectedResult)
        {
            Assert.That(a + b, Is.EqualTo(expectedResult));
        }

        [TestCaseSource(typeof(AdditionTestData),
            nameof(AdditionTestData.AdditionCasesEnumerable))]
        public int AdditionTestWithTestCaseData(int a, int b)
        {
            return a + b;
        }
    }
}

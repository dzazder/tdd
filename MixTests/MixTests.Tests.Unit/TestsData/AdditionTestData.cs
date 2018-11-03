using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MixTests.Tests.Unit.TestsData
{
    public class AdditionTestData
    {
        public static IEnumerable<int[]> AdditionCases
        {
            get
            {
                yield return new[] { 2, 2, 4 };
                yield return new[] { 1, -1, 0 };
            }
        }

        public static IEnumerable<ITestCaseData> AdditionCasesEnumerable {
            get
            {
                yield return new TestCaseData(2, 2).Returns(4).SetName("2 plus 2 must equal 4");
                yield return new TestCaseData(1, -1).Returns(0).SetName("1 plus -1 must equal 0");
            }
        }
    }
}

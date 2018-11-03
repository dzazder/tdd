using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MixTests.Tests.Unit
{
    public class PersonTests
    {
        [Test]
        public void WhenThePersonHasTheAgeGreaterThanMaximumThenExceptionIsThrown()
        {
            try
            {
                new Person { Age = 123 };
            }
            catch (ArgumentOutOfRangeException)
            {
                Assert.Pass();
            }

            Assert.Fail("ArgumentOutOfRangeExceptiion should be thrown but it has not been");
        }

        [Test]
        public void WhenThePersonHasTheAgeGreaterThanMaximumThenExceptionIsThrownDelegate()
        {
            TestDelegate action = () => new Person { Age = 123 };
            Assert.Throws<ArgumentOutOfRangeException>(action);
        }

        [Test]
        public void WhenThePersonHasTheAgeGreaterThanMaximumThenExceptionIsThrownAnonymous()
        {
            Assert.Throws<ArgumentOutOfRangeException>(delegate { new Person { Age = 123 }; });
        }

        [Test]
        public void WhenThePersonHasTheAgeGreaterThanMaximumThenExceptionIsThrownLambda()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Person { Age = 123 });
        }

        [Test]
        public void WhenThePersonHasTheAgeGreaterThanMaximumThenExceptionIsThrownTypeAsParam()
        {
            Assert.Throws(typeof(ArgumentOutOfRangeException), () => new Person { Age = 123 });
        }

        [Test]
        public void WhenThePersonHasTheAgeGreaterThanMaximumThenExceptionIsThrownClaimModel()
        {
            Assert.That(() => new Person { Age = 123 }, Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void WhenThePersonHasCorrectAgeThenExceptionIsNotThrown()
        {
            Assert.DoesNotThrow(() => new Person { Age = 88 });
        }

        [Test]
        public void WhenThePersonHasTheAgeLessThanZeroThenExceptionIsThrown()
        {
            try
            {
                new Person { Age = -5 };
            }
            catch (ArgumentOutOfRangeException)
            {
                Assert.Pass();
            }

            Assert.Fail("ArgumentOutOfRangeException should be thrown but it has not been");
        }

        [Test]
        public void WhenTwoPersonsHaveTheSamePeselThenTheyAreTheEqual()
        {
            var comparer = new PersonByPeselEqualityComparer();

            Assert.That(Person.WithPesel("89042711635"),
                Is.EqualTo(Person.WithPesel("89042711635")).Using(comparer));
        }

        [TestCaseSource("EvenNumbers")]
        public void IsEven(int number)
        {
            Assert.That(number % 2, Is.Zero);
        }

        private static readonly int[] EvenNumbers = { 0, 2, 4, 6, 20, 40};

        [TestCaseSource(nameof(AdditionCases))]
        public void AdditionTest(int a, int b, int expectedResult)
        {
            Assert.That(a + b, Is.EqualTo(expectedResult));
        }

        private static IEnumerable<int[]> AdditionCases
        {
            get
            {
                yield return new[] { 2, 2, 4 };
                yield return new[] { 1, -1, 0 };
            }
        }
    }
}

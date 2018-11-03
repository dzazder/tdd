using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MixTests.Tests.Unit.TestsData
{
    public class AdditionTestDataEnumerable : IEnumerable<int[]>
    {
        public IEnumerator<int[]> GetEnumerator()
        {
            yield return new[] { 2, 2, 4 };
            yield return new[] { 1, -1, 0 };
        }
        
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

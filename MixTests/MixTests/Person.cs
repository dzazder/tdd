using System;
using System.Collections.Generic;
using System.Text;

namespace MixTests
{
    public class Person : IPerson
    {
        private int _age;
        private const int MaxAge = 122;

        public string Pesel { get; private set; }

        public static Person WithPesel(string pesel)
        {
            return new Person { Pesel = pesel };
        }

        public int Age
        {
            get
            {
                return _age;
            }
            set
            {
                if (value <= 0 || value > MaxAge)
                {
                    throw new ArgumentOutOfRangeException(
                        paramName: nameof(value),
                        message: $"Age must be less than {MaxAge} and greater than 0");
                }
                _age = value;
            }
        }
    }
}

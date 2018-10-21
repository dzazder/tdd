using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    public class Calculator
    {
        public double Divide(double x, double y)
        {
            if (y == 0)
            {
                throw new DivideByZeroException();
            }
            double result = x / y;
            OnCalculated(result);

            return result;
        }

        public event EventHandler<double> Calculated;

        protected virtual void OnCalculated(double result)
        {
            Calculated?.Invoke(this, result);
        }
    }
}

namespace Rcw.CalFramework
{
    using System;

    internal class OperNeg : OperBase
    {
        public OperNeg()
        {
            base.Name = "~";
            base.Priority = 2;
            base.Operand = 1;
        }

        public override double? Oper(double? d1, double? d2)
        {
            double? nullable = d1;
            if (!nullable.HasValue)
            {
                return null;
            }
            return new double?(0.0 - nullable.GetValueOrDefault());
        }
    }
}


namespace Rcw.CalFramework
{
    using System;

    internal class OperGt : OperBase
    {
        public OperGt()
        {
            base.Name = ">";
            base.Priority = 6;
            base.Operand = 2;
        }

        public override double? Oper(double? d1, double? d2)
        {
            if (!d1.HasValue || !d2.HasValue)
            {
                return 1.0;
            }
            double? nullable = d1;
            double? nullable2 = d2;
            if ((nullable.GetValueOrDefault() > nullable2.GetValueOrDefault()) && (nullable.HasValue & nullable2.HasValue))
            {
                return 1.0;
            }
            return 0.0;
        }
    }
}


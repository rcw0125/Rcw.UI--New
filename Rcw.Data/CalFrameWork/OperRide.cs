namespace Rcw.CalFramework
{
    using System;

    internal class OperRide : OperBase
    {
        public OperRide()
        {
            base.Name = "*";
            base.Priority = 3;
            base.Operand = 2;
        }

        public override double? Oper(double? d1, double? d2)
        {
            double? nullable = d1;
            double? nullable2 = d2;
            if (!(nullable.HasValue & nullable2.HasValue))
            {
                return null;
            }
            return new double?(nullable.GetValueOrDefault() * nullable2.GetValueOrDefault());
        }
    }
}


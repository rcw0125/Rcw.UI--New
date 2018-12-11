namespace Rcw.CalFramework
{
    using System;

    internal class OperAdd : OperBase
    {
        public OperAdd()
        {
            base.Name = "+";
            base.Priority = 4;
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
            return new double?(nullable.GetValueOrDefault() + nullable2.GetValueOrDefault());
        }
    }
}


namespace Rcw.CalFramework
{
    using System;

    internal class OperDiv : OperBase
    {
        public OperDiv()
        {
            base.Name = "/";
            base.Priority = 3;
            base.Operand = 2;
        }

        public override double? Oper(double? d1, double? d2)
        {
            if (d2 == 0.0)
            {
                return 0.0;
            }
            double? nullable2 = d1;
            double? nullable3 = d2;
            if (!(nullable2.HasValue & nullable3.HasValue))
            {
                return null;
            }
            return new double?(nullable2.GetValueOrDefault() / nullable3.GetValueOrDefault());
        }
    }
}


namespace Rcw.CalFramework
{
    using System;

    internal class OperOr : OperBase
    {
        public OperOr()
        {
            base.Name = "||";
            base.Priority = 12;
            base.Operand = 2;
        }

        public override double? Oper(double? d1, double? d2)
        {
            if ((d1.HasValue && d2.HasValue) && ((d1 <= 0.0) && (d2 <= 0.0)))
            {
                return 0.0;
            }
            return 1.0;
        }
    }
}


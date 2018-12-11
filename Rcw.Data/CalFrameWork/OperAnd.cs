namespace Rcw.CalFramework
{
    using System;

    internal class OperAnd : OperBase
    {
        public OperAnd()
        {
            base.Name = "&&";
            base.Priority = 11;
            base.Operand = 2;
        }

        public override double? Oper(double? d1, double? d2)
        {
            if (!d1.HasValue || !d2.HasValue)
            {
                return 1.0;
            }
            if ((d1 > 0.0) && (d2 > 0.0))
            {
                return 1.0;
            }
            return 0.0;
        }
    }
}


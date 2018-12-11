namespace Rcw.CalFramework
{
    using System;

    internal class OperNe : OperBase
    {
        public OperNe()
        {
            base.Name = "!=";
            base.Priority = 7;
            base.Operand = 2;
        }

        public override double? Oper(double? d1, double? d2)
        {
            if (!d1.HasValue || !d2.HasValue)
            {
                return 1.0;
            }
            if (d1 != d2)
            {
                return 1.0;
            }
            return 0.0;
        }
    }
}


namespace Rcw.CalFramework
{
    using System;

    internal class OperNot : OperBase
    {
        public OperNot()
        {
            base.Name = "!";
            base.Priority = 2;
            base.Operand = 1;
        }

        public override double? Oper(double? d1, double? d2)
        {
            if ((d1.HasValue && d2.HasValue) && (d1 > 0.0))
            {
                return 0.0;
            }
            return 1.0;
        }
    }
}


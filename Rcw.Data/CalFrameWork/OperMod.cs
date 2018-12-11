namespace Rcw.CalFramework
{
    using System;

    internal class OperMod : OperBase
    {
        public OperMod()
        {
            base.Name = "%";
            base.Priority = 3;
            base.Operand = 2;
        }

        public override double? Oper(double? d1, double? d2)
        {
            if (d2 == 0.0)
            {
                return 0.0;
            }
            return new double?((double) (Convert.ToInt32(d1) % Convert.ToInt32(d2)));
        }
    }
}


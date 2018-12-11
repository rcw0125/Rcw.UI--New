namespace Rcw.CalFramework
{
    using System;

    internal class OperRp : OperBase
    {
        public OperRp()
        {
            base.Name = "(";
            base.Priority = 1;
            base.Operand = 0;
        }

        public override double? Oper(double? d1, double? d2)
        {
            throw new Exception("右括号没有操作数");
        }
    }
}


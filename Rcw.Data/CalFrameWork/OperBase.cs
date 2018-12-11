namespace Rcw.CalFramework
{
    using System;
    using System.Runtime.CompilerServices;

    public abstract class OperBase
    {
        protected OperBase()
        {
        }

        public static OperBase Create(string opName)
        {
            switch (opName)
            {
                case "+":
                    return new OperAdd();

                case "-":
                    return new OperDec();

                case "*":
                    return new OperRide();

                case "/":
                    return new OperDiv();

                case "(":
                    return new OperRp();

                case ")":
                    return new OperLp();

                case "%":
                    return new OperMod();

                case "~":
                    return new OperNeg();

                case "==":
                    return new OperEq();

                case "!=":
                    return new OperNe();

                case ">":
                    return new OperGt();

                case "<":
                    return new OperLt();

                case ">=":
                    return new OperGe();

                case "<=":
                    return new OperLe();

                case "&&":
                    return new OperAnd();

                case "||":
                    return new OperOr();

                case "!":
                    return new OperNot();
            }
            throw new Exception("无法解析操作符:" + opName);
        }

        public static bool operator >(OperBase d1, OperBase d2)
        {
            return (d1.Priority < d2.Priority);
        }

        public static bool operator >=(OperBase d1, OperBase d2)
        {
            return (d1.Priority <= d2.Priority);
        }

        public static bool operator <(OperBase d1, OperBase d2)
        {
            return (d1.Priority > d2.Priority);
        }

        public static bool operator <=(OperBase d1, OperBase d2)
        {
            return (d1.Priority >= d2.Priority);
        }

        public abstract double? Oper(double? d1, double? d2);

        public string Name { get; protected set; }

        /// <summary>
        /// 操作等级
        /// </summary>
        public int Operand { get; protected set; }
        /// <summary>
        /// 优先级
        /// </summary>

        public int Priority { get; protected set; }
    }
}


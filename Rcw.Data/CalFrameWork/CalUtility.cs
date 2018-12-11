namespace Rcw.CalFramework
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class CalUtility
    {
        private string formula = "";
        /// <summary>
        /// 中间变量，记录公式单项
        /// </summary>
        private List<FormulaItem> nifixExpression = new List<FormulaItem>();
        /// <summary>
        /// 正式公式表达式列表
        /// </summary>
        private List<FormulaItem> postfixExpression = new List<FormulaItem>();
        /// <summary>
        /// 计算运算  1.格式化运算公式
        /// </summary>
        /// <param name="calStr">运算公式</param>
        public CalUtility(string calStr)
        {
            this.formula = calStr;
            this.ParseFormula(calStr);
        }
        /// <summary>
        /// 计算，如果是数字，则入栈，标签，计算其值，入栈，操作符则出栈两个数，计算结果，将结果入栈
        /// </summary>
        /// <param name="tm">标签类</param>
        /// <returns></returns>
        public double? DoCal(IGetTagValue tm=null)
        {
            Stack<double?> stack = new Stack<double?>();
            foreach (FormulaItem item in this.postfixExpression)
            {
                switch (item.OpTyp)
                {
                    case FormulaItemType.Operator:
                    {
                        if (item.Oper.Operand != 1)
                        {
                            break;
                        }
                        double? nullable = stack.Pop();
                        double? nullable6 = item.Oper.Oper(nullable, 0.0);
                        double? nullable2 = new double?(nullable6.HasValue ? nullable6.GetValueOrDefault() : 0.0);
                        stack.Push(nullable2);
                        continue;
                    }
                    case FormulaItemType.Number:
                    {
                        stack.Push(new double?(item.GetValue()));
                        continue;
                    }
                    case FormulaItemType.Tag:
                    {
                        stack.Push(item.GetValue(tm));
                        continue;
                    }
                    case FormulaItemType.Control:
                    {
                        continue;
                    }
                    default:
                    {
                        continue;
                    }
                }
                //操作符的操作等级
                if (item.Oper.Operand == 2)
                {
                    double? nullable3 = stack.Pop();
                    double? nullable4 = stack.Pop();
                    double? nullable5 = item.Oper.Oper(nullable4, nullable3);
                    stack.Push(nullable5);
                }
            }
            if (stack.Count != 1)
            {
                throw new Exception("计算错误,公式：" + this.formula);
            }
            return stack.Pop();
        }
        /// <summary>
        /// 是否是数字
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>

        public bool IsNum(char c)
        {
            if (!char.IsNumber(c) && (c != '.'))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 是否是操作符
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public bool IsOper(char c)
        {
            if (((((c != '+') && (c != '-')) && ((c != '*') && (c != '/'))) && (((c != '(') && (c != ')')) && ((c != '=') && (c != '<')))) && (((c != '>') && (c != '%')) && (((c != '&') && (c != '|')) && (c != '!'))))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 是否是空格
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public bool IsSplitSpace(char c)
        {
            if (!char.IsControl(c) && !char.IsWhiteSpace(c))
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// 是否是标签
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public bool IsTagChar(char c)
        {
            return (((!this.IsNum(c) && !this.IsOper(c)) && !this.IsSplitSpace(c)) || (c == '.'));
        }

        /// <summary>
        /// 格式化公式
        /// </summary>
        /// <param name="formula"></param>
        private void ParseFormula(string formula)
        {
            StringBuilder builder = new StringBuilder(formula.Trim());
            int length = builder.Length;
            StringBuilder builder2 = new StringBuilder();
            //公式 项目类型 ---控制
            FormulaItemType control = FormulaItemType.Control;
            for (int i = 0; i < length; i++)
            {
                char ch = builder[i];
                if (ch == '.')
                {
                    builder2.Append(ch);
                    continue;
                }
                if (this.IsSplitSpace(ch))
                {
                    if (control != FormulaItemType.Control)
                    {
                        FormulaItem item = new FormulaItem(builder2.ToString(), control);
                        builder2.Clear();
                        this.nifixExpression.Add(item);
                        control = FormulaItemType.Control;
                    }
                    continue;
                }
                if (this.IsNum(ch))
                {
                    switch (control)
                    {
                        case FormulaItemType.Number:
                        case FormulaItemType.Tag:
                            goto Label_024B;
                    }
                    if (control != FormulaItemType.Control)
                    {
                        FormulaItem item2 = new FormulaItem(builder2.ToString(), control);
                        builder2.Clear();
                        this.nifixExpression.Add(item2);
                    }
                    control = FormulaItemType.Number;
                }
                else if (this.IsOper(ch))
                {
                    if (control != FormulaItemType.Operator)
                    {
                        if (control != FormulaItemType.Control)
                        {
                            FormulaItem item3 = new FormulaItem(builder2.ToString(), control);
                            builder2.Clear();
                            this.nifixExpression.Add(item3);
                        }
                        else if ((ch == '-') && ((this.nifixExpression.Count == 0) || ((this.nifixExpression[this.nifixExpression.Count - 1].OpTyp == FormulaItemType.Operator) && (this.nifixExpression[this.nifixExpression.Count - 1].Oper.Name != ")"))))
                        {
                            ch = '~';
                        }
                        control = FormulaItemType.Operator;
                    }
                    else if (ch == '-')
                    {
                        if (builder2.ToString() != ")")
                        {
                            ch = '~';
                        }
                        FormulaItem item4 = new FormulaItem(builder2.ToString(), control);
                        builder2.Clear();
                        this.nifixExpression.Add(item4);
                    }
                    else if (((builder2.ToString() == "(") || (builder2.ToString() == ")")) || ((ch.ToString() == "(") || (ch.ToString() == ")")))
                    {
                        FormulaItem item5 = new FormulaItem(builder2.ToString(), control);
                        builder2.Clear();
                        this.nifixExpression.Add(item5);
                    }
                }
                else
                {
                    switch (control)
                    {
                        case FormulaItemType.Number:
                            control = FormulaItemType.Tag;
                            goto Label_024B;

                        case FormulaItemType.Tag:
                            goto Label_024B;
                    }
                    if (control != FormulaItemType.Control)
                    {
                        FormulaItem item6 = new FormulaItem(builder2.ToString(), control);
                        builder2.Clear();
                        this.nifixExpression.Add(item6);
                    }
                    control = FormulaItemType.Tag;
                }
            Label_024B:
                builder2.Append(ch);
            }
            if ((control != FormulaItemType.Control) && (builder2.Length > 0))
            {
                FormulaItem item7 = new FormulaItem(builder2.ToString(), control);
                builder2.Clear();
                this.nifixExpression.Add(item7);
            }
            Stack<FormulaItem> stack = new Stack<FormulaItem>();
            foreach (FormulaItem item8 in this.nifixExpression)
            {
                if (item8.OpTyp != FormulaItemType.Operator)
                {
                    goto Label_0374;
                }
                if (!(item8.Oper.Name == ")"))
                {
                    goto Label_0328;
                }
                while (stack.Count > 0)
                {
                    FormulaItem item9 = stack.Pop();
                    if (item9.Oper.Name == "(")
                    {
                        break;
                    }
                    this.postfixExpression.Add(item9);
                }
                continue;
            Label_0316:
                this.postfixExpression.Add(stack.Pop());

            Label_0328:
            //栈不为空且栈顶操作符不为左括号当前操作符小于栈顶的操作符
                if (((stack.Count > 0) && (stack.Peek().Oper.Name != "(")) && (item8.Oper <= stack.Peek().Oper))
                {
                    goto Label_0316;
                }
            //当前项入栈
                stack.Push(item8);
                continue;
            Label_0374:
                //非操作符记入正式公式表达式列表里
                this.postfixExpression.Add(item8);
            }
            while (stack.Count > 0)
            {
                this.postfixExpression.Add(stack.Pop());
            }
        }

        public List<FormulaItem> NifixExpression
        {
            get
            {
                return this.nifixExpression;
            }
        }

        public List<FormulaItem> PostfixExpression
        {
            get
            {
                return this.postfixExpression;
            }
        }
    }
}


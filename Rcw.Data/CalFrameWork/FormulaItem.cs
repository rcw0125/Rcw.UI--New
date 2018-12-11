namespace Rcw.CalFramework
{
    using System;

    public class FormulaItem
    {
        private OperBase _oper;
        private string _opName = "";
        private FormulaItemType _opType = FormulaItemType.Number;

        public FormulaItem(string opName, FormulaItemType opType)
        {
            this._opName = opName;
            this._opType = opType;
            if (opType == FormulaItemType.Operator)
            {
                this._oper = OperBase.Create(opName);
            }
        }

        public double GetValue()
        {
            return double.Parse(this.Name);
        }

        public double? GetValue(IGetTagValue tm)
        {
            return tm.GetTagValue(this.Name);
        }

        public string Name
        {
            get
            {
                return this._opName;
            }
        }

        public OperBase Oper
        {
            get
            {
                return this._oper;
            }
        }

        public FormulaItemType OpTyp
        {
            get
            {
                return this._opType;
            }
        }
    }
}


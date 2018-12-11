namespace Rcw.Data
{
    using System;

    internal class JoinTableInfo : IComparable<JoinTableInfo>
    {
        private string _JoinCondition = "";
        private string _JoinTableAlias = "";
        private string _JoinTableName = "";
        private string _JoinType = "INNER";
        private bool visited;

        public int CompareTo(JoinTableInfo other)
        {
            if (other.JoinCondition.Contains(this.JoinTableKey + "."))
            {
                return -1;
            }
            if (this.JoinCondition.Contains(other.JoinTableKey + "."))
            {
                return 1;
            }
            return 0;
        }

        public string JoinCondition
        {
            get
            {
                return this._JoinCondition;
            }
            set
            {
                this._JoinCondition = value;
            }
        }

        public string JoinTableAlias
        {
            get
            {
                return this._JoinTableAlias;
            }
            set
            {
                this._JoinTableAlias = value;
            }
        }

        public string JoinTableKey
        {
            get
            {
                if (!string.IsNullOrEmpty(this.JoinTableAlias))
                {
                    return this.JoinTableAlias;
                }
                return this.JoinTableName;
            }
        }

        public string JoinTableName
        {
            get
            {
                return this._JoinTableName;
            }
            set
            {
                this._JoinTableName = value;
            }
        }

        public string JoinType
        {
            get
            {
                return this._JoinType;
            }
            set
            {
                this._JoinType = value;
            }
        }

        public bool Visited
        {
            get
            {
                return this.visited;
            }
            set
            {
                this.visited = value;
            }
        }
    }
}


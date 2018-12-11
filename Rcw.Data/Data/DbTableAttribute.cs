using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace Rcw.Data
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple=true)]
    public class DbTableAttribute:Attribute
    {
        public override object TypeId
        {
            get
            {
                return new System.Data.Linq.Mapping.TableAttribute().TypeId;
            }
        }

        public string Name
        {
            get { return _TableName; }
            set { _TableName = value; }
        }


        private string _TableName = "";
        /// <summary>
        /// 表名
        /// </summary>
        public string TableName
        {
            get { return _TableName; }
            set { _TableName = value; }
        }

        private string _TableAlias = "";
        /// <summary>
        /// 别名
        /// </summary>
        public string TableAlias
        {
            get { return _TableAlias; }
            set { _TableAlias = value; }
        }

        private string _JoinCondition;
        /// <summary>
        /// 关联条件
        /// </summary>
        public string JoinCondition
        {
            get { return _JoinCondition; }
            set { _JoinCondition = value; }
        }

        private JoinType _JoinType=JoinType.Inner;
        /// <summary>
        /// 关联类型
        /// </summary>
        public JoinType JoinType
        {
            get { return _JoinType; }
            set { _JoinType = value; }
        }

        private bool _IsView=false;
        /// <summary>
        /// 是否查询
        /// </summary>
        public bool IsView
        {
            get { return _IsView; }
            set { _IsView = value; }
        }

        private bool _IsDistinct = false;
        /// <summary>
        /// 是否去除重复项
        /// </summary>
        public bool IsDistinct
        {
            get { return _IsDistinct; }
            set { _IsDistinct = value; }
        }


       

        public DbTableAttribute()
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableName">主表表名</param>
        public DbTableAttribute(string tableName)
        {
            this.TableName = tableName;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableName">主表表名</param>
        /// <param name="tableAlias">主表别名</param>
        public DbTableAttribute(string tableName,string tableAlias)
        {
            this.TableName = tableName;
            this.TableAlias = tableAlias;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableName">主表表名</param>
        /// <param name="tableAlias">主表别名</param>
        /// <param name="isView">是否查询</param>
        public DbTableAttribute(string tableName, string tableAlias,bool isView)
        {
            this.TableName = tableName;
            this.TableAlias = tableAlias;
            this.IsView = isView;
        }
        public DbTableAttribute(string tableName,string tableAlias,string joinCondition)
        {
            this.TableName = tableName;
            this.TableAlias = tableAlias;
            this.JoinCondition = joinCondition;
        }
        public DbTableAttribute(string tableName, string tableAlias, string joinCondition,JoinType joinType)
        {
            this.TableName = tableName;
            this.TableAlias = tableAlias;
            this.JoinCondition = joinCondition;
            this.JoinType = joinType;
        }

    }

    public enum JoinType { Inner, Left, Right }
}

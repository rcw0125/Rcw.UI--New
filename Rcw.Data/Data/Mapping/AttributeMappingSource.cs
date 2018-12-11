using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
namespace Rcw.Data.Mapping
{
    public class RcwAttributeMappingSource : MappingSource
    {
        protected override MetaModel CreateModel(Type dataContextType)
        {
            
            return new RcwMetaModel();
        }
    }

    public class RcwMetaModel : MetaModel
    {

        public override Type ContextType
        {
            get { throw new NotImplementedException(); }
        }

        public override string DatabaseName
        {
            get { throw new NotImplementedException(); }
        }

        public override MetaFunction GetFunction(System.Reflection.MethodInfo method)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<MetaFunction> GetFunctions()
        {
            throw new NotImplementedException();
        }

        public override MetaType GetMetaType(Type type)
        {
            throw new NotImplementedException();
        }

        public override MetaTable GetTable(Type rowType)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<MetaTable> GetTables()
        {
            throw new NotImplementedException();
        }

        public override MappingSource MappingSource
        {
            get { throw new NotImplementedException(); }
        }

        public override Type ProviderType
        {
            get { throw new NotImplementedException(); }
        }
   
    }

    public class RcwMetaTable : MetaTable
    {

        public override System.Reflection.MethodInfo DeleteMethod
        {
            get { throw new NotImplementedException(); }
        }

        public override System.Reflection.MethodInfo InsertMethod
        {
            get { throw new NotImplementedException(); }
        }

        public override MetaModel Model
        {
            get { throw new NotImplementedException(); }
        }

        public override MetaType RowType
        {
            get { throw new NotImplementedException(); }
        }

        public override string TableName
        {
            get { throw new NotImplementedException(); }
        }

        public override System.Reflection.MethodInfo UpdateMethod
        {
            get { throw new NotImplementedException(); }
        }
    }
}

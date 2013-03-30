using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace DBSchemaInfo.Base
{
    public abstract class InformationSchemaObjectBase : DBSchemaInfo.Base.IDataBaseObject
    {
        public InformationSchemaObjectBase(DataRow dr, ICatalog cat)
        {
            _Catalog = cat;
            _ObjectName = dr[ISObjectName].ToString();
            _ObjectSchema = dr[ISObjectSchema].ToString();
            _ObjectCatalog = dr.IsNull(ISObjectCatalog) ? string.Empty : dr[ISObjectCatalog].ToString();
        }

        protected virtual string ISObjectName
        {
            get { return "TABLE_NAME"; }
        }
        protected virtual string ISObjectSchema
        {
            get { return "TABLE_SCHEMA"; }
        }
        protected virtual string ISObjectCatalog
        {
            get { return "TABLE_CATALOG"; }
        }

        private string _ObjectName;
        public string ObjectName
        {
            get
            {
                return _ObjectName;
            }
            protected internal set
            {
                _ObjectName = value;
            }
        }

        private string _ObjectSchema;
        public string ObjectSchema
        {
            get
            {
                return _ObjectSchema;
            }
            protected internal set
            {
                _ObjectSchema = value;
            }
        }

        private string _ObjectCatalog;
        public string ObjectCatalog
        {
            get
            {
                return _ObjectCatalog;
            }
            protected internal set
            {
                _ObjectCatalog = value;
            }
        }

        ICatalog _Catalog;
        public ICatalog Catalog
        {
            get
            {
                return _Catalog;
            }
        }

        public abstract void Reload(bool throwOnError);

      
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Drawing.Design;
using CslaGenerator.Design;

namespace CslaGenerator.Metadata
{
    public class CriteriaProperty : Property, IBoundProperty 
    {
        public CriteriaProperty(Property p) : base(p)
        {
        }

        public CriteriaProperty() : base()
        {
        }

        public CriteriaProperty(string name, TypeCodeEx type, string parameterName)
            : base(name, type, parameterName)
        {
        }

        public CriteriaProperty(string name, TypeCodeEx type)
            : base(name, type)
        {
        }

        private DbBindColumn _dbBindColumn=new DbBindColumn();
        [Category("Database Related")]
        [Editor(typeof(Design.DbBindColumnEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(DbBindColumnConverter))]
        [Description("The database column this property is bound to.")]
        public DbBindColumn DbBindColumn
        {
            get { return _dbBindColumn; }
            set
            {
                _dbBindColumn = value;
                base.ResetProperties(value);
            }
        }

        public override string Name
        {
            get { return base.Name; }
            set { base.Name = value; }
        }

        public override TypeCodeEx PropertyType
        {
            get { return base.PropertyType; }
            set { base.PropertyType = value; }
        }

        public override bool ReadOnly
        {
            get { return base.ReadOnly; }
            set { base.ReadOnly = value; }
        }

        public override bool Nullable
        {
            get { return base.Nullable; }
            set { base.Nullable = value; }
        }

        [Category("Definition")]
        [Description("The fixed parameter value is used as filter criteria.")]
        public string ParameterValue { get; set; }
    }
}

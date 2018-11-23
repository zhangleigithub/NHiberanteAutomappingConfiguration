using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;
using FluentNHibernate.Mapping;
using Summer.AutomappingConfiguration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Summer.AutomappingConfiguration.Conventions
{
    /// <summary>
    /// ReferenceConvention
    /// </summary>
    internal class ReferenceConvention : IReferenceConvention
    {
        #region 方法

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance"></param>
        public void Apply(IManyToOneInstance instance)
        {
            object[] attrs = instance.EntityType.GetProperty(instance.Property.Name).GetCustomAttributes(true);
            ColumnAttribute column = attrs.FirstOrDefault(x => typeof(ColumnAttribute).IsInstanceOfType(x)) as ColumnAttribute;
            LazyAttribute lazy = attrs.FirstOrDefault(x => typeof(LazyAttribute).IsInstanceOfType(x)) as LazyAttribute;
            NullableAttribute nullable = attrs.FirstOrDefault(x => typeof(NullableAttribute).IsInstanceOfType(x)) as NullableAttribute;
            InsertAttribute insert = attrs.FirstOrDefault(x => typeof(InsertAttribute).IsInstanceOfType(x)) as InsertAttribute;
            UpdateAttribute update = attrs.FirstOrDefault(x => typeof(UpdateAttribute).IsInstanceOfType(x)) as UpdateAttribute;
            FormulaAttribute formula = attrs.FirstOrDefault(x => typeof(FormulaAttribute).IsInstanceOfType(x)) as FormulaAttribute;
            IndexAttribute index = attrs.FirstOrDefault(x => typeof(IndexAttribute).IsInstanceOfType(x)) as IndexAttribute;
            UniqueAttribute unique = attrs.FirstOrDefault(x => typeof(UniqueAttribute).IsInstanceOfType(x)) as UniqueAttribute;

            if (column != null)
            {
                instance.Column(column.Name);
            }

            //Cascade
            SetProperty.ICascadeInstance(instance.Cascade, attrs);

            if (lazy != null)
            {
                instance.LazyLoad();
            }

            if (nullable != null)
            {
                instance.Nullable();
            }

            if (insert != null)
            {
                instance.Insert();
            }

            if (update != null)
            {
                instance.Update();
            }

            if (formula != null)
            {
                instance.Formula(formula.Value);
            }

            if (index != null)
            {
                instance.Index(index.Value);
            }

            if (unique != null)
            {
                instance.Unique();
            }
        }

        #endregion
    }
}

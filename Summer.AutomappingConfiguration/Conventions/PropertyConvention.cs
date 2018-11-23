using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;
using Summer.AutomappingConfiguration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Summer.AutomappingConfiguration.Conventions
{
    /// <summary>
    /// PropertyConvention
    /// </summary>
    internal class PropertyConvention : IPropertyConvention
    {
        #region 方法

        /// <summary>
        /// 属性规则
        /// </summary>
        /// <param name="instance">实例</param>
        public void Apply(IPropertyInstance instance)
        {
            object[] attrs = instance.EntityType.GetProperty(instance.Name).GetCustomAttributes(true);
            ColumnAttribute column = attrs.FirstOrDefault(x => typeof(ColumnAttribute).IsInstanceOfType(x)) as ColumnAttribute;
            LengthAttribute length = attrs.FirstOrDefault(x => typeof(LengthAttribute).IsInstanceOfType(x)) as LengthAttribute;
            DefaultValueAttribute defaultValue = attrs.FirstOrDefault(x => typeof(DefaultValueAttribute).IsInstanceOfType(x)) as DefaultValueAttribute;
            SqlTypeAttribute sqlType = attrs.FirstOrDefault(x => typeof(SqlTypeAttribute).IsInstanceOfType(x)) as SqlTypeAttribute;
            LazyAttribute lazy = attrs.FirstOrDefault(x => typeof(LazyAttribute).IsInstanceOfType(x)) as LazyAttribute;
            CheckAttribute check = attrs.FirstOrDefault(x => typeof(CheckAttribute).IsInstanceOfType(x)) as CheckAttribute;
            FormulaAttribute formula = attrs.FirstOrDefault(x => typeof(FormulaAttribute).IsInstanceOfType(x)) as FormulaAttribute;
            IndexAttribute index = attrs.FirstOrDefault(x => typeof(IndexAttribute).IsInstanceOfType(x)) as IndexAttribute;
            PrecisionAttribute percision = attrs.FirstOrDefault(x => typeof(PrecisionAttribute).IsInstanceOfType(x)) as PrecisionAttribute;
            ScaleAttribute scale = attrs.FirstOrDefault(x => typeof(ScaleAttribute).IsInstanceOfType(x)) as ScaleAttribute;
            UniqueAttribute unique = attrs.FirstOrDefault(x => typeof(UniqueAttribute).IsInstanceOfType(x)) as UniqueAttribute;

            if (column != null)
            {
                instance.Column(column.Name);
            }

            if (length != null)
            {
                instance.Length(length.Value);
            }

            if (defaultValue != null)
            {
                instance.Default(defaultValue.Value);
            }

            if (sqlType != null)
            {
                instance.CustomSqlType(sqlType.Value);
            }

            if (lazy != null)
            {
                instance.LazyLoad();
            }

            if (check != null)
            {
                instance.Check(check.Value);
            }

            if (formula != null)
            {
                instance.Formula(formula.Value);
            }

            if (index != null)
            {
                instance.Index(index.Value);
            }

            if (percision != null)
            {
                instance.Precision(percision.Value);
            }

            if (scale != null)
            {
                instance.Scale(scale.Value);
            }
            
            if (unique != null)
            {
                instance.Unique();
            }
        }

        #endregion
    }
}

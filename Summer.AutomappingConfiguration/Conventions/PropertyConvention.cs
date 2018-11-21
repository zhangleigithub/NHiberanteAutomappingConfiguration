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
        }

        #endregion
    }
}

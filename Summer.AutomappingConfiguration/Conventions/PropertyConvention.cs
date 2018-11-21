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
        /// 
        /// </summary>
        /// <param name="instance"></param>
        public void Apply(IPropertyInstance instance)
        {
            object[] attrs = instance.EntityType.GetProperty(instance.Name).GetCustomAttributes(true);
            ColumnAttribute column = attrs.FirstOrDefault(x => typeof(ColumnAttribute).IsInstanceOfType(x)) as ColumnAttribute;
            instance.Column(column.Name);
        }

        #endregion
    }
}

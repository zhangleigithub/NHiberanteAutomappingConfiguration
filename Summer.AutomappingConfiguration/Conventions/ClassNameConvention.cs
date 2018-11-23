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
    /// ClassNameConvention
    /// </summary>
    internal class ClassNameConvention : IClassConvention
    {
        #region 方法

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance"></param>
        public virtual void Apply(IClassInstance instance)
        {
            object[] attrs = instance.EntityType.GetCustomAttributes(true);
            TableAttribute table = attrs.FirstOrDefault(x => typeof(TableAttribute).IsInstanceOfType(x)) as TableAttribute;

            if (table != null)
            {
                instance.Table(table.Name);
            }
        }

        #endregion
    }
}

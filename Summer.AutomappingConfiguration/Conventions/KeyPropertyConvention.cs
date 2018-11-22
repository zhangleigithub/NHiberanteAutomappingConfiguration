using FluentNHibernate.Conventions;
using Summer.AutomappingConfiguration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Summer.AutomappingConfiguration.Conventions
{
    /// <summary>
    /// KeyPropertyConvention
    /// </summary>
    internal class KeyPropertyConvention : IKeyPropertyConvention
    {
        #region 方法

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance"></param>
        public void Apply(FluentNHibernate.Conventions.Instances.IKeyPropertyInstance instance)
        {
            object[] attrs = instance.EntityType.GetProperty(instance.Name).GetCustomAttributes(true);
            LengthAttribute length = attrs.FirstOrDefault(x => typeof(LengthAttribute).IsInstanceOfType(x)) as LengthAttribute;

            if (length != null)
            {
                instance.Length(length.Value);
            }
        }

        #endregion
    }
}

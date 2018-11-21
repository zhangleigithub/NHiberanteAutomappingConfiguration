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
    /// SubclassConvention
    /// </summary>
    internal class SubclassConvention : ISubclassConvention
    {
        #region 方法
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance"></param>
        public void Apply(ISubclassInstance instance)
        {
            instance.DiscriminatorValue(((DiscriminatedAttribute)instance.EntityType.GetCustomAttributes(typeof(DiscriminatedAttribute), true).First()).Value);
        }

        #endregion
    }
}

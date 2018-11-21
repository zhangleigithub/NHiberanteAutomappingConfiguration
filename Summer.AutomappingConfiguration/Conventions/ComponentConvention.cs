using FluentNHibernate.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Summer.AutomappingConfiguration.Conventions
{
    /// <summary>
    /// ComponentConvention
    /// </summary>
    internal class ComponentConvention : IComponentConvention
    {
        #region 方法

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance"></param>
        public void Apply(FluentNHibernate.Conventions.Instances.IComponentInstance instance)
        {
        }

        #endregion
       
    }
}

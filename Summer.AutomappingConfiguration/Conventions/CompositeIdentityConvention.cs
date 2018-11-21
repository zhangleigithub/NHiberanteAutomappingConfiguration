using FluentNHibernate.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Summer.AutomappingConfiguration.Conventions
{
    /// <summary>
    /// CompositeIdentityConvention
    /// </summary>
    internal class CompositeIdentityConvention : ICompositeIdentityConvention
    {
        #region 方法

        /// <summary>
        /// 联合主键匹配规则
        /// </summary>
        /// <param name="instance"></param>
        public void Apply(FluentNHibernate.Conventions.Instances.ICompositeIdentityInstance instance)
        {
            //instance.
        }

        #endregion
    }
}

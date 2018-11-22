using FluentNHibernate.Conventions;
using Summer.AutomappingConfiguration.Attributes;
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
            foreach (var item in instance.KeyProperties)
            {
                object[] attrs = item.EntityType.GetProperty(item.Name).GetCustomAttributes(true);
                LengthAttribute length = attrs.FirstOrDefault(x => typeof(LengthAttribute).IsInstanceOfType(x)) as LengthAttribute;

                if (length != null)
                {
                    item.Length(length.Value);
                }
            }
        }

        #endregion
    }
}

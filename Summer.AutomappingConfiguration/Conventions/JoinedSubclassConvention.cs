using FluentNHibernate.Conventions;
using Summer.AutomappingConfiguration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Summer.AutomappingConfiguration.Conventions
{
    internal class JoinedSubclassConvention : IJoinedSubclassConvention
    {
        #region 方法

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance"></param>
        public void Apply(FluentNHibernate.Conventions.Instances.IJoinedSubclassInstance instance)
        {
            instance.Key.Column(((ExtendsAttribute)instance.Type.GetCustomAttributes(typeof(ExtendsAttribute), true).First()).Key);
            instance.Key.ForeignKey(string.Format("FK_{0}_{1}", instance.Type.BaseType.Name, instance.Type.Name));
        }

        #endregion
    }
}

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
    /// HasOneConvention
    /// </summary>
    internal class HasOneConvention : IHasOneConvention
    {
        #region 属性

        /// <summary>
        /// 一对一对象的生成规则
        /// </summary>
        /// <param name="instance"></param>
        public void Apply(IOneToOneInstance instance)
        {
            object[] attrs = instance.EntityType.GetProperty(instance.Name).GetCustomAttributes(true);
            ColumnAttribute column = attrs.FirstOrDefault(x => typeof(ColumnAttribute).IsInstanceOfType(x)) as ColumnAttribute;
            LazyAttribute lazy = attrs.FirstOrDefault(x => typeof(LazyAttribute).IsInstanceOfType(x)) as LazyAttribute;

            if (column != null)
            {
                instance.ForeignKey(column.Name);
            }
            
            //Cascade
            SetProperty.ICascadeInstance(instance.Cascade, attrs);

            if (lazy != null)
            {
                instance.LazyLoad();
            }
        }

        #endregion
    }
}

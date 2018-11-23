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
    /// HasManyConvention
    /// </summary>
    internal class HasManyConvention : IHasManyConvention
    {
        #region 属性

        /// <summary>
        /// 一对多对象的生成规则
        /// </summary>
        /// <param name="instance"></param>
        public void Apply(IOneToManyCollectionInstance instance)
        {
            object[] attrs = instance.EntityType.GetProperty(instance.Member.Name).GetCustomAttributes(true);
            ColumnAttribute column = attrs.FirstOrDefault(x => typeof(ColumnAttribute).IsInstanceOfType(x)) as ColumnAttribute;
            LazyAttribute lazy = attrs.FirstOrDefault(x => typeof(LazyAttribute).IsInstanceOfType(x)) as LazyAttribute;
            InverseAttribute inverse = attrs.FirstOrDefault(x => typeof(InverseAttribute).IsInstanceOfType(x)) as InverseAttribute;

            if (column != null)
            {
                instance.Key.Column(column.Name);
            }

            //Cascade
            SetProperty.ICollectionCascadeInstance(instance.Cascade,attrs);

            if (lazy != null)
            {
                instance.LazyLoad();
            }

            if (inverse != null)
            {
                instance.Inverse();
            }
        }

        #endregion
    }
}

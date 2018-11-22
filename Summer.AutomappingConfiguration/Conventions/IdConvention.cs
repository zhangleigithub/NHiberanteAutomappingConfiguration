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
    /// IdConvention
    /// </summary>
    internal class IdConvention : IIdConvention
    {
        #region 方法

        /// <summary>
        /// Id规则
        /// </summary>
        /// <param name="instance"></param>
        public virtual void Apply(IIdentityInstance instance)
        {
            object[] attrs = instance.EntityType.GetProperty(instance.Name).GetCustomAttributes(true);

            IdAttribute pk = attrs.FirstOrDefault(x => typeof(IdAttribute).IsInstanceOfType(x)) as IdAttribute;

            ColumnAttribute column = attrs.FirstOrDefault(x => typeof(ColumnAttribute).IsInstanceOfType(x)) as ColumnAttribute;

            if (pk.Value == Enums.PrimaryKeys.Guid)
            {
                instance.GeneratedBy.Guid();
            }
            else if (pk.Value == Enums.PrimaryKeys.Identity)
            {
                instance.GeneratedBy.Identity();
            }
            else if (pk.Value == Enums.PrimaryKeys.Increment)
            {
                instance.GeneratedBy.Increment();
            }

            instance.Column(column.Name);
        }

        #endregion
    }
}

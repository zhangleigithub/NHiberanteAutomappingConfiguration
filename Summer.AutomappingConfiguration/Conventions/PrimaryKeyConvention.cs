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
    /// PrimaryKeyConvention
    /// </summary>
    internal class PrimaryKeyConvention : IIdConvention
    {
        #region 方法

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance"></param>
        public virtual void Apply(IIdentityInstance instance)
        {
            object[] attrs = instance.EntityType.GetProperty("Id").GetCustomAttributes(true);

            PrimaryKeyAttribute pk = attrs.FirstOrDefault(x => typeof(PrimaryKeyAttribute).IsInstanceOfType(x)) as PrimaryKeyAttribute;

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

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
    /// HasManyToManyConvention
    /// </summary>
    internal class HasManyToManyConvention : IHasManyToManyConvention
    {
        #region 方法

        /// <summary>
        /// 多对多关系
        /// </summary>
        /// <param name="instance"></param>
        public void Apply(IManyToManyCollectionInstance instance)
        {
            object[] attrsTableA = instance.EntityType.GetCustomAttributes(true);
            object[] attrsTableB = instance.ChildType.GetCustomAttributes(true);
            object[] attrsColumnA = instance.EntityType.GetProperty("Id").GetCustomAttributes(true);
            object[] attrsColumnB = instance.ChildType.GetProperty("Id").GetCustomAttributes(true);

            TableAttribute tableA = attrsTableA.FirstOrDefault(x => typeof(TableAttribute).IsInstanceOfType(x)) as TableAttribute;
            TableAttribute tableB = attrsTableB.FirstOrDefault(x => typeof(TableAttribute).IsInstanceOfType(x)) as TableAttribute;
            ColumnAttribute columnA = attrsColumnA.FirstOrDefault(x => typeof(ColumnAttribute).IsInstanceOfType(x)) as ColumnAttribute;
            ColumnAttribute columnB = attrsColumnB.FirstOrDefault(x => typeof(ColumnAttribute).IsInstanceOfType(x)) as ColumnAttribute;

            object[] tableNames = new object[2];

            if (string.CompareOrdinal(tableA.Name, tableB.Name) > 0)
            {
                tableNames[0] = tableA.Name;
                tableNames[1] = tableB.Name;
            }
            else
            {
                tableNames[0] = tableB.Name;
                tableNames[1] = tableA.Name;
            }

            instance.Table(string.Format("{0}_{1}", tableNames));
            instance.Key.Column(tableA.Name + columnA.Name);
            instance.Relationship.Column(tableB.Name + columnB.Name);
        }

        #endregion
    }
}

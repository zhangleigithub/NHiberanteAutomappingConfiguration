using FluentNHibernate.Conventions;
using Summer.AutomappingConfiguration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Summer.AutomappingConfiguration.Conventions
{
    /// <summary>
    /// VersionConvention
    /// </summary>
    internal class VersionConvention : IVersionConvention
    {
        #region 方法

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance"></param>
        public void Apply(FluentNHibernate.Conventions.Instances.IVersionInstance instance)
        {
            object[] attrs = instance.EntityType.GetProperty(instance.Name).GetCustomAttributes(true);

            IdAttribute id = attrs.FirstOrDefault(x => typeof(IdAttribute).IsInstanceOfType(x)) as IdAttribute;
            ColumnAttribute column = attrs.FirstOrDefault(x => typeof(ColumnAttribute).IsInstanceOfType(x)) as ColumnAttribute;
            LengthAttribute length = attrs.FirstOrDefault(x => typeof(LengthAttribute).IsInstanceOfType(x)) as LengthAttribute;
            DefaultValueAttribute defaultValue = attrs.FirstOrDefault(x => typeof(DefaultValueAttribute).IsInstanceOfType(x)) as DefaultValueAttribute;
            SqlTypeAttribute sqlType = attrs.FirstOrDefault(x => typeof(SqlTypeAttribute).IsInstanceOfType(x)) as SqlTypeAttribute;
            CheckAttribute check = attrs.FirstOrDefault(x => typeof(CheckAttribute).IsInstanceOfType(x)) as CheckAttribute;
            IndexAttribute index = attrs.FirstOrDefault(x => typeof(IndexAttribute).IsInstanceOfType(x)) as IndexAttribute;
            PrecisionAttribute percision = attrs.FirstOrDefault(x => typeof(PrecisionAttribute).IsInstanceOfType(x)) as PrecisionAttribute;
            ScaleAttribute scale = attrs.FirstOrDefault(x => typeof(ScaleAttribute).IsInstanceOfType(x)) as ScaleAttribute;
            UniqueAttribute unique = attrs.FirstOrDefault(x => typeof(UniqueAttribute).IsInstanceOfType(x)) as UniqueAttribute;
            UnsavedValueAttribute unsavedValue = attrs.FirstOrDefault(x => typeof(UnsavedValueAttribute).IsInstanceOfType(x)) as UnsavedValueAttribute;

            if (column != null)
            {
                instance.Column(column.Name);
            }

            if (length != null)
            {
                instance.Length(length.Value);
            }

            if (defaultValue != null)
            {
                instance.Default(defaultValue.Value);
            }

            if (sqlType != null)
            {
                instance.CustomSqlType(sqlType.Value);
            }

            if (check != null)
            {
                instance.Check(check.Value);
            }

            if (index != null)
            {
                instance.Index(index.Value);
            }

            if (percision != null)
            {
                instance.Precision(percision.Value);
            }

            if (scale != null)
            {
                instance.Scale(scale.Value);
            }

            if (unique != null)
            {
                instance.Unique();
            }

            if (unsavedValue != null)
            {
                instance.UnsavedValue(unsavedValue.Value);
            }
        }

        #endregion
    }
}

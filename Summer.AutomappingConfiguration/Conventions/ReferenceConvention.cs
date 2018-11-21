﻿using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;
using FluentNHibernate.Mapping;
using Summer.AutomappingConfiguration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Summer.AutomappingConfiguration.Conventions
{
    /// <summary>
    /// ReferenceConvention
    /// </summary>
    internal class ReferenceConvention : IReferenceConvention
    {
        #region 方法
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance"></param>
        public void Apply(IManyToOneInstance instance)
        {
            object[] attrs = instance.EntityType.GetProperty(instance.Property.Name).GetCustomAttributes(true);
            ColumnAttribute column = attrs.FirstOrDefault(x => typeof(ColumnAttribute).IsInstanceOfType(x)) as ColumnAttribute;
            instance.Column(column.Name);
            instance.LazyLoad();
        }

        #endregion
    }
}
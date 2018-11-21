using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.AcceptanceCriteria;
using FluentNHibernate.Conventions.Inspections;
using FluentNHibernate.Conventions.Instances;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Summer.AutomappingConfiguration.Conventions
{
    /// <summary>
    /// EnumConvention
    /// </summary>
    internal class EnumConvention : IUserTypeConvention
    {
        #region 方法
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="criteria"></param>
        public void Accept(IAcceptanceCriteria<IPropertyInspector> criteria)
        {
            criteria.Expect(x => x.Property.PropertyType.IsEnum);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance"></param>
        public void Apply(IPropertyInstance instance)
        {
            instance.CustomType(instance.Property.PropertyType);
        }

        #endregion
    }
}

using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using NHibernate.Criterion;
using Summer.AutomappingConfiguration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Summer.AutomappingConfiguration.MappingOverride
{
    /// <summary>
    /// CompositeIdMappingOverride
    /// </summary>
    /// <typeparam name="T">T</typeparam>
    public class CompositeIdMappingOverride<T> : IAutoMappingOverride<T>
    {
        /// <summary>
        /// Override
        /// </summary>
        /// <param name="mapping">mapping</param>
        public virtual void Override(AutoMapping<T> mapping)
        {
            var compositeId = mapping.CompositeId();

            foreach (var item in typeof(T).GetProperties())
            {
                if (item.GetCustomAttributes(typeof(CompositeIdAttribute), true).Length > 0)
                {
                    ParameterExpression parameter = System.Linq.Expressions.Expression.Parameter(typeof(T), "x");
                    System.Linq.Expressions.Expression member = System.Linq.Expressions.Expression.PropertyOrField(parameter, item.Name);
                    Expression<Func<T, object>> lamada = System.Linq.Expressions.Expression.Lambda<Func<T, object>>(member, parameter);
                    ColumnAttribute column = item.GetCustomAttributes(typeof(ColumnAttribute), true).FirstOrDefault() as ColumnAttribute;

                    compositeId.KeyProperty(lamada, column.Name);
                }
            }
        }
    }
}

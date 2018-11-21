using FluentNHibernate;
using FluentNHibernate.Automapping;
using Summer.AutomappingConfiguration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Summer.AutomappingConfiguration
{
    /// <summary>
    /// AutoMapConfiguration
    /// </summary>
    internal class AutoMapConfiguration : DefaultAutomappingConfiguration
    {
        #region 方法

        public AutoMapConfiguration()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public override bool ShouldMap(Type type)
        {
            return (type.IsClass);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        public override bool IsId(Member member)
        {
            return member.DeclaringType.GetProperty(member.Name).GetCustomAttributes(typeof(PrimaryKeyAttribute), true).Count() > 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public override bool IsDiscriminated(Type type)
        {
            return type.GetCustomAttributes(typeof(DiscriminatedAttribute), true).Count() > 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public override string GetDiscriminatorColumn(Type type)
        {
            return ((DiscriminatedAttribute)type.GetCustomAttributes(typeof(DiscriminatedAttribute), true).First()).ColumName;
        }

        #endregion
    }
}

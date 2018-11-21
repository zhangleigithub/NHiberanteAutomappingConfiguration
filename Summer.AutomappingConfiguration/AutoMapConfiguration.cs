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

        /// <summary>
        /// 构造函数
        /// </summary>
        public AutoMapConfiguration()
        {
        }

        /// <summary>
        /// 是否映射
        /// </summary>
        /// <param name="type">类型</param>
        /// <returns>bool</returns>
        public override bool ShouldMap(Type type)
        {
            return (type.IsClass);
        }

        /// <summary>
        /// Id
        /// </summary>
        /// <param name="member">成员</param>
        /// <returns>bool</returns>
        public override bool IsId(Member member)
        {
            return member.DeclaringType.GetProperty(member.Name).GetCustomAttributes(typeof(PrimaryKeyAttribute), true).Count() > 0;
        }

        /// <summary>
        /// 组件
        /// </summary>
        /// <param name="type">类型</param>
        /// <returns>bool</returns>
        public override bool IsComponent(Type type)
        {
            return type.GetCustomAttributes(typeof(ComponentAttribute), true).Count() > 0;
        }

        /// <summary>
        /// 组件前缀
        /// </summary>
        /// <param name="member">成员</param>
        /// <returns>组件前缀</returns>
        public override string GetComponentColumnPrefix(Member member)
        {
            return ((ComponentPrefixAttribute)member.DeclaringType.GetProperty(member.Name).GetCustomAttributes(typeof(ComponentPrefixAttribute), true).First()).Value;
        }

        /// <summary>
        /// 鉴别器
        /// </summary>
        /// <param name="type">类型</param>
        /// <returns>鉴别器</returns>
        public override bool IsDiscriminated(Type type)
        {
            return type.GetCustomAttributes(typeof(DiscriminatedAttribute), true).Count() > 0;
        }

        /// <summary>
        /// 鉴别器列名
        /// </summary>
        /// <param name="type">类型</param>
        /// <returns>鉴别器列名</returns>
        public override string GetDiscriminatorColumn(Type type)
        {
            return ((DiscriminatedAttribute)type.GetCustomAttributes(typeof(DiscriminatedAttribute), true).First()).ColumName;
        }

        #endregion
    }
}

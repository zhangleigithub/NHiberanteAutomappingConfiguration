using FluentNHibernate.Automapping;
using FluentNHibernate.Conventions;
using Summer.AutomappingConfiguration.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Summer.AutomappingConfiguration
{
    /// <summary>
    /// 可持续模型生成
    /// </summary>
    internal class PersistenceModelGenerator
    {
        #region 属性

        /// <summary>
        /// 忽略基类
        /// </summary>
        public IList<Type> IgnoredBaseTypes { get; set; }

        /// <summary>
        /// 包含基类
        /// </summary>
        public IList<Type> IncludeBaseTypes { get; set; }

        #endregion

        #region 方法

        /// <summary>
        /// 构造函数
        /// </summary>
        public PersistenceModelGenerator()
        {
            this.IgnoredBaseTypes = new List<Type>();
            this.IncludeBaseTypes = new List<Type>();
        }

        /// <summary>
        /// 生成
        /// </summary>
        /// <param name="assemblies">程序集</param>
        /// <returns>自动可持续模型</returns>
        public AutoPersistenceModel Generate(Assembly[] assemblies)
        {
            var mappings = AutoMap.Assemblies(new AutoMapConfiguration(), assemblies);

            foreach (var item in this.IgnoredBaseTypes)
            {
                mappings.IgnoreBase(item);
            }

            foreach (var item in this.IncludeBaseTypes)
            {
                mappings.IncludeBase(item);
            }

            mappings.Conventions.Setup(this.GetConventions());

            return mappings;
        }

        /// <summary>
        /// 协议
        /// </summary>
        /// <returns>协议</returns>
        protected Action<IConventionFinder> GetConventions()
        {
            return finder =>
            {
                finder.Add<ClassNameConvention>();
                finder.Add<PrimaryKeyConvention>();
                finder.Add<PropertyConvention>();
                finder.Add<ReferenceConvention>();
                finder.Add<HasOneConvention>();
                finder.Add<HasManyConvention>();
                finder.Add<HasManyToManyConvention>();
                finder.Add<SubclassConvention>();
                finder.Add<JoinedSubclassConvention>();
                finder.Add<EnumConvention>();
            };
        }

        #endregion
    }
}

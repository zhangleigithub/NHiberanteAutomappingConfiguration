using FluentNHibernate.Automapping;
using FluentNHibernate.Conventions;
using Summer.AutomappingConfiguration.Attributes;
using Summer.AutomappingConfiguration.Conventions;
using Summer.AutomappingConfiguration.MappingOverride;
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
        #region 方法

        /// <summary>
        /// 生成
        /// </summary>
        /// <param name="assemblies">程序集</param>
        /// <returns>自动可持续模型</returns>
        public AutoPersistenceModel Generate(Assembly[] assemblies)
        {
            var mappings = AutoMap.Assemblies(new AutoMapConfiguration(), assemblies);

            MethodInfo createMappingOverride = typeof(CreateMappingOverride).GetMethod("Create");

            foreach (var item in assemblies)
            {
                foreach (var itemType in item.GetTypes())
                {
                    if (itemType.GetCustomAttributes(typeof(CompositeIdentityAttribute), true).Length > 0)
                    {
                        MethodInfo method = createMappingOverride.MakeGenericMethod(itemType);
                        Type t = method.Invoke(null, null) as Type;
                        mappings.Override(t);
                    }
                }
            }

            mappings.Conventions.Setup(this.GetConventions());

            return mappings;
        }

        /// <summary>
        /// 规则
        /// </summary>
        /// <returns>规则</returns>
        private Action<IConventionFinder> GetConventions()
        {
            return finder =>
            {
                finder.Add<ClassNameConvention>();
                finder.Add<IdConvention>();
                finder.Add<CompositeIdentityConvention>();
                finder.Add<PropertyConvention>();
                finder.Add<KeyPropertyConvention>();
                finder.Add<ComponentConvention>();
                finder.Add<ReferenceConvention>();
                finder.Add<HasOneConvention>();
                finder.Add<HasManyConvention>();
                finder.Add<HasManyToManyConvention>();
                finder.Add<SubclassConvention>();
                finder.Add<JoinedSubclassConvention>();
                finder.Add<EnumConvention>();
                finder.Add<VersionConvention>();
            };
        }

        #endregion
    }
}

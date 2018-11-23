using FluentNHibernate.Conventions.Instances;
using Summer.AutomappingConfiguration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Summer.AutomappingConfiguration.Conventions
{
    /// <summary>
    /// SetProperty
    /// </summary>
    internal static class SetProperty
    {
        /// <summary>
        /// ICollectionCascadeInstance
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="attrs"></param>
        public static void ICollectionCascadeInstance(ICollectionCascadeInstance instance, object[] attrs)
        {
            CascadeAttribute cascade = attrs.FirstOrDefault(x => typeof(CascadeAttribute).IsInstanceOfType(x)) as CascadeAttribute;

            if (cascade != null)
            {
                if ((cascade.Value & Cascade.None) == Cascade.None)
                {
                    instance.None();
                }

                if ((cascade.Value & Cascade.Persist) == Cascade.Persist)
                {
                    instance.SaveUpdate();
                }

                if ((cascade.Value & Cascade.Refresh) == Cascade.Refresh)
                {
                }

                if ((cascade.Value & Cascade.Merge) == Cascade.Merge)
                {
                    instance.Merge();
                }

                if ((cascade.Value & Cascade.Remove) == Cascade.Remove)
                {
                    instance.Delete();
                }

                if ((cascade.Value & Cascade.Detach) == Cascade.Detach)
                {
                }

                if ((cascade.Value & Cascade.ReAttach) == Cascade.ReAttach)
                {
                }

                if ((cascade.Value & Cascade.DeleteOrphans) == Cascade.DeleteOrphans)
                {
                    instance.DeleteOrphan();
                }

                if ((cascade.Value & Cascade.All) == Cascade.All)
                {
                    instance.All();
                }
            }
        }

        /// <summary>
        /// ICascadeInstance
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="attrs"></param>
        public static void ICascadeInstance(ICascadeInstance instance, object[] attrs)
        {
            CascadeAttribute cascade = attrs.FirstOrDefault(x => typeof(CascadeAttribute).IsInstanceOfType(x)) as CascadeAttribute;

            if (cascade != null)
            {
                if ((cascade.Value & Cascade.None) == Cascade.None)
                {
                    instance.None();
                }

                if ((cascade.Value & Cascade.Persist) == Cascade.Persist)
                {
                    instance.SaveUpdate();
                }

                if ((cascade.Value & Cascade.Refresh) == Cascade.Refresh)
                {
                }

                if ((cascade.Value & Cascade.Merge) == Cascade.Merge)
                {
                    instance.Merge();
                }

                if ((cascade.Value & Cascade.Remove) == Cascade.Remove)
                {
                    instance.Delete();
                }

                if ((cascade.Value & Cascade.Detach) == Cascade.Detach)
                {
                }

                if ((cascade.Value & Cascade.ReAttach) == Cascade.ReAttach)
                {
                }

                if ((cascade.Value & Cascade.DeleteOrphans) == Cascade.DeleteOrphans)
                {
                }

                if ((cascade.Value & Cascade.All) == Cascade.All)
                {
                    instance.All();
                }
            }
        }
    }
}

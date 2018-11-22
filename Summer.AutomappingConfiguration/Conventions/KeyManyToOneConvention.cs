using FluentNHibernate.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Summer.AutomappingConfiguration.Conventions
{
    internal class KeyManyToOneConvention : IKeyManyToOneConvention
    {
        public void Apply(FluentNHibernate.Conventions.Instances.IKeyManyToOneInstance instance)
        {
        }
    }
}

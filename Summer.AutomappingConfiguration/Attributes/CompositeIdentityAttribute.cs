using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Summer.AutomappingConfiguration.Attributes
{
    /// <summary>
    /// CompositeIdAttribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property)]
    public class CompositeIdentityAttribute : Attribute
    {
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Summer.AutomappingConfiguration.MappingOverride
{
    /// <summary>
    /// CreateMappingOverride
    /// </summary>
    public class CreateMappingOverride
    {
        /// <summary>
        /// Create
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <returns>Type</returns>
        public static Type Create<T>()
        {
            return typeof(CompositeIdMappingOverride<T>);
        }
    }
}

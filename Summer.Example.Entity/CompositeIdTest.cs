using Summer.AutomappingConfiguration;
using Summer.AutomappingConfiguration.Attributes;
using Summer.AutomappingConfiguration.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Summer.Example.Entity
{
    [Table("CompositeIdTest")]
    [CompositeId()]
    public class CompositeIdTest
    {
        [CompositeId()]
        [Column("Key1")]
        [Length(5)]
        public virtual string Key1 { get; set; }

        [CompositeId()]
        [Column("Key2")]
        public virtual string Key2 { get; set; }

        [Column("Remark")]
        public virtual string Remark { get; set; }

        /// <summary>
        /// Equals
        /// </summary>
        /// <param name="obj">obj</param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        /// <summary>
        /// GetHashCode
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}

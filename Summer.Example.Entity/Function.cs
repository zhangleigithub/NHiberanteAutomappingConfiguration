using Summer.AutomappingConfiguration.Attributes;
using Summer.AutomappingConfiguration.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Summer.Example.Entity
{
    /// <summary>
    /// Function
    /// </summary>
    [Table("Function")]
    public class Function
    {
        [PrimaryKey(PrimaryKeys.Increment)]
        [Column("ID")]
        public virtual long Id { get; set; }

        [Column("Name")]
        public virtual string Name { get; set; }
    }
}

using Summer.AutomappingConfiguration.Attributes;
using Summer.AutomappingConfiguration.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Summer.Example.Entity
{
    [Table("Person")]
    public class Person
    {
        [Id(PrimaryKeys.Increment)]
        [Column("ID")]
        public virtual long Id { get; set; }

        [Column("Name")]
        public virtual string Name { get; set; }

        [Column("Type")]
        public virtual string Type { get; set; }
    }
}

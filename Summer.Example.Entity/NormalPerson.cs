using Summer.AutomappingConfiguration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Summer.Example.Entity
{
    [Table("NormalPerson")]
    [Extends("PersionId")]
    //[Table("Person")]
    //[Discriminated("Type", 1)]
    public class NormalPerson : Person
    {
        [Column("Remark")]
        public virtual string Remark { get; set; }
    }
}

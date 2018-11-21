using Summer.AutomappingConfiguration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Summer.Example.Entity
{
    [Table("SuperManPerson")]
    [Extends("PersionId")]
    //[Table("Person")]
    //[Discriminated("Type", 0)]
    public class SuperManPerson : Person
    {
        [Column("Fly")]
        public virtual string Fly { get; set; }
    }
}

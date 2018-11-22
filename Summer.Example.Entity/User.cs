using Summer.AutomappingConfiguration.Attributes;
using Summer.AutomappingConfiguration.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Summer.Example.Entity
{
    [Table("User")]
    public class User
    {
        [Id(PrimaryKeys.Guid)]
        [Column("ID")]
        public virtual Guid Id { get; set; }

        [Column("Name")]
        public virtual string Name { get; set; }

        [Column("Type")]
        [Length(1)]
        [DefaultValue("1")]
        [SqlType("nchar")]
        public virtual string Type { get; set; }

        [ComponentPrefix("Ex")]
        public virtual UserEx UserEx { get; set; } 

        [Column("AuthorityID")]
        public virtual IList<Authority> Authority { get; set; }
    }
}

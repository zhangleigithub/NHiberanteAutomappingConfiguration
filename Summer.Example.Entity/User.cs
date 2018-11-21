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
        [PrimaryKey(PrimaryKeys.Guid)]
        [Column("ID")]
        public virtual Guid Id { get; set; }

        [Column("Name")]
        public virtual string Name { get; set; }

        [Column("Type")]
        public virtual string Type { get; set; }

        [Column("AuthorityID")]
        public virtual IList<Authority> Authority { get; set; }
    }
}

using Summer.AutomappingConfiguration.Attributes;
using Summer.AutomappingConfiguration.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Summer.Example.Entity
{
    [Table("Authority")]
    public class Authority
    {
        [Id(PrimaryKeys.Increment)]
        [Column("ID")]
        public virtual long Id { get; set; }

        [Column("Name")]
        public virtual string Name { get; set; }

        [Column("UserID")]
        public virtual IList<User> User { get; set; }

        [Column("AuthorityID")]
        public virtual IList<Function> Function { get; set; }
    }
}

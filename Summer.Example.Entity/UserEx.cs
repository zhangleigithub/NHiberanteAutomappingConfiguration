using Summer.AutomappingConfiguration.Attributes;
using Summer.AutomappingConfiguration.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Summer.Example.Entity
{
    [Component()]
    public class UserEx
    {
        [Column("Remark")]
        public virtual string Remark { get; set; }
    }
}

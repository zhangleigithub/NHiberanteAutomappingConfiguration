using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Summer.AutomappingConfiguration.Attributes
{
    /// <summary>
    /// TableAttribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class TableAttribute : Attribute
    {
        #region 属性

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        #endregion

        #region 方法

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="name">name</param>
        public TableAttribute(string name)
        {
            this.Name = name;
        }

        #endregion
    }
}

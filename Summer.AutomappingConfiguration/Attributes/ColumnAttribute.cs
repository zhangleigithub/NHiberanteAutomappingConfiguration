using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Summer.AutomappingConfiguration.Attributes
{
    /// <summary>
    /// ColumnAttribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class ColumnAttribute : Attribute
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
        public ColumnAttribute(string name)
        {
            this.Name = name;
        }

        #endregion
    }
}

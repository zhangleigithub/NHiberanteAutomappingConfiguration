using Summer.AutomappingConfiguration.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Summer.AutomappingConfiguration.Attributes
{
    /// <summary>
    /// PrimaryKeyAttribute
    /// </summary>
    public class PrimaryKeyAttribute : Attribute
    {
        #region 属性

        /// <summary>
        /// Value
        /// </summary>
        public PrimaryKeys Value { get; set; }

        #endregion

        #region 方法

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="value">Value</param>
        public PrimaryKeyAttribute(PrimaryKeys value)
        {
            this.Value = value;
        }

        #endregion
    }
}

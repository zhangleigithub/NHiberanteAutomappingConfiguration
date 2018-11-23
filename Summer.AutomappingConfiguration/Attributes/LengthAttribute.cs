using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Summer.AutomappingConfiguration.Attributes
{
    /// <summary>
    /// LengthAttribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class LengthAttribute : Attribute
    {
        #region 属性

        /// <summary>
        /// value
        /// </summary>
        public int Value { get; set; }

        #endregion

        #region 方法

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="value">value</param>
        public LengthAttribute(int value)
        {
            this.Value = value;
        }

        #endregion
    }
}

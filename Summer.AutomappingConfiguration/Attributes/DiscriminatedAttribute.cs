using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Summer.AutomappingConfiguration.Attributes
{
    /// <summary>
    /// DiscriminatedAttribute
    /// </summary>
    public class DiscriminatedAttribute : Attribute
    {
        #region 属性

        /// <summary>
        /// ColumName
        /// </summary>
        public string ColumName { get; set; }

        /// <summary>
        /// Value
        /// </summary>
        public int Value { get; set; }

        #endregion

        #region 方法

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="columName">columName</param>
        public DiscriminatedAttribute(string columName,int value)
        {
            this.ColumName = columName;
            this.Value = value;
        }

        #endregion
    }
}

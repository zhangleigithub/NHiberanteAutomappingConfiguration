using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Summer.AutomappingConfiguration.Attributes
{
    /// <summary>
    /// ExtendsAttribute
    /// </summary>
    public class ExtendsAttribute : Attribute
    {
        #region 属性

        /// <summary>
        /// Name
        /// </summary>
        public string Key { get; set; }

        #endregion

        #region 方法

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="key">key</param>
        public ExtendsAttribute(string key)
        {
            this.Key = key;
        }

        #endregion
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Summer.AutomappingConfiguration.Attributes
{
    /// <summary>
    /// DefaultValueAttribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class DefaultValueAttribute : Attribute
    {
        #region 属性

        /// <summary>
        /// value
        /// </summary>
        public string Value { get; set; }

        #endregion

        #region 方法

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="value">value</param>
        public DefaultValueAttribute(string value)
        {
            this.Value = value;
        }

        #endregion
    }
}

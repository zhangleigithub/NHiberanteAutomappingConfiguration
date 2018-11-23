using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Summer.AutomappingConfiguration.Attributes
{
    /// <summary>
    /// CascadeAttribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class CascadeAttribute : Attribute
    {
        #region 属性

        /// <summary>
        /// value
        /// </summary>
        public Cascade Value { get; set; }

        #endregion

        #region 方法

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="value">value</param>
        public CascadeAttribute(Cascade value)
        {
            this.Value = value;
        }

        #endregion
    }

    /// <summary>
    /// Cascade
    /// </summary>
    public enum Cascade
    {
        /// <summary>
        /// None
        /// </summary>
        None = 0,

        /// <summary>
        /// Persist
        /// </summary>
        Persist = 2,

        /// <summary>
        /// Refresh
        /// </summary>
        Refresh = 4,

        /// <summary>
        /// Merge
        /// </summary>
        Merge = 8,

        /// <summary>
        /// Remove
        /// </summary>
        Remove = 16,

        /// <summary>
        /// Detach
        /// </summary>
        Detach = 32,

        /// <summary>
        /// ReAttach
        /// </summary>
        ReAttach = 64,

        /// <summary>
        /// DeleteOrphans
        /// </summary>
        DeleteOrphans = 128,

        /// <summary>
        /// All
        /// </summary>
        All = 256
    }
}

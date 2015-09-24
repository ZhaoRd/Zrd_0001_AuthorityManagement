// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EnumModel.cs" company="Skymate">
//   copyright @ 2015 skymate.
// </copyright>
// <summary>
//   带有描述的枚举.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace AuthorityManagement
{
    /// <summary>
    /// 带有描述的枚举.
    /// </summary>
    /// <typeparam name="TEnum">
    /// </typeparam>
    public class EnumModel<TEnum> 
    {
        /// <summary>
        /// 枚举描述.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 枚举的值.
        /// </summary>
        public TEnum Enum { get; set; }
    }
}